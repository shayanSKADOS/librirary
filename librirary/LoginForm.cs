using Microsoft.EntityFrameworkCore;

namespace Library
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loggedInAdmin = AdminService.Login(txtUsername.Text, txtPassword.Text);
            if (loggedInAdmin != null)
            {
                ShowAdminPanel();
                return;
            }

            var loggedInMember = MemberService.Login(txtUsername.Text, txtPassword.Text);
            if (loggedInMember != null)
            {
                ShowMemberPanel(loggedInMember);
                return;
            }

            MessageBox.Show("Username or password is incorrect");
        }

        private void ShowMemberPanel(Member loggedInMember)
        {
            var memberPanel = new MemberPanel(loggedInMember);
            memberPanel.FormClosed += Panel_FormClosed;
            memberPanel.Show();
            this.Hide();
        }

        private void ShowAdminPanel()
        {
            var adminPanel = new AdminPanel();
            adminPanel.FormClosed += Panel_FormClosed;
            adminPanel.Show();
            this.Hide();
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AdminService.CreateAdminIfNotExists();
        }
    }
}
