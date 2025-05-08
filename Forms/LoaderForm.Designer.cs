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

            // Form
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 400);
            this.Load += new EventHandler(LoaderForm_Load);

            // Title
            this.lblTitle.Text = "InvestApp";
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Padding = new Padding(0, 40, 0, 0);

            // Loading Text
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Font = new Font("Segoe UI", 12F);
            this.lblLoading.ForeColor = Color.FromArgb(95, 77, 221);
            this.lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLoading.Dock = DockStyle.Bottom;
            this.lblLoading.Padding = new Padding(0, 0, 0, 40);

            // Progress Bar
            this.progressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progressBar.AnimationSpeed = 500;
            this.progressBar.BackColor = Color.FromArgb(30, 30, 45);
            this.progressBar.Font = new Font("Segoe UI", 72F, FontStyle.Bold);
            this.progressBar.ForeColor = Color.White;
            this.progressBar.InnerColor = Color.FromArgb(30, 30, 45);
            this.progressBar.InnerMargin = 2;
            this.progressBar.InnerWidth = 10;
            this.progressBar.Location = new Point(100, 120);
            this.progressBar.MarqueeAnimationSpeed = 2000;
            this.progressBar.Name = "progressBar";
            this.progressBar.OuterColor = Color.FromArgb(40, 40, 60);
            this.progressBar.OuterMargin = -25;
            this.progressBar.OuterWidth = 26;
            this.progressBar.ProgressColor = Color.FromArgb(95, 77, 221);
            this.progressBar.ProgressWidth = 10;
            this.progressBar.SecondaryFont = new Font("Segoe UI", 36F);
            this.progressBar.Size = new Size(200, 200);
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.SubscriptColor = Color.FromArgb(95, 77, 221);
            this.progressBar.SubscriptMargin = new Padding(10, -35, 0, 0);
            this.progressBar.SuperscriptColor = Color.FromArgb(95, 77, 221);
            this.progressBar.SuperscriptMargin = new Padding(10, 35, 0, 0);
            this.progressBar.TextMargin = new Padding(8, 8, 0, 0);
            this.progressBar.Value = 68;

            // Add Controls
            this.Controls.AddRange(new Control[] { lblTitle, progressBar, lblLoading });
        }

        private CircularProgressBar.CircularProgressBar progressBar;
        private Label lblTitle;
        private Label lblLoading;
    }
}