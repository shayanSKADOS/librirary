using Microsoft.EntityFrameworkCore;

namespace Library
{
    public partial class LoginForm : Form
    {
        private LibraryContext _dbContext = new();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var hashedPassword = Hashing.QuickHash(txtPassword.Text);

            if (_dbContext.Admins.Any(admin => admin.Username == txtUsername.Text && admin.Password == hashedPassword))
            {
                var adminPanel = new AdminPanel();
                adminPanel.FormClosed += Panel_FormClosed;
                adminPanel.Show();
                this.Hide();
            }

            var userMember = _dbContext.Members.SingleOrDefault(member => member.Username == txtUsername.Text);
            if (userMember != null && userMember.Password == hashedPassword)
            {
                var memberPanel = new MemberPanel(userMember);
                memberPanel.FormClosed += Panel_FormClosed;
                memberPanel.Show();
                this.Hide();
            }

        }

        private void Panel_FormClosed(object? sender, FormClosedEventArgs e)
        {
            ClearInputs();
            this.Show();
        }

        private void ClearInputs()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
