using System.Text.Json;

namespace Invest_Application
{
    public class InvestmentAnalyzer
    {
        private decimal GetAssetCurrentValue(string folderPath)
        {
            
            decimal totalGain = 0;
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    Asset? asset = JsonOrganizer.GetAssetFromDB<Asset>(file);
                    if (asset != null)
                    {
                        totalGain += asset.CurrentPrice();
                    }
                }
            }
            return totalGain;
        }
        private decimal GetAssetPurchaseValue(string folderPath)
        {
            decimal totalSpent = 0;
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    Asset? asset = JsonOrganizer.GetAssetFromDB<Asset>(file);
                    if (asset != null)
                    {
                        totalSpent += asset.PurchasePrice;
                    }
                }
            }
            return totalSpent;
        }


        public decimal GetGoldCurrentValue(string username)
        {
            return GetAssetCurrentValue(AppPaths.GetUserGoldFolder(username));
        }

        public decimal GetGoldPurchaseValue(string username)
        {
            return GetAssetPurchaseValue(AppPaths.GetUserGoldFolder(username));
        }

        public decimal GetGoldROI(string username)
        {
            decimal gain = GetGoldCurrentValue(username);
            decimal spent = GetGoldPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public decimal GetRealEstateCurrentValue(string username)
        {
            return GetAssetCurrentValue(AppPaths.GetUserRealEstateFolder(username));
        }

        public decimal GetRealEstatePurchaseValue(string username)
        {
            return GetAssetPurchaseValue(AppPaths.GetUserRealEstateFolder(username));
        }

        public decimal GetRealEstateROI(string username)
        {
            decimal gain = GetRealEstateCurrentValue(username);
            decimal spent = GetRealEstatePurchaseValue(username);
            return (gain - spent) / spent;
        }

        public decimal GetStockCurrentValue(string username)
        {
            return GetAssetCurrentValue(AppPaths.GetUserStockFolder(username));
        }

        public decimal GetStockPurchaseValue(string username)
        {
            return GetAssetPurchaseValue(AppPaths.GetUserStockFolder(username));
        }

        public decimal GetStockROI(string username)
        {
            decimal gain = GetStockCurrentValue(username);
            decimal spent = GetStockPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public decimal GetCryptoCurrentValue(string username)
        {
            return GetAssetCurrentValue(AppPaths.GetUserCryptoFolder(username));
        }

        public decimal GetCryptoPurchaseValue(string username)
        {
            return GetAssetPurchaseValue(AppPaths.GetUserCryptoFolder(username));
        }

        public decimal GetCryptoROI(string username)
        {
            decimal gain = GetCryptoCurrentValue(username);
            decimal spent = GetCryptoPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public decimal GetTotalCurrentValue(string username)
        {
            return GetGoldCurrentValue(username)
                 + GetRealEstateCurrentValue(username)
                 + GetStockCurrentValue(username)
                 + GetCryptoCurrentValue(username);
        }

        public decimal GetTotalPurchaseValue(string username)
        {
            return GetGoldPurchaseValue(username)
                 + GetRealEstatePurchaseValue(username)
                 + GetStockPurchaseValue(username)
                 + GetCryptoPurchaseValue(username);
        }

        public decimal GetTotalROI(string username)
        {
            decimal gain = GetTotalCurrentValue(username);
            decimal spent = GetTotalPurchaseValue(username);
            return (gain - spent) / spent;
        }
    }
}
