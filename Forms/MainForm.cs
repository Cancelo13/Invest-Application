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
            decimal totalROI = 0; // Replace with actual calculation
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
            UpdateAddButtonPosition();
        }

        private void UpdateAddButtonPosition()
        {
            if (btnAdd != null)
            {
                btnAdd.Location = new Point(
                    panelDesktop.Width - btnAdd.Width - 30,
                    panelDesktop.Height - btnAdd.Height - 30
                );
            }
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

            // Initialize ADD button if it doesn't exist
            if (btnAdd == null)
            {
                InitializeAddButton();
            }

            // Show and update ADD button
            btnAdd.Tag = assetType;
            btnAdd.Visible = true;
            btnAdd.BringToFront();
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