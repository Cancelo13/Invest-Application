using FontAwesome.Sharp;

namespace InvestApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CustomizeComponents();
        }

        private void CustomizeComponents()
        {
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.ForeColor = Color.Gainsboro;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // For now, always authenticate successfully
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Add main form navigation here
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}