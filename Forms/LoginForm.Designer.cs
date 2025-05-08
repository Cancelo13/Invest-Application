using FontAwesome.Sharp;

namespace InvestApp.Forms
{
    partial class LoginForm
    {
        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegister = new Button();
            this.btnExit = new IconButton();
            this.lblTitle = new Label();
            this.iconPictureBox1 = new IconPictureBox();
            this.iconPictureBox2 = new IconPictureBox();

            // Panel
            this.panel1.BackColor = Color.FromArgb(40, 40, 60);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Size = new Size(200, 450);

            // Title
            this.lblTitle.Text = "LOGIN";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Gainsboro;
            this.lblTitle.Location = new Point(250, 30);
            this.lblTitle.Size = new Size(200, 50);

            // Username TextBox
            this.txtUsername.Location = new Point(250, 150);
            this.txtUsername.Size = new Size(250, 30);
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.BackColor = Color.FromArgb(50, 50, 70);
            this.txtUsername.ForeColor = Color.Gainsboro;
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Segoe UI", 12F);

            // Password TextBox
            this.txtPassword.Location = new Point(250, 200);
            this.txtPassword.Size = new Size(250, 30);
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BackColor = Color.FromArgb(50, 50, 70);
            this.txtPassword.ForeColor = Color.Gainsboro;
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Segoe UI", 12F);

            // Login Button
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Location = new Point(250, 270);
            this.btnLogin.Size = new Size(250, 40);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.BackColor = Color.FromArgb(95, 77, 221);
            this.btnLogin.ForeColor = Color.Gainsboro;
            this.btnLogin.Click += new EventHandler(btnLogin_Click);

            // Register Button
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.Location = new Point(250, 320);
            this.btnRegister.Size = new Size(250, 40);
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.BackColor = Color.FromArgb(40, 40, 60);
            this.btnRegister.ForeColor = Color.Gainsboro;
            this.btnRegister.Click += new EventHandler(btnRegister_Click);

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
            this.ClientSize = new Size(550, 450);
            this.Controls.AddRange(new Control[] { 
                panel1, lblTitle, txtUsername, txtPassword, 
                btnLogin, btnRegister, btnExit
            });
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private Panel panel1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private IconButton btnExit;
        private Label lblTitle;
        private IconPictureBox iconPictureBox1;
        private IconPictureBox iconPictureBox2;
    }
}