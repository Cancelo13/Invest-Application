using FontAwesome.Sharp;
using Invest_Application;

namespace InvestApp.Forms
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            // Panels
            this.panelMenu = new Panel();
            this.panelAssetsSubmenu = new Panel();
            this.panelProfile = new Panel();
            this.panelTop = new Panel();
            this.panelDesktop = new Panel();

            // Profile
            this.iconProfile = new IconPictureBox();
            this.lblUserName = new Label();

            // Asset Buttons
            this.btnAssets = new IconButton();
            this.btnGold = new IconButton();
            this.btnCrypto = new IconButton();
            this.btnRealEstate = new IconButton();
            this.btnStock = new IconButton();

            // Zakat & Report
            this.btnZakat = new IconButton();
            this.btnReport = new IconButton();

            // ROI
            this.panelROI = new Panel();
            this.lblROI = new Label();
            this.iconROI = new IconPictureBox();
            this.lblROITitle = new Label();

            // Exit
            this.btnExit = new IconButton();

            // === Form Settings ===
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 30, 45);

            // === Left Menu Panel ===
            this.panelMenu.Size = new Size(300, this.Height);
            this.panelMenu.Dock = DockStyle.Left;
            this.panelMenu.BackColor = Color.FromArgb(30, 30, 45);

            // === Profile Panel ===
            this.panelProfile.Size = new Size(300, 120);
            this.panelProfile.Dock = DockStyle.Top;
            this.panelProfile.BackColor = Color.FromArgb(95, 77, 221);
            this.panelProfile.Cursor = Cursors.Hand;
            this.panelProfile.Click += (s, e) => { /* Placeholder for profile click */ };

            // Profile Icon
            this.iconProfile.IconChar = IconChar.UserCircle;
            this.iconProfile.IconSize = 60;
            this.iconProfile.IconColor = Color.White;
            this.iconProfile.Size = new Size(60, 60);
            this.iconProfile.Location = new Point(25, 30);
            this.iconProfile.BackColor = Color.Transparent;
            this.iconProfile.Click += (s, e) => { /* Placeholder for profile click */ };

            // Username Label
            this.lblUserName.Text = "Name";
            this.lblUserName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblUserName.ForeColor = Color.White;
            this.lblUserName.Location = new Point(100, 40);
            this.lblUserName.Size = new Size(180, 40);
            this.lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            this.lblUserName.Click += (s, e) => { /* Placeholder for profile click */ };

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
            this.panelAssetsSubmenu.BringToFront();


            ConfigureAssetButton(btnCrypto, "Crypto", IconChar.Bitcoin);
            ConfigureAssetButton(btnGold, "Gold", IconChar.Coins);
            ConfigureAssetButton(btnRealEstate, "RealEstate", IconChar.Building);
            ConfigureAssetButton(btnStock, "Stock", IconChar.ChartLine);

            btnCrypto.Location = new Point(0, 0);
            btnGold.Location = new Point(0, 50);
            btnRealEstate.Location = new Point(0, 100);
            btnStock.Location = new Point(0, 150);

            this.panelAssetsSubmenu.Controls.AddRange(new Control[] {
                btnCrypto, btnGold, btnRealEstate, btnStock
            });

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
            this.btnReport.Click += (s, e) => { /* Placeholder for report click */ };

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
            this.btnZakat.Click += (s, e) => { /* Placeholder for zakat click */ };

            // === Top Panel ===
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Height = 80;
            this.panelTop.BackColor = Color.FromArgb(30, 30, 45);

            // === ROI Panel (Top Right) ===
            this.panelROI.Size = new Size(220, 70);
            this.panelROI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.panelROI.BackColor = Color.FromArgb(95, 77, 221);
            this.panelROI.Location = new Point(this.Width - 420, 10);
            // ROI Icon
            this.iconROI.IconChar = IconChar.ChartLine;
            this.iconROI.IconSize = 32;
            this.iconROI.Size = new Size(32, 32);
            this.iconROI.Location = new Point(20, 20);

            // ROI Title
            this.lblROITitle.Text = "ROI";
            this.lblROITitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblROITitle.ForeColor = Color.White;
            this.lblROITitle.Location = new Point(60, 10);
            this.lblROITitle.Size = new Size(60, 25);

            // ROI Value
            this.lblROI.Text = "+12.5%";
            this.lblROI.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblROI.ForeColor = Color.LimeGreen;
            this.lblROI.Location = new Point(60, 35);
            this.lblROI.Size = new Size(120, 30);

            // === Exit Button ===
            this.btnExit.IconChar = IconChar.Times;
            this.btnExit.IconColor = Color.White;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Size = new Size(32, 32);
            this.btnExit.BackColor = Color.Transparent;
            this.btnExit.Location = new Point(this.panelTop.Width - 42, 8); // 8px from top, 10px from right
            this.btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.Click += btnExit_Click;
            this.panelTop.Controls.Add(this.btnExit);

            // === Desktop Panel ===
            this.panelDesktop.BackColor = Color.FromArgb(245, 245, 245);
            this.panelDesktop.Dock = DockStyle.Fill;
            this.panelDesktop.Padding = new Padding(20);

            // === Add controls ===
            this.panelProfile.Controls.AddRange(new Control[] { iconProfile, lblUserName });
            this.panelMenu.Controls.Clear();
            this.panelMenu.Controls.AddRange(new Control[] {
                btnAssets,
                panelProfile,
                btnZakat,
                btnReport
            });

            this.panelROI.Controls.AddRange(new Control[] { iconROI, lblROITitle, lblROI });
            this.panelTop.Controls.AddRange(new Control[] { panelROI, btnExit });
            this.Controls.Add(panelAssetsSubmenu);
            this.Controls.AddRange(new Control[] { panelDesktop, panelMenu, panelTop });
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
            btn.Dock = DockStyle.None; // Remove Dock
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(40, 0, 0, 0);
            btn.Click += (s, e) => { /* Placeholder for asset click */ };
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
    }
}