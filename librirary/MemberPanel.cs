using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class MemberPanel : Form
    {
        private readonly LibraryContext _dbContext = new();
        private readonly Member _member;
        public MemberPanel(Member member)
        {
            InitializeComponent();
            _member = member;
        }

        private void MemberPanel_Load(object sender, EventArgs e)
        {
            memberName.Text = "Welcome " + _member.Name;

            var loanedBooks = _dbContext.Bookloans.Include(l => l.BookCopy).Include(l => l.BookCopy.Book);
            var loanedBooksByMember = loanedBooks
                .Where(loaned => loaned.MembrId == _member.Id)
                .Where(loaned => !loaned.BookCopy.IsAvailable!.Value)
                .Where(loaned => !loaned.ReturnDate.HasValue);

            foreach (var book in loanedBooksByMember)
            {
                string[] bookList =
                {
                    book.BookCopy.Book.Title,
                    book.LoanDate.ToString()
                };
                var item = new ListViewItem(bookList);
                listViewLoanedBooks.Items.Add(item);
            }

            var books = _dbContext.Books.Include(b => b.Bookcopies);
            foreach (var book in books)
            {
                string[] bookList =
                {
                    book.Id.ToString(),
                    book.Title,
                    book.Category,
                    book.Author,
                    book.Bookcopies
                        .Where(bc => bc.IsAvailable != null && bc.IsAvailable.Value)
                        .Count().ToString()
                };
                var item = new ListViewItem(bookList);
                listViewAvailableBooks.Items.Add(item);
            }
        }

        private void btnLogoutMP_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
