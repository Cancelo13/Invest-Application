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

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            this.MouseDown += Form_MouseDown;
            LoadUserInfo();
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

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void btnAssets_Click(object sender, EventArgs e)
        {
            if (!panelAssetsSubmenu.Visible)
            {
                // Calculate position below Assets button
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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