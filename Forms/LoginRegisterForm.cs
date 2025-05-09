using FontAwesome.Sharp;
using Invest_Application;

namespace InvestApp.Forms
{
    public partial class LoginRegisterForm : Form
    {
        private bool isLoginMode = true;

        public LoginRegisterForm()
        {
            InitializeComponent();
            SetLoginMode();
            this.MouseDown += Form_MouseDown;
        }

        private void SetLoginMode()
        {
            isLoginMode = true;
            lblTitle.Text = "Welcome Back";
            pnlName.Visible = false;
            txtName.Visible = false;
            pnlConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            btnSubmit.Text = "LOGIN";
            btnSwitchMode.Text = "Need an account? Register";
            this.Height = 500;
        }

        private void SetRegisterMode()
        {
            isLoginMode = false;
            lblTitle.Text = "Create Account";
            pnlName.Visible = true;
            txtName.Visible = true;
            pnlConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            btnSubmit.Text = "REGISTER";
            btnSwitchMode.Text = "Already have an account? Login";
            this.Height = 600;
        }

        private void btnSwitchMode_Click(object sender, EventArgs e)
        {
            if (isLoginMode)
                SetRegisterMode();
            else
                SetLoginMode();

            ClearFields();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isLoginMode)
                HandleLogin();
            else
                HandleRegister();
        }


        private void HandleLogin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool validLogin = true;
            User? user = JsonOrganizer.GetUserFromDB(AppPaths.GetUserFile(username));
            if (user == null)
            {
                validLogin = false;
            }
            else
            {
                if (user.Password == password)
                {
                    JsonOrganizer.SaveLogin(user);
                    validLogin = true;
                }
                else
                {
                    validLogin = false;
                }
            }

            if (validLogin)
            {
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool validUsername(string username)
        {
            // Username must be 4-20 characters, alphanumeric only
            return !string.IsNullOrWhiteSpace(username) &&
                   username.Length >= 4 &&
                   username.Length <= 20 &&
                   username.All(char.IsLetterOrDigit);
        }

        bool validPassword(string password)
        {
            // Password must be at least 6 characters and contain a letter and a digit
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Length >= 6 &&
                   password.Any(char.IsLetter) &&
                   password.Any(char.IsDigit);
        }


        private void HandleRegister()
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DatabaseOrganizer.IsUserExists(username))
            {
                MessageBox.Show("Username is already taken, try another one", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validUsername(username))
            {
                MessageBox.Show("Please enter a valid username", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!validPassword(password))
            {
                MessageBox.Show("Please enter a valid password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User user = new User(name, username, password);
            DatabaseOrganizer.SaveUser(user);
            // For demo, always succeed
            MessageBox.Show("Registration successful now you can login", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetLoginMode();
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}