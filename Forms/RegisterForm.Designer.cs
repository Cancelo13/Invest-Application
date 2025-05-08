using FontAwesome.Sharp;

namespace InvestApp.Forms
{
    partial class RegisterForm
    {
        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.txtName = new TextBox();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.btnRegister = new Button();
            this.btnBack = new Button();
            this.btnExit = new IconButton();
            this.lblTitle = new Label();

            // Panel
            this.panel1.BackColor = Color.FromArgb(40, 40, 60);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Size = new Size(200, 500);

            // Title
            this.lblTitle.Text = "REGISTER";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Gainsboro;
            this.lblTitle.Location = new Point(250, 30);
            this.lblTitle.Size = new Size(200, 50);

            // Name TextBox
            this.txtName.Location = new Point(250, 120);
            this.txtName.Size = new Size(250, 30);
            this.txtName.PlaceholderText = "Full Name";
            this.txtName.BackColor = Color.FromArgb(50, 50, 70);
            this.txtName.ForeColor = Color.Gainsboro;
            this.txtName.BorderStyle = BorderStyle.None;
            this.txtName.Font = new Font("Segoe UI", 12F);

            // Username TextBox
            this.txtUsername.Location = new Point(250, 170);
            this.txtUsername.Size = new Size(250, 30);
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.BackColor = Color.FromArgb(50, 50, 70);
            this.txtUsername.ForeColor = Color.Gainsboro;
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Segoe UI", 12F);

            // Password TextBox
            this.txtPassword.Location = new Point(250, 220);
            this.txtPassword.Size = new Size(250, 30);
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BackColor = Color.FromArgb(50, 50, 70);
            this.txtPassword.ForeColor = Color.Gainsboro;
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Segoe UI", 12F);

            // Confirm Password TextBox
            this.txtConfirmPassword.Location = new Point(250, 270);
            this.txtConfirmPassword.Size = new Size(250, 30);
            this.txtConfirmPassword.PlaceholderText = "Confirm Password";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.BackColor = Color.FromArgb(50, 50, 70);
            this.txtConfirmPassword.ForeColor = Color.Gainsboro;
            this.txtConfirmPassword.BorderStyle = BorderStyle.None;
            this.txtConfirmPassword.Font = new Font("Segoe UI", 12F);

            // Register Button
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.Location = new Point(250, 340);
            this.btnRegister.Size = new Size(250, 40);
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.BackColor = Color.FromArgb(95, 77, 221);
            this.btnRegister.ForeColor = Color.Gainsboro;
            this.btnRegister.Click += new EventHandler(btnRegister_Click);

            // Back Button
            this.btnBack.Text = "BACK TO LOGIN";
            this.btnBack.Location = new Point(250, 390);
            this.btnBack.Size = new Size(250, 40);
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Color.FromArgb(40, 40, 60);
            this.btnBack.ForeColor = Color.Gainsboro;
            this.btnBack.Click += new EventHandler(btnBack_Click);

            // Exit Button
            this.btnExit.Text = "";
            this.btnExit.IconChar = IconChar.Times;
            this.btnExit.IconColor = Color.Gainsboro;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Size = new Size(30, 30);
            this.btnExit.Location = new Point(520, 10);
            this.btnExit.Click += new EventHandler(btnExit_Click);

            // Form Settings
            this.ClientSize = new Size(550, 500);
            this.Controls.AddRange(new Control[] { 
                panel1, lblTitle, txtName, txtUsername, 
                txtPassword, txtConfirmPassword, 
                btnRegister, btnBack, btnExit 
            });
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private Panel panel1;
        private TextBox txtName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnBack;
        private IconButton btnExit;
        private Label lblTitle;
    }
}