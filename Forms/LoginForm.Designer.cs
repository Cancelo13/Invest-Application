using FontAwesome.Sharp;

namespace InvestApp.Forms
{
    partial class LoginForm
    {
        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.panelLogo = new Panel();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegister = new Button();
            this.btnExit = new IconButton();
            this.lblTitle = new Label();
            this.iconUser = new IconPictureBox();
            this.iconLock = new IconPictureBox();
            this.panel2 = new Panel(); // Username underline
            this.panel3 = new Panel(); // Password underline
            // Left Panel
            this.panel1.BackColor = Color.FromArgb(95, 77, 221);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Size = new Size(200, 450);

            // Logo Panel
            this.panelLogo.Size = new Size(200, 200);
            this.panelLogo.Dock = DockStyle.Top;
            this.panelLogo.BackColor = Color.FromArgb(95, 77, 221);
            this.panel1.Controls.Add(panelLogo);

            // Logo Image
             this.panelLogo.Size = new Size(200, 200);
            this.panelLogo.Dock = DockStyle.Top;
            this.panelLogo.BackColor = Color.FromArgb(95, 77, 221);
            this.panel1.Controls.Add(panelLogo);

            // Title
            this.lblTitle.Text = "Welcome Back";
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblTitle.Location = new Point(250, 40);
            this.lblTitle.Size = new Size(300, 50);

            // Username Icon
            this.iconUser.IconChar = IconChar.UserAlt;
            this.iconUser.IconSize = 25;
            this.iconUser.IconColor = Color.FromArgb(95, 77, 221);
            this.iconUser.Location = new Point(250, 150);
            this.iconUser.Size = new Size(32, 32);

            // Username TextBox
            this.txtUsername.Location = new Point(290, 150);
            this.txtUsername.Size = new Size(250, 30);
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.BackColor = Color.FromArgb(245, 245, 245);
            this.txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Segoe UI", 12F);

            // Username Underline
            this.panel2.BackColor = Color.FromArgb(95, 77, 221);
            this.panel2.Location = new Point(290, 180);
            this.panel2.Size = new Size(250, 2);

            // Password Icon
            this.iconLock.IconChar = IconChar.Lock;
            this.iconLock.IconSize = 25;
            this.iconLock.IconColor = Color.FromArgb(95, 77, 221);
            this.iconLock.Location = new Point(250, 220);
            this.iconLock.Size = new Size(32, 32);

            // Password TextBox
            this.txtPassword.Location = new Point(290, 220);
            this.txtPassword.Size = new Size(250, 30);
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BackColor = Color.FromArgb(245, 245, 245);
            this.txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Segoe UI", 12F);

            // Password Underline
            this.panel3.BackColor = Color.FromArgb(95, 77, 221);
            this.panel3.Location = new Point(290, 250);
            this.panel3.Size = new Size(250, 2);

            // Login Button
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Location = new Point(250, 290);
            this.btnLogin.Size = new Size(290, 45);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.BackColor = Color.FromArgb(95, 77, 221);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(btnLogin_Click);

            // Register Button
            this.btnRegister.Text = "Don't have an account? Register here";
            this.btnRegister.Location = new Point(250, 350);
            this.btnRegister.Size = new Size(290, 35);
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.BackColor = Color.FromArgb(245, 245, 245);
            this.btnRegister.ForeColor = Color.FromArgb(95, 77, 221);
            this.btnRegister.Font = new Font("Segoe UI", 9F);
            this.btnRegister.Cursor = Cursors.Hand;
            this.btnRegister.Click += new EventHandler(btnRegister_Click);

            // Exit Button
            this.btnExit.Text = "";
            this.btnExit.IconChar = IconChar.Times;
            this.btnExit.IconColor = Color.FromArgb(95, 77, 221);
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Size = new Size(32, 32);
            this.btnExit.Location = new Point(558, 12);
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.Click += new EventHandler(btnExit_Click);

            // Form Settings
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ClientSize = new Size(600, 450);
            this.Controls.AddRange(new Control[] { 
                panel1, lblTitle, iconUser, txtUsername, panel2,
                iconLock, txtPassword, panel3,
                btnLogin, btnRegister, btnExit
            });
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private Panel panel1;
        private Panel panelLogo;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private IconButton btnExit;
        private Label lblTitle;
        private IconPictureBox iconUser;
        private IconPictureBox iconLock;
        private Panel panel2;
        private Panel panel3;
    }
}