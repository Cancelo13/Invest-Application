using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using Invest_Application;

namespace InvestApp.Forms
{
    public partial class AssetForm : Form
    {
        private readonly string assetType;
        private readonly string username;

        public AssetForm(string assetType, string username)
        {
            InitializeComponent();
            this.assetType = assetType;
            this.username = username;
            this.Load += AssetForm_Load;
        }

        private void AssetForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Add New {assetType}";
            dtpPurchaseDate.MaxDate = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    Asset newAsset = CreateAsset();
                    SaveAsset(newAsset);
                    MessageBox.Show("Asset added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding asset: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Asset CreateAsset()
        {
            string name = txtName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);
            DateTime date = dtpPurchaseDate.Value;

            return assetType switch
            {
                "Gold" => new Gold(name, quantity, price, date),
                "Crypto" => new Crypto(name, quantity, price, date),
                "RealEstate" => new RealEstate(name, quantity, price, date),
                "Stock" => new Stock(name, quantity, price, date),
                _ => throw new ArgumentException("Invalid asset type")
            };
        }

        private void SaveAsset(Asset asset)
        {
            switch (assetType)
            {
                case "Gold":
                    DatabaseOrganizer.SaveUserGold((Gold)asset, username);
                    break;
                case "Crypto":
                    DatabaseOrganizer.SaveUserCrypto((Crypto)asset, username);
                    break;
                case "RealEstate":
                    DatabaseOrganizer.SaveUserRealEstate((RealEstate)asset, username);
                    break;
                case "Stock":
                    DatabaseOrganizer.SaveUserStock((Stock)asset, username);
                    break;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter an asset name.", "Validation Error");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}