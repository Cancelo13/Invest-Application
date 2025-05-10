using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using Invest_Application;

namespace InvestApp.Forms
{
    public partial class MainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private User currentUser;
        private IconButton btnAdd;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int HTLEFT = 0x0A;
        private const int HTRIGHT = 0x0B;
        private const int HTTOP = 0x0C;
        private const int HTTOPLEFT = 0x0D;
        private const int HTTOPRIGHT = 0x0E;
        private const int HTBOTTOM = 0x0F;
        private const int HTBOTTOMLEFT = 0x10;
        private const int HTBOTTOMRIGHT = 0x11;
        private bool isDragging = false;
        private const int RESIZE_AREA = 10;

        public MainForm(User user)
        {
            InitializeComponent();
            leftBorderBtn = new Panel
            {
                Size = new Size(7, 60),
                Visible = false
            };
            panelMenu.Controls.Add(leftBorderBtn);
            this.panelROI.BringToFront();

            // ...existing code...
            currentUser = user;
            this.MouseDown += Form_MouseDown;
            this.panelTop.MouseDown += Form_MouseDown;
            this.MouseUp += Form_MouseUp;
            this.panelTop.MouseUp += Form_MouseUp;
            LoadUserInfo();
            InitializeAddButton();
            this.Load += (s, e) => ShowUserProfile();
            this.Resize += (s, e) => UpdateAddButtonPosition();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && WindowState == FormWindowState.Normal)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.X <= RESIZE_AREA && pos.Y <= RESIZE_AREA)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (pos.X >= ClientSize.Width - RESIZE_AREA && pos.Y <= RESIZE_AREA)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (pos.X <= RESIZE_AREA && pos.Y >= ClientSize.Height - RESIZE_AREA)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (pos.X >= ClientSize.Width - RESIZE_AREA && pos.Y >= ClientSize.Height - RESIZE_AREA)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (pos.X <= RESIZE_AREA)
                    m.Result = (IntPtr)HTLEFT;
                else if (pos.X >= ClientSize.Width - RESIZE_AREA)
                    m.Result = (IntPtr)HTRIGHT;
                else if (pos.Y <= RESIZE_AREA)
                    m.Result = (IntPtr)HTTOP;
                else if (pos.Y >= ClientSize.Height - RESIZE_AREA)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void panelProfile_Click(object sender, EventArgs e)
        {
            // Clear any active button highlighting
            DisableButton();

            // Hide the ADD button
            if (btnAdd != null)
            {
                btnAdd.Visible = false;
            }

            // Show profile content
            ShowUserProfile();
        }

        private void LoadUserInfo()
        {
            lblUserName.Text = currentUser.Name;
            // Calculate total ROI
            decimal totalROI = InvestmentAnalyzer.GetTotalROI(currentUser.Username); // Replace with actual calculation
            UpdateROIDisplay(totalROI);
        }

        private void UpdateROIDisplay(decimal roi)
        {
            lblROI.Text = $"{roi:P2}";
            Color roiColor = roi >= 0 ? Color.FromArgb(39, 174, 96) : Color.FromArgb(231, 76, 60);
            lblROI.ForeColor = Color.White;
            iconROI.IconColor = roiColor;
            panelROI.BorderStyle = BorderStyle.FixedSingle;
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void InitializeAddButton()
        {
            btnAdd = new IconButton
            {
                Text = "ADD",
                IconChar = IconChar.Plus,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 50),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                IconColor = Color.White,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = Color.FromArgb(95, 77, 221),
                Cursor = Cursors.Hand,
                Visible = false,
                Padding = new Padding(10, 0, 0, 0)
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelDesktop.Controls.Add(btnAdd);
            btnAdd.Click += btnAdd_Click;  // Add this line

            UpdateAddButtonPosition();
        }

        private Panel CreateAssetInfoPanel(Asset asset)
        {
            Panel assetPanel = new Panel
            {
                Width = panelDesktop.Width - 40,
                Height = 100,
                Padding = new Padding(20),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Asset Name
            Label lblName = new Label
            {
                Text = asset.Name,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 10),
                AutoSize = true
            };

            // Quantity
            Label lblQuantity = new Label
            {
                Text = $"Quantity: {asset.Quantity}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 40),
                AutoSize = true
            };

            // Purchase Info
            Label lblPurchase = new Label
            {
                Text = $"Purchase: ${asset.TotalPurchasePrice():N2} on {asset.PurchaseDate:d}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(200, 40),
                AutoSize = true
            };

            // Current Value
            decimal currentValue = asset.CurrentPrice();
            Label lblCurrentValue = new Label
            {
                Text = $"Current Value: ${currentValue:N2}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(500, 40),
                AutoSize = true
            };

            // ROI
            decimal roi = asset.CalculateROI();
            Label lblROI = new Label
            {
                Text = $"ROI: {roi:P2}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = roi >= 0 ? Color.FromArgb(39, 174, 96) : Color.FromArgb(231, 76, 60),
                Location = new Point(700, 40),
                AutoSize = true
            };

            // Edit Button
            IconButton btnEdit = new IconButton
            {
                IconChar = IconChar.Edit,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(40, 40),
                IconColor = Color.FromArgb(255, 193, 7), // Yellow
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Location = new Point(assetPanel.Width - 100, 30),
                Anchor = AnchorStyles.Right
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += (s, e) =>
            {
                string assetType = btnAdd.Tag?.ToString() ?? "";
                using (var form = new AssetForm(assetType, currentUser.Username, asset))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        // Refresh the list without changing button state
                        RefreshAssetList(assetType);

                        // Update total ROI display
                        decimal totalROI = InvestmentAnalyzer.GetTotalROI(currentUser.Username);
                        UpdateROIDisplay(totalROI);
                    }
                }
            };

            // Delete Button
            IconButton btnDelete = new IconButton
            {
                IconChar = IconChar.TrashAlt,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(40, 40),
                IconColor = Color.FromArgb(231, 76, 60), // Red
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Location = new Point(assetPanel.Width - 50, 30),
                Anchor = AnchorStyles.Right
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show("Are you sure you want to delete this asset?", "Delete Asset",
        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        // Get current asset type for refresh
                        string assetType = btnAdd.Tag?.ToString() ?? "";

                        // Delete the asset using DatabaseOrganizer
                        DatabaseOrganizer.DeleteUserAsset(currentUser.Username, asset);

                        // Clear and refresh only the desktop panel
                        panelDesktop.Controls.Clear();

                        // Create scrollable panel
                        Panel scrollPanel = new Panel
                        {
                            AutoScroll = true,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(20)
                        };

                        // Get updated assets list
                        List<Asset> assets = new List<Asset>();
                        switch (assetType)
                        {
                            case "Gold":
                                assets = DatabaseOrganizer.GetAllUserGold(currentUser.Username).ToList<Asset>();
                                break;
                            case "Crypto":
                                assets = DatabaseOrganizer.GetAllUserCrypto(currentUser.Username).ToList<Asset>();
                                break;
                            case "RealEstate":
                                assets = DatabaseOrganizer.GetAllUserRealEstate(currentUser.Username).ToList<Asset>();
                                break;
                            case "Stock":
                                assets = DatabaseOrganizer.GetAllUserStock(currentUser.Username).ToList<Asset>();
                                break;
                        }

                        // Rebuild asset panels
                        int yOffset = 0;
                        foreach (var updatedAsset in assets)
                        {
                            Panel assetPanel = CreateAssetInfoPanel(updatedAsset);
                            assetPanel.Location = new Point(0, yOffset);
                            scrollPanel.Controls.Add(assetPanel);
                            yOffset += assetPanel.Height + 10;
                        }

                        // Add the scroll panel to desktop
                        panelDesktop.Controls.Add(scrollPanel);

                        // Keep ADD button visible and on top
                        if (btnAdd != null)
                        {
                            btnAdd.Tag = assetType;
                            btnAdd.Visible = true;
                            panelDesktop.Controls.Add(btnAdd);
                            UpdateAddButtonPosition();
                            btnAdd.BringToFront();
                        }

                        // Update total ROI display
                        decimal totalROI = InvestmentAnalyzer.GetTotalROI(currentUser.Username);
                        UpdateROIDisplay(totalROI);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting asset: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };


            // Horizontal Line
            Panel linePanel = new Panel
            {
                Height = 1,
                BackColor = Color.FromArgb(200, 200, 200),
                Dock = DockStyle.Bottom
            };

            assetPanel.Controls.AddRange(new Control[] {
                lblName, lblQuantity, lblPurchase,
                lblCurrentValue, lblROI, linePanel,
                btnEdit, btnDelete
            });

            return assetPanel;
        }

        private void btnZakat_Click(object sender, EventArgs e)
        {
            // Clear desktop panel
            panelDesktop.Controls.Clear();

            // Hide ADD button if it exists
            if (btnAdd != null)
            {
                btnAdd.Visible = false;
            }

            // Calculate Zakat
            var calculator = new ZakatCalculator();
            decimal zakatAmount = calculator.CalculateZakat(currentUser.Username);

            // Create Zakat display label
            Label lblZakat = new Label
            {
                Text = $"Your Zakat is:\n${zakatAmount:N2}",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(95, 77, 221),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Center the label in the panel
            lblZakat.Location = new Point(
                (panelDesktop.Width - lblZakat.PreferredWidth) / 2,
                (panelDesktop.Height - lblZakat.PreferredHeight) / 2
            );

            // Add label to desktop panel
            panelDesktop.Controls.Add(lblZakat);

            // Activate button styling
            ActivateButton(sender, Color.FromArgb(95, 77, 221));
        }
        private void UpdateAddButtonPosition()
        {
            if (btnAdd != null)
            {
                // Position the button at bottom right with proper margins
                btnAdd.Location = new Point(
                    panelDesktop.ClientSize.Width - btnAdd.Width - 30,
                    panelDesktop.ClientSize.Height - btnAdd.Height - 30
                );

                // Ensure the button is visible and on top
                btnAdd.Visible = true;
                btnAdd.BringToFront();

                // Set proper anchor to maintain position when form resizes
                btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string assetType = btnAdd.Tag?.ToString() ?? "";
            using (var form = new AssetForm(assetType, currentUser.Username))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    // Keep track of the current button
                    IconButton currentAssetBtn = currentBtn;

                    // Refresh the asset list without resetting button state
                    RefreshAssetList(assetType);

                    // Reactivate the button with the same styling
                    if (currentAssetBtn != null)
                    {
                        ActivateButton(currentAssetBtn, Color.FromArgb(95, 77, 221));
                    }
                }
            }
        }
        private void RefreshAssetList(string assetType)
        {
            // Clear desktop panel
            panelDesktop.Controls.Clear();

            // Create scrollable panel
            Panel scrollPanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            // Get assets based on type
            List<Asset> assets = new List<Asset>();
            switch (assetType)
            {
                case "Gold":
                    assets = DatabaseOrganizer.GetAllUserGold(currentUser.Username).ToList<Asset>();
                    break;
                case "Crypto":
                    assets = DatabaseOrganizer.GetAllUserCrypto(currentUser.Username).ToList<Asset>();
                    break;
                case "RealEstate":
                    assets = DatabaseOrganizer.GetAllUserRealEstate(currentUser.Username).ToList<Asset>();
                    break;
                case "Stock":
                    assets = DatabaseOrganizer.GetAllUserStock(currentUser.Username).ToList<Asset>();
                    break;
            }

            // Add asset panels
            int yOffset = 0;
            foreach (var asset in assets)
            {
                Panel assetPanel = CreateAssetInfoPanel(asset);
                assetPanel.Location = new Point(0, yOffset);
                scrollPanel.Controls.Add(assetPanel);
                yOffset += assetPanel.Height + 10;
            }

            // Add the scroll panel to desktop
            panelDesktop.Controls.Add(scrollPanel);

            // Ensure ADD button stays visible
            if (btnAdd != null)
            {
                btnAdd.Tag = assetType;
                btnAdd.Visible = true;
                panelDesktop.Controls.Add(btnAdd);
                UpdateAddButtonPosition();
                btnAdd.BringToFront();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Clear desktop panel
            panelDesktop.Controls.Clear();
            if (btnAdd != null) btnAdd.Visible = false;

            if (DatabaseOrganizer.GetUserAssetCount(currentUser.Username) == 0)
            {
                // Create "No Assets" label
                Label lblNoAssets = new Label
                {
                    Text = "No assets available to generate report",
                    Font = new Font("Segoe UI", 24, FontStyle.Bold),
                    ForeColor = Color.FromArgb(95, 77, 221),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lblNoAssets.Location = new Point(
                    (panelDesktop.Width - lblNoAssets.PreferredWidth) / 2,
                    (panelDesktop.Height - lblNoAssets.PreferredHeight) / 2
                );

                panelDesktop.Controls.Add(lblNoAssets);
                ActivateButton(sender, Color.FromArgb(95, 77, 221));
                return;
            }

            // Generate reports
            ReportGenerator.GenerateExcelReport(currentUser.Username);
            ReportGenerator.GenerateTextReport(currentUser.Username);
            ReportGenerator.GeneratePdfReport(currentUser.Username);

            // Create main container panel
            Panel mainContainer = new Panel
            {
                Width = panelDesktop.Width - 60,
                Height = panelDesktop.Height - 60,
                Location = new Point(30, 30),
                BackColor = Color.White
            };

            // Create buttons panel at the top
            Panel buttonsPanel = new Panel
            {
                Width = mainContainer.Width,
                Height = 80,
                Dock = DockStyle.Top,
                BackColor = Color.Transparent
            };

            // Create report content panel
            Panel reportPanel = new Panel
            {
                Width = mainContainer.Width,
                Height = mainContainer.Height - buttonsPanel.Height - 20,
                Location = new Point(0, buttonsPanel.Height + 10),
                BackColor = Color.White,
                AutoScroll = true
            };

            // Create Excel button
            IconButton btnExcel = new IconButton
            {
                Text = "Save as Excel",
                IconChar = IconChar.FileExcel,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 50),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 128, 71),
                IconColor = Color.FromArgb(25, 128, 71),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnExcel.FlatAppearance.BorderSize = 2;
            btnExcel.FlatAppearance.BorderColor = Color.FromArgb(25, 128, 71);
            btnExcel.Click += (s, e) =>
            {
                using (var fbd = new FolderBrowserDialog())
                    if (fbd.ShowDialog() == DialogResult.OK)
                        try
                        {
                            ReportGenerator.SaveExcelReport(currentUser.Username, fbd.SelectedPath);
                            MessageBox.Show("Excel report saved successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving Excel report: {ex.Message}", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            };

            // Create PDF button
            IconButton btnPDF = new IconButton
            {
                Text = "Save as PDF",
                IconChar = IconChar.FilePdf,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 50),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 33, 39),
                IconColor = Color.FromArgb(200, 33, 39),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnPDF.FlatAppearance.BorderSize = 2;
            btnPDF.FlatAppearance.BorderColor = Color.FromArgb(200, 33, 39);
            btnPDF.Click += (s, e) =>
            {
                using (var fbd = new FolderBrowserDialog())
                    if (fbd.ShowDialog() == DialogResult.OK)
                        try
                        {
                            ReportGenerator.SavePdfReport(currentUser.Username, fbd.SelectedPath);
                            MessageBox.Show("PDF report saved successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving PDF report: {ex.Message}", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            };

            IconButton btnGenerate = new IconButton
            {
                Text = "Generate New",
                IconChar = IconChar.Sync,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 50),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(95, 77, 221),
                IconColor = Color.FromArgb(95, 77, 221),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnGenerate.FlatAppearance.BorderSize = 2;
            btnGenerate.FlatAppearance.BorderColor = Color.FromArgb(95, 77, 221);

            int buttonSpacing = 10;
            int totalWidth = btnExcel.Width * 3 + buttonSpacing * 2;
            int startX = (buttonsPanel.Width - totalWidth) / 2;
            // Position buttons
            btnExcel.Location = new Point(startX, 15);
            btnPDF.Location = new Point(startX + btnExcel.Width + buttonSpacing, 15);
            btnGenerate.Location = new Point(startX + (btnExcel.Width + buttonSpacing) * 2, 15);


            // Create report text display
            RichTextBox reportText = new RichTextBox
            {
                Width = reportPanel.Width - 40,
                Height = reportPanel.Height - 40,
                Location = new Point(20, 20),
                Font = new Font("Consolas", 12),
                BackColor = Color.White,
                ReadOnly = true,
                BorderStyle = BorderStyle.None
            };

            // Load and display report content
            try
            {
                string reportContent = File.ReadAllText(AppPaths.GetTextSaveFile());
                reportText.Text = reportContent;
            }
            catch (Exception ex)
            {
                reportText.Text = $"Error loading report: {ex.Message}";
            }

            btnGenerate.Click += (s, ev) =>
            {
                try
                {
                    // Clear the current report text first
                    if (reportPanel.Controls.Count > 0 && reportPanel.Controls[0] is RichTextBox existingReportText)
                    {
                        existingReportText.Clear();
                    }

                    // Generate new reports
                    //ReportGenerator.InitializeGeneration();
                    ReportGenerator.GenerateExcelReport(currentUser.Username);
                    ReportGenerator.GenerateTextReport(currentUser.Username);
                    ReportGenerator.GeneratePdfReport(currentUser.Username);

                    // Add a small delay to ensure file is written completely
                    System.Threading.Thread.Sleep(100);

                    MessageBox.Show("Report generated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh report display by reading the new content AFTER showing the message
                    string reportContent = File.ReadAllText(AppPaths.GetTextSaveFile());
                    if (reportPanel.Controls.Count > 0 && reportPanel.Controls[0] is RichTextBox rtb)
                    {
                        rtb.Text = reportContent;
                        rtb.Refresh();
                        Application.DoEvents(); // Ensure UI updates immediately
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Add controls to panels
            buttonsPanel.Controls.AddRange(new Control[] { btnExcel, btnPDF, btnGenerate });
            reportPanel.Controls.Add(reportText);
            mainContainer.Controls.AddRange(new Control[] { buttonsPanel, reportPanel });
            panelDesktop.Controls.Add(mainContainer);

            // Activate button styling
            ActivateButton(sender, Color.FromArgb(95, 77, 221));
        }

        private void btnAssets_Click(object sender, EventArgs e)
        {
            if (!panelAssetsSubmenu.Visible)
            {
                // Calculate position below Assets button, accounting for top panel
                Point buttonPoint = btnAssets.PointToScreen(Point.Empty);
                Point formPoint = this.PointToClient(buttonPoint);

                panelAssetsSubmenu.Location = new Point(
                    formPoint.X,
                    formPoint.Y + btnAssets.Height
                );

                panelAssetsSubmenu.BringToFront();
            }
            panelAssetsSubmenu.Visible = !panelAssetsSubmenu.Visible;
        }

        private void AssetButton_Click(object sender, EventArgs e)
        {
            IconButton clickedButton = sender as IconButton;
            string assetType = clickedButton.Text;

            // Clear desktop panel
            panelDesktop.Controls.Clear();

            // Create scrollable panel
            Panel scrollPanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            // Get assets based on type
            List<Asset> assets = new List<Asset>();
            switch (assetType)
            {
                case "Gold":
                    assets = DatabaseOrganizer.GetAllUserGold(currentUser.Username).ToList<Asset>();
                    break;
                case "Crypto":
                    assets = DatabaseOrganizer.GetAllUserCrypto(currentUser.Username).ToList<Asset>();
                    break;
                case "RealEstate":
                    assets = DatabaseOrganizer.GetAllUserRealEstate(currentUser.Username).ToList<Asset>();
                    break;
                case "Stock":
                    assets = DatabaseOrganizer.GetAllUserStock(currentUser.Username).ToList<Asset>();
                    break;
            }

            // Add asset panels
            int yOffset = 0;
            foreach (var asset in assets)
            {
                Panel assetPanel = CreateAssetInfoPanel(asset);
                assetPanel.Location = new Point(0, yOffset);
                scrollPanel.Controls.Add(assetPanel);
                yOffset += assetPanel.Height + 10;
            }

            // Add the scroll panel to desktop
            panelDesktop.Controls.Add(scrollPanel);

            // Initialize ADD button if needed
            // Add after panelDesktop.Controls.Add(scrollPanel);
            if (btnAdd == null)
            {
                InitializeAddButton();
            }
            btnAdd.Tag = assetType;
            btnAdd.Visible = true;
            btnAdd.BringToFront();
            UpdateAddButtonPosition();
            panelDesktop.Controls.Add(btnAdd);
            UpdateAddButtonPosition();

            // Activate button styling
            ActivateButton(clickedButton, Color.FromArgb(95, 77, 221));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.WriteAllText(AppPaths.GetLoginStateFile(), "");
                Application.Restart();
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaximize.IconChar = IconChar.WindowRestore;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.IconChar = IconChar.Square;
            }
        }


        private void ShowUserProfile()
        {
            // Clear desktop panel and hide ADD button
            panelDesktop.Controls.Clear();
            if (btnAdd != null) btnAdd.Visible = false;

            // Create main profile panel
            Panel profilePanel = new Panel
            {
                Width = 1000,
                Height = 700,
                BackColor = Color.FromArgb(245, 246, 250),
                Padding = new Padding(40)
            };

            // Create header panel with user info
            Panel headerPanel = new Panel
            {
                Width = 920,
                Height = 150,
                BackColor = Color.White,
                Location = new Point(40, 40)
            };

            // Profile icon
            IconPictureBox profileIcon = new IconPictureBox
            {
                IconChar = IconChar.UserCircle,
                IconSize = 100,
                Size = new Size(100, 100),
                Location = new Point(30, 25),
                IconColor = Color.FromArgb(95, 77, 221),
                BackColor = Color.Transparent
            };

            // User info labels
            Label lblProfileName = new Label
            {
                Text = currentUser.Name,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(95, 77, 221),
                Location = new Point(150, 30),
                AutoSize = true
            };

            Label lblProfileUsername = new Label
            {
                Text = $"@{currentUser.Username}",
                Font = new Font("Segoe UI", 16),
                ForeColor = Color.Gray,
                Location = new Point(150, 80),
                AutoSize = true
            };

            // Add controls to header panel
            headerPanel.Controls.AddRange(new Control[] { profileIcon, lblProfileName, lblProfileUsername });

            // Create assets overview panel
            Panel assetsPanel = new Panel
            {
                Location = new Point(40, 210),
                Width = 920,
                Height = 450,
                BackColor = Color.White
            };

            // Add assets title
            Label lblAssetsTitle = new Label
            {
                Text = "Assets Overview",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(95, 77, 221),
                Location = new Point(30, 30),
                AutoSize = true
            };
            assetsPanel.Controls.Add(lblAssetsTitle);

            // Add asset cards
            var assetTypes = new[]{
                (type: "Gold", icon: IconChar.Crown, color: Color.FromArgb(255, 215, 0)),
                (type: "Crypto", icon: IconChar.Bitcoin, color: Color.FromArgb(247, 147, 26)),
                (type: "Stock", icon: IconChar.ChartLine, color: Color.FromArgb(0, 150, 136)),
                (type: "Real Estate", icon: IconChar.Home, color: Color.FromArgb(156, 39, 176))
            };

            int cardWidth = 420;
            int cardHeight = 180;
            int padding = 30;
            int startY = 90;

            // Create and add asset cards
            for (int i = 0; i < assetTypes.Length; i++)
            {
                var (type, icon, color) = assetTypes[i];
                int row = i / 2;
                int col = i % 2;
                int x = padding + (cardWidth + padding) * col;
                int y = startY + (cardHeight + padding) * row;

                Panel card = CreateAssetCard(
                    type,
                    icon,
                    color,
                    GetAssetCount(type),
                    GetAssetROI(type),
                    new Point(x, y),
                    new Size(cardWidth, cardHeight)
                );

                assetsPanel.Controls.Add(card);
            }

            // Add panels to main profile panel
            profilePanel.Controls.AddRange(new Control[] { headerPanel, assetsPanel });

            // Center the profile panel
            profilePanel.Location = new Point(
                (panelDesktop.Width - profilePanel.Width) / 2,
                (panelDesktop.Height - profilePanel.Height) / 2
            );

            // Add to desktop panel
            panelDesktop.Controls.Add(profilePanel);
        }


        private Panel CreateAssetCard(string assetType, IconChar icon, Color color, int count, decimal roi, Point location, Size size)
        {
            Panel card = new Panel
            {
                Location = location,
                Size = size,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Asset icon
            IconPictureBox assetIcon = new IconPictureBox
            {
                IconChar = icon,
                IconSize = 32,
                Size = new Size(32, 32),
                Location = new Point(20, 20),
                IconColor = color,
                BackColor = Color.Transparent
            };

            // Asset type label
            Label lblType = new Label
            {
                Text = $"{assetType} Assets",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(70, 20),
                AutoSize = true
            };

            // Count label
            Label lblCount = new Label
            {
                Text = $"{count} asset{(count != 1 ? "s" : "")}",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Gray,
                Location = new Point(70, 50),
                AutoSize = true
            };

            // ROI label
            Label lblROI = new Label
            {
                Text = $"ROI: {roi:P2}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = roi >= 0 ? Color.FromArgb(39, 174, 96) : Color.FromArgb(231, 76, 60),
                Location = new Point(20, 90),
                AutoSize = true
            };

            // Add border and shadow effect
            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(230, 230, 230)))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            card.Controls.AddRange(new Control[] { assetIcon, lblType, lblCount, lblROI });
            return card;
        }

        private int GetAssetCount(string assetType)
        {
            return assetType switch
            {
                "Gold" => DatabaseOrganizer.GetUserGoldCount(currentUser.Username),
                "Crypto" => DatabaseOrganizer.GetUserCryptoCount(currentUser.Username),
                "Stock" => DatabaseOrganizer.GetUserStockCount(currentUser.Username),
                "Real Estate" => DatabaseOrganizer.GetUserRealEstateCount(currentUser.Username),
                _ => 0
            };
        }

        private decimal GetAssetROI(string assetType)
        {
            return assetType switch
            {
                "Gold" => InvestmentAnalyzer.GetGoldROI(currentUser.Username),
                "Crypto" => InvestmentAnalyzer.GetCryptoROI(currentUser.Username),
                "Stock" => InvestmentAnalyzer.GetStockROI(currentUser.Username),
                "Real Estate" => InvestmentAnalyzer.GetRealEstateROI(currentUser.Username),
                _ => 0
            };
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(30, 30, 45);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && sender is Panel && ((Panel)sender).Name == "panelTop")
                {
                    isDragging = true;
                    ReleaseCapture();
                    SendMessage(this.Handle, 0x112, 0xf012, 0);
                }
            }
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}