using FontAwesome.Sharp;
using Invest_Application;

namespace InvestApp.Forms
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            // Initialize all components
            this.panelMenu = new Panel();
            this.panelAssetsSubmenu = new Panel();
            this.panelProfile = new Panel();
            this.panelTop = new Panel();
            this.panelDesktop = new Panel();
            this.iconProfile = new IconPictureBox();
            this.lblUserName = new Label();
            this.btnAssets = new IconButton();
            this.btnGold = new IconButton();
            this.btnCrypto = new IconButton();
            this.btnRealEstate = new IconButton();
            this.btnStock = new IconButton();
            this.btnZakat = new IconButton();
            this.btnReport = new IconButton();
            this.panelROI = new Panel();
            this.lblROI = new Label();
            this.iconROI = new IconPictureBox();
            this.lblROITitle = new Label();
            this.btnExit = new IconButton();

            // === Form Settings ===
            this.WindowState = FormWindowState.Normal;  // Start in normal state
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1280, 720);    // Minimum size
            this.Size = new Size(1600, 900);
            this.Padding = new Padding(2);  // Add padding for resize area

            // === Top Panel ===
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 80;
            this.panelTop.BackColor = Color.FromArgb(30, 30, 45);

            // === Profile Panel (in top panel) ===
            this.panelProfile.Size = new Size(300, 80);
            this.panelProfile.Dock = DockStyle.Left;
            this.panelProfile.BackColor = Color.FromArgb(95, 77, 221);
            this.panelProfile.Cursor = Cursors.Hand;

            // Profile Icon
            this.iconProfile.IconChar = IconChar.UserCircle;
            this.iconProfile.IconSize = 40;
            this.iconProfile.IconColor = Color.White;
            this.iconProfile.Size = new Size(40, 40);
            this.iconProfile.Location = new Point(20, 20);
            this.iconProfile.BackColor = Color.Transparent;

            this.panelProfile.Click += panelProfile_Click;
            this.iconProfile.Click += panelProfile_Click;
            this.lblUserName.Click += panelProfile_Click;

            // Username Label
            this.lblUserName.Text = "Name";
            this.lblUserName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblUserName.ForeColor = Color.White;
            this.lblUserName.Location = new Point(70, 25);
            this.lblUserName.Size = new Size(200, 30);
            this.lblUserName.TextAlign = ContentAlignment.MiddleLeft;

            // === Left Menu Panel ===
            this.panelMenu.Size = new Size(300, this.Height);
            this.panelMenu.Dock = DockStyle.Left;
            this.panelMenu.BackColor = Color.FromArgb(30, 30, 45);
            this.panelMenu.Padding = new Padding(0, 0, 0, 0);

            // === Asset Button ===
            this.btnAssets.Text = "Assets";
            this.btnAssets.IconChar = IconChar.ChevronDown;
            this.btnAssets.FlatStyle = FlatStyle.Flat;
            this.btnAssets.FlatAppearance.BorderSize = 0;
            this.btnAssets.Size = new Size(300, 60);
            this.btnAssets.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnAssets.ForeColor = Color.White;
            this.btnAssets.IconColor = Color.White;
            this.btnAssets.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.btnAssets.Dock = DockStyle.Top;
            this.btnAssets.TextAlign = ContentAlignment.MiddleLeft;
            this.btnAssets.Padding = new Padding(20, 0, 0, 0);
            this.btnAssets.Click += btnAssets_Click;

            // === Assets Submenu ===
            this.panelAssetsSubmenu.BackColor = Color.FromArgb(40, 40, 60);
            this.panelAssetsSubmenu.Size = new Size(300, 200);
            this.panelAssetsSubmenu.Visible = false;

            ConfigureAssetButton(btnCrypto, "Crypto", IconChar.Bitcoin);
            ConfigureAssetButton(btnGold, "Gold", IconChar.Coins);
            ConfigureAssetButton(btnRealEstate, "RealEstate", IconChar.Building);
            ConfigureAssetButton(btnStock, "Stock", IconChar.ChartLine);

            btnCrypto.Location = new Point(0, 0);
            btnGold.Location = new Point(0, 50);
            btnRealEstate.Location = new Point(0, 100);
            btnStock.Location = new Point(0, 150);

            // === Report Button ===
            this.btnReport.Text = "Report";
            this.btnReport.IconChar = IconChar.FileAlt;
            this.btnReport.FlatStyle = FlatStyle.Flat;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.Size = new Size(300, 50);
            this.btnReport.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnReport.ForeColor = Color.Gold;
            this.btnReport.IconColor = Color.Gold;
            this.btnReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnReport.Dock = DockStyle.Bottom;
            this.btnReport.TextAlign = ContentAlignment.MiddleLeft;
            this.btnReport.Padding = new Padding(20, 0, 0, 0);
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);

            // === Zakat Button ===
            this.btnZakat.Text = "Zakat";
            this.btnZakat.IconChar = IconChar.HandHoldingUsd;
            this.btnZakat.FlatStyle = FlatStyle.Flat;
            this.btnZakat.FlatAppearance.BorderSize = 0;
            this.btnZakat.Size = new Size(300, 50);
            this.btnZakat.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnZakat.ForeColor = Color.Gold;
            this.btnZakat.IconColor = Color.Gold;
            this.btnZakat.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnZakat.Dock = DockStyle.Bottom;
            this.btnZakat.TextAlign = ContentAlignment.MiddleLeft;
            this.btnZakat.Padding = new Padding(20, 0, 0, 0);
            this.btnZakat.Click += new System.EventHandler(this.btnZakat_Click);

            // === ROI Panel ===
            this.panelROI = new Panel
            {
                Size = new Size(280, 70),
                BackColor = Color.FromArgb(95, 77, 221),
                Location = new Point(350, 5),  // Changed location to be after profile panel
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // ROI Icon
            this.iconROI = new IconPictureBox();
            this.iconROI.IconChar = IconChar.ChartLine;
            this.iconROI.IconSize = 32;
            this.iconROI.Size = new Size(32, 32);
            this.iconROI.Location = new Point(20, 20);
            this.iconROI.IconColor = Color.White;
            this.iconROI.BackColor = Color.Transparent;

            // ROI Title
            this.lblROITitle = new Label();
            this.lblROITitle.Text = "ROI";
            this.lblROITitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblROITitle.ForeColor = Color.White;
            this.lblROITitle.Location = new Point(60, 10);
            this.lblROITitle.Size = new Size(60, 25);

            // ROI Value
            this.lblROI = new Label();
            this.lblROI.Text = "+0.00%";
            this.lblROI.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblROI.ForeColor = Color.White;
            this.lblROI.Location = new Point(60, 35);
            this.lblROI.Size = new Size(200, 25);
            this.lblROI.TextAlign = ContentAlignment.MiddleLeft;

            // === Exit Button ===
            this.btnExit.IconChar = IconChar.Times;
            this.btnExit.IconColor = Color.White;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.BackColor = Color.Transparent;
            this.btnExit.Size = new Size(45, 45);      // Match maximize button size
            this.btnExit.Location = new Point(this.panelTop.Width - 50, 2);
            this.btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.Click += btnExit_Click;

            // === Maximize/Restore Button ===
            this.FormBorderStyle = FormBorderStyle.None;  // Required for custom window chrome
            this.MaximizeBox = true;

            this.btnMaximize = new IconButton();
            this.btnMaximize.IconChar = IconChar.Square;
            this.btnMaximize.IconColor = Color.White;
            this.btnMaximize.FlatStyle = FlatStyle.Flat;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Size = new Size(45, 45);  // Increased size
            this.btnMaximize.BackColor = Color.Transparent;
            this.btnMaximize.Location = new Point(this.panelTop.Width - 97, 2);  // Adjusted position
            this.btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnMaximize.Cursor = Cursors.Hand;
            this.btnMaximize.Click += btnMaximize_Click;

            // === Logout Button ===
            this.btnLogout = new IconButton();
            this.btnLogout.Text = "Logout";
            this.btnLogout.IconChar = IconChar.SignOutAlt;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Size = new Size(150, 50);
            this.btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.IconColor = Color.White;
            this.btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new Padding(20, 0, 0, 0);
            this.btnLogout.BackColor = Color.FromArgb(95, 77, 221);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += btnLogout_Click;

            // === Desktop Panel ===
            this.panelDesktop.BackColor = Color.FromArgb(245, 245, 245);
            this.panelDesktop.Dock = DockStyle.Fill;

            // === Add Controls in Correct Order ===
            this.panelProfile.Controls.AddRange(new Control[] { iconProfile, lblUserName });
            this.panelAssetsSubmenu.Controls.AddRange(new Control[] { btnCrypto, btnGold, btnRealEstate, btnStock });

            this.panelROI.Controls.Clear();  // Clear any existing controls
            this.panelROI.Controls.AddRange(new Control[] {
                this.iconROI,
                this.lblROITitle,
                this.lblROI
            });
            this.panelTop.Controls.Clear();
            this.panelTop.Controls.AddRange(new Control[] {
                panelProfile,  // Profile panel first (left side)
                panelROI,     // ROI panel second
                btnMaximize,  // Maximize button third
                btnExit      // Exit button last
            });
            this.panelROI.BringToFront();

            this.panelMenu.Controls.AddRange(new Control[] {
                btnAssets,
                btnZakat,
                btnReport,
                btnLogout
            });

            this.Controls.AddRange(new Control[] {
                panelDesktop,
                panelMenu,
                panelTop,
                panelAssetsSubmenu
            });
        }

        private void ConfigureAssetButton(IconButton btn, string text, IconChar icon)
        {
            btn.Text = text;
            btn.IconChar = icon;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(300, 50);
            btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btn.ForeColor = Color.White;
            btn.IconColor = Color.White;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Dock = DockStyle.None;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(40, 0, 0, 0);
            btn.Click += AssetButton_Click;  // Replace the existing placeholder click handler

        }

        private Panel panelMenu;
        private Panel panelAssetsSubmenu;
        private Panel panelProfile;
        private Panel panelTop;
        private Panel panelDesktop;
        private Label lblUserName;
        private IconPictureBox iconProfile;
        private IconButton btnAssets;
        private IconButton btnGold;
        private IconButton btnCrypto;
        private IconButton btnRealEstate;
        private IconButton btnStock;
        private Panel panelROI;
        private Label lblROI;
        private IconPictureBox iconROI;
        private Label lblROITitle;
        private IconButton btnExit;
        private IconButton btnZakat;
        private IconButton btnReport;
        private IconButton btnLogout;
        private IconButton btnMaximize;

    }
}