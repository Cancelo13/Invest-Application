using FontAwesome.Sharp;
using System.Runtime.InteropServices;
namespace InvestApp.Forms
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            this.panelMenu = new Panel();
            this.panelLogo = new Panel();
            this.panelDesktop = new Panel();
            this.btnDashboard = new IconButton();
            this.btnInvestments = new IconButton();
            this.btnAnalytics = new IconButton();
            this.btnSettings = new IconButton();
            this.btnLogout = new IconButton();
            this.lblTitle = new Label();

            // Main Form
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Left Menu Panel
            this.panelMenu.Size = new Size(220, 700);
            this.panelMenu.Dock = DockStyle.Left;
            this.panelMenu.BackColor = Color.FromArgb(30, 30, 45);

            // Logo Panel
            this.panelLogo.Size = new Size(220, 140);
            this.panelLogo.Dock = DockStyle.Top;
            this.panelLogo.BackColor = Color.FromArgb(30, 30, 45);
            this.panelMenu.Controls.Add(panelLogo);

            // Dashboard Button
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.IconChar = IconChar.ChartLine;
            this.btnDashboard.FlatStyle = FlatStyle.Flat;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.Size = new Size(220, 60);
            this.btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnDashboard.ForeColor = Color.Gainsboro;
            this.btnDashboard.IconColor = Color.Gainsboro;
            this.btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnDashboard.Dock = DockStyle.Top;
            this.btnDashboard.Padding = new Padding(10, 0, 20, 0);

            // Investments Button
            this.btnInvestments.Text = "Investments";
            this.btnInvestments.IconChar = IconChar.MoneyBillTrendUp;
            this.btnInvestments.FlatStyle = FlatStyle.Flat;
            this.btnInvestments.FlatAppearance.BorderSize = 0;
            this.btnInvestments.Size = new Size(220, 60);
            this.btnInvestments.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnInvestments.ForeColor = Color.Gainsboro;
            this.btnInvestments.IconColor = Color.Gainsboro;
            this.btnInvestments.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnInvestments.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnInvestments.Dock = DockStyle.Top;
            this.btnInvestments.Padding = new Padding(10, 0, 20, 0);

            // Analytics Button
            this.btnAnalytics.Text = "Analytics";
            this.btnAnalytics.IconChar = IconChar.ChartPie;
            this.btnAnalytics.FlatStyle = FlatStyle.Flat;
            this.btnAnalytics.FlatAppearance.BorderSize = 0;
            this.btnAnalytics.Size = new Size(220, 60);
            this.btnAnalytics.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnAnalytics.ForeColor = Color.Gainsboro;
            this.btnAnalytics.IconColor = Color.Gainsboro;
            this.btnAnalytics.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnAnalytics.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnAnalytics.Dock = DockStyle.Top;
            this.btnAnalytics.Padding = new Padding(10, 0, 20, 0);

            // Settings Button
            this.btnSettings.Text = "Settings";
            this.btnSettings.IconChar = IconChar.Gear;
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Size = new Size(220, 60);
            this.btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnSettings.ForeColor = Color.Gainsboro;
            this.btnSettings.IconColor = Color.Gainsboro;
            this.btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnSettings.Dock = DockStyle.Top;
            this.btnSettings.Padding = new Padding(10, 0, 20, 0);

            // Logout Button
            this.btnLogout.Text = "Logout";
            this.btnLogout.IconChar = IconChar.RightFromBracket;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Size = new Size(220, 60);
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnLogout.ForeColor = Color.Gainsboro;
            this.btnLogout.IconColor = Color.Gainsboro;
            this.btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.Padding = new Padding(10, 0, 20, 0);

            // Desktop Panel
            this.panelDesktop.Size = new Size(980, 700);
            this.panelDesktop.Dock = DockStyle.Fill;
            this.panelDesktop.BackColor = Color.FromArgb(245, 245, 245);

            // Add controls to the menu panel
            this.panelMenu.Controls.AddRange(new Control[] {
                btnDashboard,
                btnInvestments,
                btnAnalytics,
                btnSettings,
                btnLogout
            });

            // Add panels to form
            this.Controls.AddRange(new Control[] {
                panelDesktop,
                panelMenu
            });
        }

        private Panel panelMenu;
        private Panel panelLogo;
        private Panel panelDesktop;
        private IconButton btnDashboard;
        private IconButton btnInvestments;
        private IconButton btnAnalytics;
        private IconButton btnSettings;
        private IconButton btnLogout;
        private Label lblTitle;
    }
}