using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace Library
{
    public partial class AdminPanel : Form
    {
        private readonly LibraryContext _dbContext = new LibraryContext();
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username or Password is not filled!");
                return;
            }

            if (IsThereAnyAdminOrMemberWithThisUsername(txtUserName.Text))
            {
                MessageBox.Show("This username is used!");
                return;
            }

            var hashedPassword = Hashing.QuickHash(txtPassword.Text);
            if (checkIsAdmin.Checked)
            {
                var newAdmin = new Admin()
                {
                    Username = txtUserName.Text,
                    Password = hashedPassword,
                };
                _dbContext.Admins.Add(newAdmin);
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

            _dbContext.SaveChanges();
            ClearInputs();
            RefreshMembers();
            RefreshCmbMembers();
        }

        private void RefreshCmbMembers()
        {
            cmbMembers.Items.Clear();
            var members = _dbContext.Members.Select(m => m.Id + ". " + m.Name).ToArray();
            cmbMembers.Items.AddRange(members);
            if (members.Length != 0)
            {
                cmbMembers.SelectedIndex = 0;
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtUserName.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
        }

        private bool IsThereAnyAdminOrMemberWithThisUsername(string username)
        {
            return _dbContext.Admins.Any(admin => admin.Username == username) || _dbContext.Members.Any(member => member.Username == username);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsKeyDigitOrControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private static bool IsKeyDigitOrControl(char key)
        {
            return char.IsControl(key) || char.IsDigit(key);
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
                ListViewItem item = CreateListViewItemBasedOnMember(member);
                memberList.Items.Add(item);
            }
        }

        private static ListViewItem CreateListViewItemBasedOnMember(Member member)
        {
            return new ListViewItem([member.Id.ToString(), member.Name, member.Phone.ToString()]);
        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            if (!_dbContext.Books.Any(book => book.Title == txtTitle.Text))
            {
                BookService.CreateBook(txtTitle.Text, category.Text, txtAuthor.Text, Int32.Parse(txtAvailableNums.Text));
            }
            else
            {
                var book = _dbContext.Books.Single(book => book.Title == txtTitle.Text);
                BookService.AddBookCopiesForABook(book.Id, Int32.Parse(txtAvailableNums.Text));
            }

            RefreshBooks();
            RefreshCmbBooks();
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
                return;
            }

            var books = _dbContext.Books.Include(b => b.Bookcopies);
            var bookId = GetBookIdFromCmbBooks();
            var book = books.SingleOrDefault(bookID => bookID.Id.ToString() == bookId);
            if (book == null
                || book.Bookcopies
                .Where(bc => bc.IsAvailable != null && bc.IsAvailable.Value)
                .Count() <= 0)
            {
                MessageBox.Show("Book copy not available!");
                return;
            }

            var availibleBookCopy = GetFirstAvailibleBookCopy(book);

            if (availibleBookCopy == null)
            {
                MessageBox.Show($"Book {book.Title} is not available");
                return;
            }

            availibleBookCopy.IsAvailable = false;

            var memberId = GetMemberIdFromCmbMembers();
            var checkOutMember = _dbContext.Members.SingleOrDefault(member => member.Id.ToString() == memberId);
            if (checkOutMember == null)
            {
                MessageBox.Show($"Member with id {memberId} is not available");
                return;
            }

            var loandBook = new Bookloan()
            {
                LoanDate = DateTime.Now,
                BookCopy = availibleBookCopy,
                Membr = checkOutMember,
            };
            _dbContext.Bookloans.Add(loandBook);
            _dbContext.SaveChanges();
            RefreshLoanedBooks();
        }

        private string GetMemberIdFromCmbMembers()
        {
            return cmbMembers.Text.Split(".")[0];
        }

        private static Bookcopy? GetFirstAvailibleBookCopy(Book book)
        {
            return book.Bookcopies.FirstOrDefault(bookAvailible =>
                            bookAvailible.IsAvailable != null && bookAvailible.IsAvailable.Value);
        }

        private string GetBookIdFromCmbBooks()
        {
            return cmbBooks.Text.Split('.')[0];
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

            var selectedLoanId = GetSelectedLoanId();
            var selectedLoan = _dbContext.Bookloans.Single(l => l.Id == selectedLoanId);
            selectedLoan.ReturnDate = DateTime.Now;

            var bookCopy = _dbContext.Bookloans
                .Where(bl => bl.Id == selectedLoanId)
                .Select(bl => bl.BookCopy)
                .Single();
            bookCopy.IsAvailable = true;

            _dbContext.SaveChanges();
            RefreshLoanedBooks();
        }

        private int GetSelectedLoanId()
        {
            return int.Parse(loansViewList.SelectedItems[0].SubItems[0].Text);
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            RefreshBooks();
            RefreshMembers();
            RefreshLoanedBooks();
            RefreshCmbBooks();
            RefreshCmbMembers();
        }

        private void RefreshCmbBooks()
        {
            cmbBooks.Items.Clear();
            var books = _dbContext.Books.Select(b => b.Id + ". " + b.Title).ToArray();
            cmbBooks.Items.AddRange(books);
            if (books.Length != 0)
            {
                cmbBooks.SelectedIndex = 0;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
            if (!IsKeyLetterOrControlOrSpace(e))
            {
                e.Handled = true;
            }
        }

        private static bool IsKeyLetterOrControlOrSpace(KeyPressEventArgs e)
        {
            return char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ' ';
        }
    }
}
