namespace Library
{
    partial class AdminPanel
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
            components = new System.ComponentModel.Container();
            btnAddMember = new Button();
            txtUserName = new TextBox();
            tabAdminPanel = new TabControl();
            tabMemberAdd = new TabPage();
            btnLogoutMC = new Button();
            checkIsAdmin = new CheckBox();
            btnRefresh = new Button();
            txtPhone = new TextBox();
            txtName = new TextBox();
            txtPassword = new TextBox();
            memberList = new ListView();
            Id = new ColumnHeader();
            memberName = new ColumnHeader();
            Phone = new ColumnHeader();
            Books = new ColumnHeader();
            tabBookAdd = new TabPage();
            button2AbtnLogoutBC = new Button();
            btnRefreshBooks = new Button();
            txtAvailableNums = new TextBox();
            booksViewList = new DataGridView();
            columnID = new DataGridViewTextBoxColumn();
            columnTitle = new DataGridViewTextBoxColumn();
            columnCategory = new DataGridViewTextBoxColumn();
            columnAuthor = new DataGridViewTextBoxColumn();
            columnAvailable = new DataGridViewTextBoxColumn();
            category = new ComboBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            AddBook = new Button();
            tabCheckouts = new TabPage();
            btnLogoutCO = new Button();
            cmbBooks = new ComboBox();
            cmbMembers = new ComboBox();
            btnRefreshLoanedBooks = new Button();
            loansViewList = new ListView();
            idColumn = new ColumnHeader();
            columnMember = new ColumnHeader();
            columnBookName = new ColumnHeader();
            columnStartTime = new ColumnHeader();
            columnEndTime = new ColumnHeader();
            statusColumn = new ColumnHeader();
            btnReturn = new Button();
            btnCheckout = new Button();
            memberBindingSource = new BindingSource(components);
            memberBindingSource1 = new BindingSource(components);
            tabAdminPanel.SuspendLayout();
            tabMemberAdd.SuspendLayout();
            tabBookAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksViewList).BeginInit();
            tabCheckouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memberBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memberBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // btnAddMember
            // 
            btnAddMember.Location = new Point(680, 38);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(106, 31);
            btnAddMember.TabIndex = 0;
            btnAddMember.Text = "Add member";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(8, 38);
            txtUserName.Multiline = true;
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "UserName";
            txtUserName.Size = new Size(142, 31);
            txtUserName.TabIndex = 2;
            txtUserName.KeyPress += txtUserName_KeyPress;
            // 
            // tabAdminPanel
            // 
            tabAdminPanel.Controls.Add(tabMemberAdd);
            tabAdminPanel.Controls.Add(tabBookAdd);
            tabAdminPanel.Controls.Add(tabCheckouts);
            tabAdminPanel.Dock = DockStyle.Fill;
            tabAdminPanel.Location = new Point(0, 0);
            tabAdminPanel.Name = "tabAdminPanel";
            tabAdminPanel.SelectedIndex = 0;
            tabAdminPanel.Size = new Size(800, 450);
            tabAdminPanel.TabIndex = 3;
            // 
            // tabMemberAdd
            // 
            tabMemberAdd.Controls.Add(btnLogoutMC);
            tabMemberAdd.Controls.Add(checkIsAdmin);
            tabMemberAdd.Controls.Add(btnRefresh);
            tabMemberAdd.Controls.Add(txtPhone);
            tabMemberAdd.Controls.Add(txtName);
            tabMemberAdd.Controls.Add(txtPassword);
            tabMemberAdd.Controls.Add(memberList);
            tabMemberAdd.Controls.Add(btnAddMember);
            tabMemberAdd.Controls.Add(txtUserName);
            tabMemberAdd.Location = new Point(4, 24);
            tabMemberAdd.Name = "tabMemberAdd";
            tabMemberAdd.Padding = new Padding(3);
            tabMemberAdd.Size = new Size(792, 422);
            tabMemberAdd.TabIndex = 0;
            tabMemberAdd.Text = "Member control";
            tabMemberAdd.UseVisualStyleBackColor = true;
            // 
            // btnLogoutMC
            // 
            btnLogoutMC.Location = new Point(8, 6);
            btnLogoutMC.Name = "btnLogoutMC";
            btnLogoutMC.Size = new Size(75, 23);
            btnLogoutMC.TabIndex = 9;
            btnLogoutMC.Text = "Logout";
            btnLogoutMC.UseVisualStyleBackColor = true;
            btnLogoutMC.Click += btnLogoutMC_Click;
            // 
            // checkIsAdmin
            // 
            checkIsAdmin.AutoSize = true;
            checkIsAdmin.Location = new Point(691, 75);
            checkIsAdmin.Name = "checkIsAdmin";
            checkIsAdmin.Size = new Size(71, 19);
            checkIsAdmin.TabIndex = 8;
            checkIsAdmin.Text = "Is admin";
            checkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(699, 113);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefreshMembers_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(452, 38);
            txtPhone.Multiline = true;
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone";
            txtPhone.Size = new Size(142, 31);
            txtPhone.TabIndex = 6;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // txtName
            // 
            txtName.Location = new Point(304, 38);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(142, 31);
            txtName.TabIndex = 5;
            txtName.KeyPress += txtName_KeyPress;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(156, 38);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(142, 31);
            txtPassword.TabIndex = 4;
            // 
            // memberList
            // 
            memberList.Columns.AddRange(new ColumnHeader[] { Id, memberName, Phone, Books });
            memberList.Dock = DockStyle.Bottom;
            memberList.Location = new Point(3, 142);
            memberList.Name = "memberList";
            memberList.Size = new Size(786, 277);
            memberList.TabIndex = 3;
            memberList.UseCompatibleStateImageBehavior = false;
            memberList.View = View.Details;
            // 
            // Id
            // 
            Id.Text = "Id";
            // 
            // memberName
            // 
            memberName.Text = "Member Name";
            memberName.Width = 160;
            // 
            // Phone
            // 
            Phone.Text = "Phone";
            // 
            // Books
            // 
            Books.Text = "Books";
            Books.Width = 250;
            // 
            // tabBookAdd
            // 
            tabBookAdd.Controls.Add(button2AbtnLogoutBC);
            tabBookAdd.Controls.Add(btnRefreshBooks);
            tabBookAdd.Controls.Add(txtAvailableNums);
            tabBookAdd.Controls.Add(booksViewList);
            tabBookAdd.Controls.Add(category);
            tabBookAdd.Controls.Add(txtAuthor);
            tabBookAdd.Controls.Add(txtTitle);
            tabBookAdd.Controls.Add(AddBook);
            tabBookAdd.Location = new Point(4, 24);
            tabBookAdd.Name = "tabBookAdd";
            tabBookAdd.Padding = new Padding(3);
            tabBookAdd.Size = new Size(792, 422);
            tabBookAdd.TabIndex = 1;
            tabBookAdd.Text = "Book control";
            tabBookAdd.UseVisualStyleBackColor = true;
            // 
            // button2AbtnLogoutBC
            // 
            button2AbtnLogoutBC.Location = new Point(8, 6);
            button2AbtnLogoutBC.Name = "button2AbtnLogoutBC";
            button2AbtnLogoutBC.Size = new Size(75, 23);
            button2AbtnLogoutBC.TabIndex = 12;
            button2AbtnLogoutBC.Text = "Logout";
            button2AbtnLogoutBC.UseVisualStyleBackColor = true;
            button2AbtnLogoutBC.Click += button2AbtnLogoutBC_Click;
            // 
            // btnRefreshBooks
            // 
            btnRefreshBooks.Location = new Point(678, 161);
            btnRefreshBooks.Name = "btnRefreshBooks";
            btnRefreshBooks.Size = new Size(106, 31);
            btnRefreshBooks.TabIndex = 11;
            btnRefreshBooks.Text = "Refresh";
            btnRefreshBooks.UseVisualStyleBackColor = true;
            btnRefreshBooks.Click += btnRefreshBooks_Click;
            // 
            // txtAvailableNums
            // 
            txtAvailableNums.Location = new Point(452, 38);
            txtAvailableNums.Multiline = true;
            txtAvailableNums.Name = "txtAvailableNums";
            txtAvailableNums.PlaceholderText = "Available numbers";
            txtAvailableNums.Size = new Size(142, 31);
            txtAvailableNums.TabIndex = 10;
            // 
            // booksViewList
            // 
            booksViewList.AllowUserToAddRows = false;
            booksViewList.AllowUserToDeleteRows = false;
            booksViewList.BackgroundColor = SystemColors.Window;
            booksViewList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksViewList.Columns.AddRange(new DataGridViewColumn[] { columnID, columnTitle, columnCategory, columnAuthor, columnAvailable });
            booksViewList.Dock = DockStyle.Bottom;
            booksViewList.Location = new Point(3, 198);
            booksViewList.Name = "booksViewList";
            booksViewList.ReadOnly = true;
            booksViewList.Size = new Size(786, 221);
            booksViewList.TabIndex = 9;
            // 
            // columnID
            // 
            columnID.HeaderText = "ID";
            columnID.Name = "columnID";
            columnID.ReadOnly = true;
            columnID.Width = 140;
            // 
            // columnTitle
            // 
            columnTitle.HeaderText = "Title";
            columnTitle.Name = "columnTitle";
            columnTitle.ReadOnly = true;
            columnTitle.Width = 200;
            // 
            // columnCategory
            // 
            columnCategory.HeaderText = "Category";
            columnCategory.Name = "columnCategory";
            columnCategory.ReadOnly = true;
            // 
            // columnAuthor
            // 
            columnAuthor.HeaderText = "Author";
            columnAuthor.Name = "columnAuthor";
            columnAuthor.ReadOnly = true;
            columnAuthor.Width = 200;
            // 
            // columnAvailable
            // 
            columnAvailable.HeaderText = "Books available";
            columnAvailable.Name = "columnAvailable";
            columnAvailable.ReadOnly = true;
            columnAvailable.Resizable = DataGridViewTriState.True;
            columnAvailable.SortMode = DataGridViewColumnSortMode.NotSortable;
            columnAvailable.ToolTipText = "Show Id's";
            // 
            // category
            // 
            category.FormattingEnabled = true;
            category.Items.AddRange(new object[] { "Biology", "Physics", "Math", "Chemistry" });
            category.Location = new Point(304, 43);
            category.Name = "category";
            category.Size = new Size(142, 23);
            category.TabIndex = 5;
            category.Text = "Biology";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(156, 38);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "Author";
            txtAuthor.Size = new Size(142, 31);
            txtAuthor.TabIndex = 4;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(8, 38);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title";
            txtTitle.Size = new Size(142, 31);
            txtTitle.TabIndex = 3;
            // 
            // AddBook
            // 
            AddBook.Location = new Point(678, 38);
            AddBook.Name = "AddBook";
            AddBook.Size = new Size(106, 31);
            AddBook.TabIndex = 2;
            AddBook.Text = "Add book";
            AddBook.UseVisualStyleBackColor = true;
            AddBook.Click += AddBook_Click;
            // 
            // tabCheckouts
            // 
            tabCheckouts.Controls.Add(btnLogoutCO);
            tabCheckouts.Controls.Add(cmbBooks);
            tabCheckouts.Controls.Add(cmbMembers);
            tabCheckouts.Controls.Add(btnRefreshLoanedBooks);
            tabCheckouts.Controls.Add(loansViewList);
            tabCheckouts.Controls.Add(btnReturn);
            tabCheckouts.Controls.Add(btnCheckout);
            tabCheckouts.Location = new Point(4, 24);
            tabCheckouts.Name = "tabCheckouts";
            tabCheckouts.Padding = new Padding(3);
            tabCheckouts.Size = new Size(792, 422);
            tabCheckouts.TabIndex = 2;
            tabCheckouts.Text = "Checkouts";
            tabCheckouts.UseVisualStyleBackColor = true;
            // 
            // btnLogoutCO
            // 
            btnLogoutCO.Location = new Point(6, 6);
            btnLogoutCO.Name = "btnLogoutCO";
            btnLogoutCO.Size = new Size(75, 23);
            btnLogoutCO.TabIndex = 12;
            btnLogoutCO.Text = "Logout";
            btnLogoutCO.UseVisualStyleBackColor = true;
            btnLogoutCO.Click += btnLogoutCO_Click;
            // 
            // cmbBooks
            // 
            cmbBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBooks.FormattingEnabled = true;
            cmbBooks.Location = new Point(154, 38);
            cmbBooks.Name = "cmbBooks";
            cmbBooks.Size = new Size(142, 23);
            cmbBooks.TabIndex = 11;
            // 
            // cmbMembers
            // 
            cmbMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMembers.FormattingEnabled = true;
            cmbMembers.Location = new Point(6, 38);
            cmbMembers.Name = "cmbMembers";
            cmbMembers.Size = new Size(142, 23);
            cmbMembers.TabIndex = 10;
            // 
            // btnRefreshLoanedBooks
            // 
            btnRefreshLoanedBooks.Location = new Point(680, 168);
            btnRefreshLoanedBooks.Name = "btnRefreshLoanedBooks";
            btnRefreshLoanedBooks.Size = new Size(106, 31);
            btnRefreshLoanedBooks.TabIndex = 9;
            btnRefreshLoanedBooks.Text = "Refresh";
            btnRefreshLoanedBooks.UseVisualStyleBackColor = true;
            btnRefreshLoanedBooks.Click += btnRefreshLoanedBooks_Click;
            // 
            // loansViewList
            // 
            loansViewList.Columns.AddRange(new ColumnHeader[] { idColumn, columnMember, columnBookName, columnStartTime, columnEndTime, statusColumn });
            loansViewList.Dock = DockStyle.Bottom;
            loansViewList.FullRowSelect = true;
            loansViewList.Location = new Point(3, 205);
            loansViewList.MultiSelect = false;
            loansViewList.Name = "loansViewList";
            loansViewList.Size = new Size(786, 214);
            loansViewList.TabIndex = 8;
            loansViewList.UseCompatibleStateImageBehavior = false;
            loansViewList.View = View.Details;
            // 
            // idColumn
            // 
            idColumn.DisplayIndex = 4;
            idColumn.Text = "Id";
            idColumn.Width = 0;
            // 
            // columnMember
            // 
            columnMember.DisplayIndex = 0;
            columnMember.Text = "Member";
            // 
            // columnBookName
            // 
            columnBookName.DisplayIndex = 1;
            columnBookName.Text = "Book";
            // 
            // columnStartTime
            // 
            columnStartTime.DisplayIndex = 2;
            columnStartTime.Text = "Start time";
            columnStartTime.Width = 120;
            // 
            // columnEndTime
            // 
            columnEndTime.DisplayIndex = 3;
            columnEndTime.Text = "End time";
            // 
            // statusColumn
            // 
            statusColumn.Text = "Status";
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(680, 33);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(106, 31);
            btnReturn.TabIndex = 7;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(319, 33);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(106, 31);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // memberBindingSource
            // 
            memberBindingSource.DataSource = typeof(Member);
            // 
            // memberBindingSource1
            // 
            memberBindingSource1.DataSource = typeof(Member);
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabAdminPanel);
            Name = "AdminPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminPanel";
            Load += AdminPanel_Load;
            tabAdminPanel.ResumeLayout(false);
            tabMemberAdd.ResumeLayout(false);
            tabMemberAdd.PerformLayout();
            tabBookAdd.ResumeLayout(false);
            tabBookAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)booksViewList).EndInit();
            tabCheckouts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)memberBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)memberBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddMember;
        private TextBox txtUserName;
        private TabControl tabAdminPanel;
        private TabPage tabMemberAdd;
        private TabPage tabBookAdd;
        private Button AddBook;
        private TextBox txtPhone;
        private TextBox txtName;
        private TextBox txtPassword;
        private Button btnRefresh;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private ComboBox category;
        private ListView memberList;
        private ColumnHeader Id;
        private ColumnHeader memberName;
        private ColumnHeader Phone;
        private ColumnHeader Books;
        private DataGridView booksViewList;
        private TextBox txtAvailableNums;
        private Button btnRefreshBooks;
        private TabPage tabCheckouts;
        private Button btnReturn;
        private Button btnCheckout;
        private BindingSource memberBindingSource;
        private BindingSource memberBindingSource1;
        private CheckBox checkIsAdmin;
        private DataGridViewTextBoxColumn columnID;
        private DataGridViewTextBoxColumn columnTitle;
        private DataGridViewTextBoxColumn columnCategory;
        private DataGridViewTextBoxColumn columnAuthor;
        private DataGridViewTextBoxColumn columnAvailable;
        private Button btnRefreshLoanedBooks;
        private ListView loansViewList;
        private ColumnHeader columnMember;
        private ColumnHeader columnBookName;
        private ColumnHeader columnStartTime;
        private ColumnHeader columnEndTime;
        private ColumnHeader idColumn;
        private ColumnHeader statusColumn;
        private ComboBox cmbBooks;
        private ComboBox cmbMembers;
        private Button btnLogoutMC;
        private Button button2AbtnLogoutBC;
        private Button btnLogoutCO;
    }
}