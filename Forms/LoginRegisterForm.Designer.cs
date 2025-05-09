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
            this.panel1.Size = new Size(300, 600);

            // Add Logo Icon to Left Panel
            IconPictureBox logoIcon = new IconPictureBox();
            logoIcon.IconChar = IconChar.ChartLine;
            logoIcon.IconSize = 100;
            logoIcon.IconColor = Color.White;
            logoIcon.Size = new Size(100, 100);
            logoIcon.Location = new Point(100, 120);
            this.panel1.Controls.Add(logoIcon);

            // Add App Name to Left Panel
            Label lblAppName = new Label();
            lblAppName.Text = "InvestApp";
            lblAppName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Size = new Size(300, 50);
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            lblAppName.Location = new Point(0, 230);
            this.panel1.Controls.Add(lblAppName);

            int rightSideX = 350;
            int controlWidth = 400;

            // Title
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblTitle.Location = new Point(rightSideX, 40);
            this.lblTitle.Size = new Size(400, 50);

            // Input Fields Styling
            Color inputBackColor = Color.FromArgb(250, 250, 250);
            Color placeholderColor = Color.FromArgb(150, 150, 150);

            // Name TextBox and Line
            this.txtName.Location = new Point(rightSideX, 120);
            this.txtName.Size = new Size(controlWidth, 35);
            this.txtName.BackColor = inputBackColor;
            this.txtName.PlaceholderText = "Full Name";
            this.txtName.BorderStyle = BorderStyle.None;
            this.txtName.Font = new Font("Segoe UI", 12F);
            this.txtName.Padding = new Padding(5, 5, 5, 5);

            this.pnlName.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlName.Location = new Point(rightSideX, 150);
            this.pnlName.Size = new Size(controlWidth, 2);

            // Username TextBox and Line
            this.txtUsername.Location = new Point(rightSideX, 180);
            this.txtUsername.Size = new Size(controlWidth, 35);
            this.txtUsername.BackColor = inputBackColor;
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Segoe UI", 12F);
            this.txtUsername.Padding = new Padding(5, 5, 5, 5);
            this.pnlUsername.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlUsername.Location = new Point(rightSideX, 210);
            this.pnlUsername.Size = new Size(controlWidth, 2);

            // Password TextBox and Line
            this.txtPassword.Location = new Point(rightSideX, 240);
            this.txtPassword.Size = new Size(controlWidth, 35);
            this.txtPassword.BackColor = inputBackColor;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Segoe UI", 12F);
            this.txtPassword.Padding = new Padding(5, 5, 5, 5);

            this.pnlPassword.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlPassword.Location = new Point(rightSideX, 270);
            this.pnlPassword.Size = new Size(controlWidth, 2);

            // Confirm Password TextBox and Line
            this.txtConfirmPassword.Location = new Point(rightSideX, 300);
            this.txtConfirmPassword.Size = new Size(controlWidth, 35);
            this.txtConfirmPassword.BackColor = inputBackColor;
            this.txtConfirmPassword.PlaceholderText = "Confirm Password";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.BorderStyle = BorderStyle.None;
            this.txtConfirmPassword.Font = new Font("Segoe UI", 12F);
            this.txtConfirmPassword.Padding = new Padding(5, 5, 5, 5);

            this.pnlConfirmPassword.BackColor = Color.FromArgb(95, 77, 221);
            this.pnlConfirmPassword.Location = new Point(rightSideX, 330);
            this.pnlConfirmPassword.Size = new Size(controlWidth, 2);

            // Submit Button
            this.btnSubmit.Size = new Size(controlWidth, 45);
            this.btnSubmit.Location = new Point(rightSideX, 370);
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.BackColor = Color.FromArgb(95, 77, 221);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnSubmit.Cursor = Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Click += new EventHandler(btnSubmit_Click);

            // Switch Mode Button
            this.btnSwitchMode.Size = new Size(controlWidth, 35);
            this.btnSwitchMode.Location = new Point(rightSideX, 430);
            this.btnSwitchMode.FlatStyle = FlatStyle.Flat;
            this.btnSwitchMode.FlatAppearance.BorderSize = 0;
            this.btnSwitchMode.BackColor = Color.Transparent;
            this.btnSwitchMode.ForeColor = Color.FromArgb(95, 77, 221);
            this.btnSwitchMode.Font = new Font("Segoe UI", 10F);
            this.btnSwitchMode.Cursor = Cursors.Hand;
            this.btnSwitchMode.Click += new EventHandler(btnSwitchMode_Click);

            // Exit Button
            this.btnExit.IconChar = IconChar.Times;
            this.btnExit.IconColor = Color.FromArgb(95, 77, 221);
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Size = new Size(32, 32);
            this.btnExit.Location = new Point(758, 12);
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.Click += new EventHandler(btnExit_Click);

            // Form Settings
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add Controls
            this.Controls.AddRange(new Control[] {
                panel1, lblTitle,
                txtName, pnlName,
                txtUsername, pnlUsername,
                txtPassword, pnlPassword,
                txtConfirmPassword, pnlConfirmPassword,
                btnSubmit, btnSwitchMode, btnExit
            });
            // Enable form dragging
            this.MouseDown += new MouseEventHandler(Form_MouseDown);

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
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