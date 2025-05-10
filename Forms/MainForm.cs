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

        public MainForm(User user)
        {
            InitializeComponent();
            leftBorderBtn = new Panel
            {
                Size = new Size(7, 60),
                Visible = false
            };
            panelMenu.Controls.Add(leftBorderBtn);

            // ...existing code...
            currentUser = user;
            this.MouseDown += Form_MouseDown;
            LoadUserInfo();
            InitializeAddButton();
            this.Load += (s, e) => ShowUserProfile();
            this.Resize += (s, e) => UpdateAddButtonPosition();
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
            btnEdit.Click += (s, e) => { /* Edit functionality will be added later */ };

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
            btnDelete.Click += (s, e) => { /* Delete functionality will be added later */ };


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
            ReportGenerator.InitializeGeneration();
            ReportGenerator.GenerateExcelReport(currentUser.Username);
            ReportGenerator.GeneratePdfReport(currentUser.Username);
            ReportGenerator.GenerateTextReport(currentUser.Username);
            // Hide ADD button if it exists
            if (btnAdd != null)
            {
                btnAdd.Visible = false;
            }

            // Create container panel for buttons
            Panel reportButtonsPanel = new Panel
            {
                Width = 400,
                Height = 150,
                BackColor = Color.Transparent
            };

            // Create Excel button
            IconButton btnExcel = new IconButton
            {
                Text = "EXCEL Report",
                IconChar = IconChar.FileExcel,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 60),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 128, 71),
                IconColor = Color.FromArgb(25, 128, 71),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Location = new Point(0, 0)
            };
            btnExcel.FlatAppearance.BorderSize = 2;
            btnExcel.FlatAppearance.BorderColor = Color.FromArgb(25, 128, 71);
            btnExcel.Click += (s, ev) =>
            {
                try
                {
                    ReportGenerator.SaveExcelReport(currentUser.Username, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    MessageBox.Show("Excel report generated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating Excel report: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Create PDF button
            IconButton btnPDF = new IconButton
            {
                Text = "PDF Report",
                IconChar = IconChar.FilePdf,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 60),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 33, 39),
                IconColor = Color.FromArgb(200, 33, 39),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Location = new Point(220, 0)
            };
            btnPDF.FlatAppearance.BorderSize = 2;
            btnPDF.FlatAppearance.BorderColor = Color.FromArgb(200, 33, 39);
            btnPDF.Click += (s, ev) =>
            {
                try
                {
                    ReportGenerator.SavePdfReport(currentUser.Username, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    MessageBox.Show("PDF report saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving PDF report: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Add buttons to container panel
            reportButtonsPanel.Controls.AddRange(new Control[] { btnExcel, btnPDF });

            // Center the container panel
            reportButtonsPanel.Location = new Point(
                (panelDesktop.Width - reportButtonsPanel.Width) / 2,
                (panelDesktop.Height - reportButtonsPanel.Height) / 2
            );

            // Add container panel to desktop
            panelDesktop.Controls.Add(reportButtonsPanel);

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

        private void ShowUserProfile()
        {
            // Clear desktop panel
            panelDesktop.Controls.Clear();

            // Hide ADD button if it exists
            if (btnAdd != null)
            {
                btnAdd.Visible = false;
            }

            // This is a placeholder for when you implement the profile form
            panelProfile.BringToFront();
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
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
    }
}