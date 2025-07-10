namespace Library
{
    partial class MemberPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            memberName = new Label();
            listViewLoanedBooks = new ListView();
            bookNamesColumn = new ColumnHeader();
            loanDateColumn = new ColumnHeader();
            listViewAvailableBooks = new ListView();
            columnid = new ColumnHeader();
            columnTitle = new ColumnHeader();
            columnCategory = new ColumnHeader();
            columnAuthor = new ColumnHeader();
            columnAvailable = new ColumnHeader();
            btnLogoutMP = new Button();
            SuspendLayout();
            // 
            // memberName
            // 
            memberName.Anchor = AnchorStyles.Right;
            memberName.AutoSize = true;
            memberName.Location = new Point(93, 16);
            memberName.Name = "memberName";
            memberName.Size = new Size(37, 15);
            memberName.TabIndex = 3;
            memberName.Text = "name";
            // 
            // listViewLoanedBooks
            // 
            listViewLoanedBooks.Columns.AddRange(new ColumnHeader[] { bookNamesColumn, loanDateColumn });
            listViewLoanedBooks.Location = new Point(12, 144);
            listViewLoanedBooks.Name = "listViewLoanedBooks";
            listViewLoanedBooks.Size = new Size(370, 294);
            listViewLoanedBooks.TabIndex = 4;
            listViewLoanedBooks.UseCompatibleStateImageBehavior = false;
            listViewLoanedBooks.View = View.Details;
            // 
            // bookNamesColumn
            // 
            bookNamesColumn.Text = "Book";
            bookNamesColumn.Width = 185;
            // 
            // loanDateColumn
            // 
            loanDateColumn.Text = "Loan date";
            loanDateColumn.Width = 185;
            // 
            // listViewAvailableBooks
            // 
            listViewAvailableBooks.Columns.AddRange(new ColumnHeader[] { columnid, columnTitle, columnCategory, columnAuthor, columnAvailable });
            listViewAvailableBooks.Location = new Point(418, 144);
            listViewAvailableBooks.Name = "listViewAvailableBooks";
            listViewAvailableBooks.Size = new Size(370, 294);
            listViewAvailableBooks.TabIndex = 5;
            listViewAvailableBooks.UseCompatibleStateImageBehavior = false;
            listViewAvailableBooks.View = View.Details;
            // 
            // columnid
            // 
            columnid.Text = "Id";
            columnid.Width = 30;
            // 
            // columnTitle
            // 
            columnTitle.Text = "Book Title";
            columnTitle.Width = 120;
            // 
            // columnCategory
            // 
            columnCategory.Text = "Category";
            // 
            // columnAuthor
            // 
            columnAuthor.Text = "Author";
            columnAuthor.Width = 100;
            // 
            // columnAvailable
            // 
            columnAvailable.Text = "Available books";
            // 
            // btnLogoutMP
            // 
            btnLogoutMP.Location = new Point(12, 12);
            btnLogoutMP.Name = "btnLogoutMP";
            btnLogoutMP.Size = new Size(75, 23);
            btnLogoutMP.TabIndex = 13;
            btnLogoutMP.Text = "Logout";
            btnLogoutMP.UseVisualStyleBackColor = true;
            btnLogoutMP.Click += btnLogoutMP_Click;
            // 
            // MemberPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogoutMP);
            Controls.Add(listViewAvailableBooks);
            Controls.Add(listViewLoanedBooks);
            Controls.Add(memberName);
            Name = "MemberPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MemberPanel";
            Load += MemberPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label memberName;
        private ListView listViewLoanedBooks;
        private ListView listViewAvailableBooks;
        private ColumnHeader bookNamesColumn;
        private ColumnHeader loanDateColumn;
        private ColumnHeader columnid;
        private ColumnHeader columnTitle;
        private ColumnHeader columnCategory;
        private ColumnHeader columnAuthor;
        private ColumnHeader columnAvailable;
        private Button btnLogoutMP;
    }
}