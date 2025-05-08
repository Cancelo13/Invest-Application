using FontAwesome.Sharp;
using InvestApp.Models;

namespace InvestApp.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
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
            var user = new User
            {
                Name = txtName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            // For now, just show success
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.Hide();
            new LoginForm().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}