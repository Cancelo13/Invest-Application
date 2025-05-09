using FontAwesome.Sharp;

namespace InvestApp.Forms
{
    partial class LoaderForm
    {
        private void InitializeComponent()
        {
            this.progressBar = new CircularProgressBar.CircularProgressBar();
            this.lblTitle = new Label();
            this.lblLoading = new Label();
            this.lblWaitMessage = new Label(); // Add new label

            // Form
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 500); // Increased form size

            // Title
            this.lblTitle.Text = "InvestApp";
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Padding = new Padding(0, 40, 0, 0);

            // Wait Message
            this.lblWaitMessage.Text = "We are patching everything up, please wait";
            this.lblWaitMessage.Font = new Font("Segoe UI", 12F);
            this.lblWaitMessage.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblWaitMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.lblWaitMessage.Size = new Size(500, 30);
            this.lblWaitMessage.Location = new Point(0, 160);

            // Progress Bar
            this.progressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progressBar.AnimationSpeed = 500;
            this.progressBar.BackColor = Color.FromArgb(30, 30, 45);
            this.progressBar.Font = new Font("Segoe UI", 48F, FontStyle.Bold); // Reduced font size
            this.progressBar.ForeColor = Color.White;
            this.progressBar.InnerColor = Color.FromArgb(30, 30, 45);
            this.progressBar.InnerMargin = 2;
            this.progressBar.InnerWidth = 8; // Reduced width
            this.progressBar.Location = new Point(175, 200); // Adjusted location
            this.progressBar.MarqueeAnimationSpeed = 2000;
            this.progressBar.Name = "progressBar";
            this.progressBar.OuterColor = Color.FromArgb(40, 40, 60);
            this.progressBar.OuterMargin = -25;
            this.progressBar.OuterWidth = 20; // Reduced width
            this.progressBar.ProgressColor = Color.FromArgb(95, 77, 221);
            this.progressBar.ProgressWidth = 8; // Reduced width
            this.progressBar.SecondaryFont = new Font("Segoe UI", 24F); // Reduced font size
            this.progressBar.Size = new Size(150, 150); // Reduced size
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.SubscriptColor = Color.FromArgb(95, 77, 221);
            this.progressBar.SubscriptMargin = new Padding(10, -35, 0, 0);
            this.progressBar.SuperscriptColor = Color.FromArgb(95, 77, 221);
            this.progressBar.SuperscriptMargin = new Padding(10, 35, 0, 0);
            this.progressBar.TextMargin = new Padding(8, 8, 0, 0);
            this.progressBar.Value = 68;

            // Loading Text
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Font = new Font("Segoe UI", 12F);
            this.lblLoading.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLoading.Dock = DockStyle.Bottom;
            this.lblLoading.Padding = new Padding(0, 0, 0, 40);

            // Add Controls
            this.Controls.AddRange(new Control[] { 
                lblTitle, 
                lblWaitMessage, // Added new label
                progressBar, 
                lblLoading 
            });
        }

        private CircularProgressBar.CircularProgressBar progressBar;
        private Label lblTitle;
        private Label lblLoading;
        private Label lblWaitMessage; // Add field for new label
    }
}