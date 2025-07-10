using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace Library
{
    public partial class AdminPanel : Form
    {
        private LibraryContext _dbContext = new LibraryContext();
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            var hashedPassword = Hashing.QuickHash(txtPassword.Text);
            if (!_dbContext.Admins.Any(admin => admin.Username == txtUserName.Text) && _dbContext.Members.SingleOrDefault(member => member.Username == txtUserName.Text) == null)
            {
                if (checkIsAdmin.Checked)
                {
                    if (txtUserName.Text == "" || txtPassword.Text == "")
                    {
                        MessageBox.Show("Username or Password is not filled!");
                    }
                    else
                    {
                        var newAdmin = new Admin()
                        {
                            Username = txtUserName.Text,
                            Password = hashedPassword,
                        };
                        _dbContext.Admins.Add(newAdmin);
                    }
                }
                else if (!checkIsAdmin.Checked)
                {
                    if (txtUserName.Text == "" || txtPassword.Text == "" || txtName.Text == "" || txtPhone.Text == "")
                    {
                        MessageBox.Show("You should fill all boxes!");
                    }
                    else
                    {
                        var newMember = new Member()
                        {
                            Name = txtName.Text,
                            Username = txtUserName.Text,
                            Password = hashedPassword,
                            Phone = Int32.Parse(txtPhone.Text),
                        };
                        _dbContext.Members.Add(newMember);
                    }
                }
            }
            else MessageBox.Show("This username is used!");

            txtName.Clear(); txtUserName.Clear(); txtPhone.Clear(); txtPassword.Clear();
            _dbContext.SaveChanges();
            RefreshMembers();
            cmbMembers.Items.Clear();
            cmbMembers.Items.AddRange(_dbContext.Members.Select(m => m.Id + ". " + m.Name).ToArray());
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRefreshMembers_Click(object sender, EventArgs e)
        {
            RefreshMembers();
        }

        private void RefreshMembers()
        {
            var members = _dbContext.Members;
            memberList.Items.Clear();
            foreach (var member in members)
            {
                string[] memberInfo = { member.Id.ToString(), member.Name, member.Phone.ToString() };
                var item = new ListViewItem(memberInfo);
                memberList.Items.Add(item);
            }
        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            if (_dbContext.Books.SingleOrDefault(book => book.Title == txtTitle.Text) == null)
            {
                var book = new Book()
                {
                    Author = txtAuthor.Text,
                    Title = txtTitle.Text,
                    Category = category.Text
                };
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();

                for (int i = 0; i < Int32.Parse(txtAvailableNums.Text); i++)
                {
                    var bookCopy = new Bookcopy()
                    {
                        BookId = book.Id,
                    };
                    _dbContext.Bookcopies.Add(bookCopy);
                }
            }
            else
            {
                var book = _dbContext.Books.Single(book => book.Title == txtTitle.Text);
                for (int i = 0; i < Int32.Parse(txtAvailableNums.Text); i++)
                {
                    var bookCopy = new Bookcopy()
                    {
                        BookId = book.Id,
                    };
                    _dbContext.Bookcopies.Add(bookCopy);
                }
            }
            _dbContext.SaveChanges();

            RefreshBooks();
            cmbBooks.Items.Clear();
            cmbBooks.Items.AddRange(_dbContext.Books.Select(b => b.Id + ". " + b.Title).ToArray());
        }

        private void btnRefreshBooks_Click(object sender, EventArgs e)
        {
            RefreshBooks();
        }

        private void RefreshBooks()
        {
            booksViewList.Rows.Clear();
            var books = _dbContext.Books.Include(b => b.Bookcopies);
            foreach (var book in books)
            {
                var bookInList = new ArrayList()
                {
                    book.Id,
                    book.Title,
                    book.Category,
                    book.Author,
                    book.Bookcopies
                        .Where(bc => bc.IsAvailable != null && bc.IsAvailable.Value)
                        .Count()
                };

                booksViewList.Rows.Add(bookInList.ToArray());
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cmbMembers.Text == "" || cmbBooks.Text == "")
            {
                MessageBox.Show("Choose member and book first!");
            }
            else
            {
                var books = _dbContext.Books.Include(b => b.Bookcopies);
                var bookId = cmbBooks.Text.Split('.')[0];
                var book = books.SingleOrDefault(bookID => bookID.Id.ToString() == bookId);
                var members = _dbContext.Members;
                if (book != null
                    && book.Bookcopies
                    .Where(bc => bc.IsAvailable != null && bc.IsAvailable.Value)
                    .Count() > 0)
                {
                    var availibleBook = book.Bookcopies.FirstOrDefault(bookAvailible =>
                        bookAvailible.IsAvailable != null && bookAvailible.IsAvailable.Value);

                    if (availibleBook == null)
                    {
                        MessageBox.Show($"Book {book.Title} is not available");
                        return;
                    }

                    availibleBook.IsAvailable = false;

                    var memberId = cmbMembers.Text.Split(".")[0];
                    var checkOutMember = members.SingleOrDefault(member => member.Id.ToString() == memberId);
                    if (checkOutMember == null)
                    {
                        MessageBox.Show($"Member with id {memberId} is not available");
                        return;
                    }

                    var loandBook = new Bookloan()
                    {
                        LoanDate = DateTime.Now,
                        BookCopy = availibleBook,
                        Membr = checkOutMember,
                    };
                    _dbContext.Bookloans.Add(loandBook);
                    _dbContext.SaveChanges();
                    RefreshLoanedBooks();
                }
                else
                    MessageBox.Show("Book copy not available!");
            }
        }

        private void btnRefreshLoanedBooks_Click(object sender, EventArgs e)
        {
            RefreshLoanedBooks();
        }

        private void RefreshLoanedBooks()
        {
            var loans = _dbContext.Bookloans.Include(l => l.Membr).Include(l => l.BookCopy).Include(l => l.BookCopy.Book);
            loansViewList.Items.Clear();

            loansViewList.Items.AddRange(
                loans.OrderBy(l => l.ReturnDate).Select(loan => CreateListViewItemBasedOnLoan(loan)).ToArray()
            );
        }

        private static ListViewItem CreateListViewItemBasedOnLoan(Bookloan loan)
        {
            return new ListViewItem(
                    [
                        loan.Id.ToString(),
                        loan.Membr.Name,
                        loan.BookCopy.Book.Title,
                        loan.LoanDate.ToString(),
                        loan.ReturnDate.HasValue ? loan.ReturnDate.Value.ToString() : "",
                        loan.ReturnDate.HasValue ? "Returned" : "Hold"
                    ]
                );
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (loansViewList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a loan first");
                return;
            }

            var selectedLoanId = int.Parse(loansViewList.SelectedItems[0].SubItems[0].Text);
            var bookCopy = _dbContext.Bookloans
                .Where(bl => bl.Id == selectedLoanId)
                .Select(bl => bl.BookCopy)
                .Single();
            bookCopy.IsAvailable = true;

            var selectedLoan = _dbContext.Bookloans.Single(l => l.Id == selectedLoanId);
            selectedLoan.ReturnDate = DateTime.Now;

            _dbContext.SaveChanges();
            RefreshLoanedBooks();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            RefreshBooks();
            RefreshMembers();
            RefreshLoanedBooks();

            cmbBooks.Items.AddRange(_dbContext.Books.Select(b => b.Id + ". " + b.Title).ToArray());
            cmbMembers.Items.AddRange(_dbContext.Members.Select(m => m.Id + ". " + m.Name).ToArray());
        }

        private void btnLogoutMC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2AbtnLogoutBC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogoutCO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
