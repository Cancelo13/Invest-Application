using System.Runtime.InteropServices;
using FontAwesome.Sharp; 
namespace InvestApp.Forms
{
    partial class LoginRegisterForm
    {
        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.txtName = new TextBox();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.btnSubmit = new Button();
            this.btnSwitchMode = new Button();
            this.btnExit = new IconButton();
            this.lblTitle = new Label();
            this.pnlName = new Panel();
            this.pnlUsername = new Panel();
            this.pnlPassword = new Panel();
            this.pnlConfirmPassword = new Panel();

            // Left Panel
            this.panel1.BackColor = Color.FromArgb(95, 77, 221);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Size = new Size(200, 500);

            // Title
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblTitle.Location = new Point(250, 40);
            this.lblTitle.Size = new Size(300, 50);

            // Name TextBox and Line
            this.txtName.Location = new Point(250, 120);
            this.txtName.Size = new Size(300, 30);
            this.txtName.PlaceholderText = "Full Name";
            this.txtName.BorderStyle = BorderStyle.None;
            this.txtName.Font = new Font("Segoe UI", 12F);

            this.pnlName.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlName.Location = new Point(250, 150);
            this.pnlName.Size = new Size(300, 2);

            // Username TextBox and Line
            this.txtUsername.Location = new Point(250, 180);
            this.txtUsername.Size = new Size(300, 30);
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Segoe UI", 12F);

            this.pnlUsername.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlUsername.Location = new Point(250, 210);
            this.pnlUsername.Size = new Size(300, 2);

            // Password TextBox and Line
            this.txtPassword.Location = new Point(250, 240);
            this.txtPassword.Size = new Size(300, 30);
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Segoe UI", 12F);

            this.pnlPassword.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlPassword.Location = new Point(250, 270);
            this.pnlPassword.Size = new Size(300, 2);

            // Confirm Password TextBox and Line
            this.txtConfirmPassword.Location = new Point(250, 300);
            this.txtConfirmPassword.Size = new Size(300, 30);
            this.txtConfirmPassword.PlaceholderText = "Confirm Password";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.BorderStyle = BorderStyle.None;
            this.txtConfirmPassword.Font = new Font("Segoe UI", 12F);

            this.pnlConfirmPassword.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlConfirmPassword.Location = new Point(250, 330);
            this.pnlConfirmPassword.Size = new Size(300, 2);

            // Submit Button
            this.btnSubmit.Location = new Point(250, 370);
            this.btnSubmit.Size = new Size(300, 45);
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.BackColor = Color.FromArgb(95, 77, 221);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnSubmit.Cursor = Cursors.Hand;
            this.btnSubmit.Click += new EventHandler(btnSubmit_Click);

            // Switch Mode Button
            this.btnSwitchMode.Location = new Point(250, 430);
            this.btnSwitchMode.Size = new Size(300, 35);
            this.btnSwitchMode.FlatStyle = FlatStyle.Flat;
            this.btnSwitchMode.FlatAppearance.BorderSize = 0;
            this.btnSwitchMode.BackColor = Color.FromArgb(245, 245, 245);
            this.btnSwitchMode.ForeColor = Color.FromArgb(95, 77, 221);
            this.btnSwitchMode.Font = new Font("Segoe UI", 9F);
            this.btnSwitchMode.Cursor = Cursors.Hand;
            this.btnSwitchMode.Click += new EventHandler(btnSwitchMode_Click);

            // Exit Button
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
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 500);

            // Add Controls
            this.Controls.AddRange(new Control[] {
                panel1, lblTitle,
                txtName, pnlName,
                txtUsername, pnlUsername,
                txtPassword, pnlPassword,
                txtConfirmPassword, pnlConfirmPassword,
                btnSubmit, btnSwitchMode, btnExit
            });
        }

        private Panel panel1;
        private TextBox txtName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnSubmit;
        private Button btnSwitchMode;
        private IconButton btnExit;
        private Label lblTitle;
        private Panel pnlName;
        private Panel pnlUsername;
        private Panel pnlPassword;
        private Panel pnlConfirmPassword;
    }
}