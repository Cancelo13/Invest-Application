using FontAwesome.Sharp;
using Invest_Application;

namespace InvestApp.Forms
{
    partial class AssetForm
    {
        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtName = new TextBox();
            this.txtQuantity = new TextBox();
            this.txtPrice = new TextBox();
            this.dtpPurchaseDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Form
            this.Text = "Add Asset";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(400, 500);
            this.BackColor = Color.White;

            // Title
            this.lblTitle = new Label
            {
                Text = "Add New Asset",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(95, 77, 221),
                Location = new Point(20, 20),
                Size = new Size(360, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Asset Name
            Label lblName = new Label
            {
                Text = "Asset Name",
                Location = new Point(20, 80),
                Size = new Size(360, 20)
            };

            this.txtName = new TextBox
            {
                Location = new Point(20, 100),
                Size = new Size(360, 30),
                Font = new Font("Segoe UI", 12)
            };

            // Quantity
            Label lblQuantity = new Label
            {
                Text = "Quantity",
                Location = new Point(20, 150),
                Size = new Size(360, 20)
            };

            this.txtQuantity = new TextBox
            {
                Location = new Point(20, 170),
                Size = new Size(360, 30),
                Font = new Font("Segoe UI", 12)
            };

            // Purchase Price
            Label lblPrice = new Label
            {
                Text = "Purchase Price ($)",
                Location = new Point(20, 220),
                Size = new Size(360, 20)
            };

            this.txtPrice = new TextBox
            {
                Location = new Point(20, 240),
                Size = new Size(360, 30),
                Font = new Font("Segoe UI", 12)
            };

            // Purchase Date
            Label lblDate = new Label
            {
                Text = "Purchase Date",
                Location = new Point(20, 290),
                Size = new Size(360, 20)
            };

            this.dtpPurchaseDate = new DateTimePicker
            {
                Location = new Point(20, 310),
                Size = new Size(360, 30),
                Font = new Font("Segoe UI", 12),
                Format = DateTimePickerFormat.Short
            };

            // Save Button
            this.btnSave = new Button
            {
                Text = "Save",
                Location = new Point(20, 380),
                Size = new Size(170, 40),
                BackColor = Color.FromArgb(95, 77, 221),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            this.btnSave.Click += btnSave_Click;

            // Cancel Button
            this.btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(210, 380),
                Size = new Size(170, 40),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            this.btnCancel.Click += btnCancel_Click;

            // Add controls
            this.Controls.AddRange(new Control[] {
                lblTitle,
                lblName, txtName,
                lblQuantity, txtQuantity,
                lblPrice, txtPrice,
                lblDate, dtpPurchaseDate,
                btnSave, btnCancel
            });
        }

        private Label lblTitle;
        private TextBox txtName;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private DateTimePicker dtpPurchaseDate;
        private Button btnSave;
        private Button btnCancel;
    }
}