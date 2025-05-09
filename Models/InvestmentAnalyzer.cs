using System.Text.Json;

namespace Invest_Application
{
    public class InvestmentAnalyzer
    {
        public decimal GetAssetROI(string folderPath)
        {
            decimal total = 0;
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    Asset? asset = JsonOrganizer.GetAssetFromDB<Asset>(file);
                    if (asset != null)
                    {
                        total += asset.CalculateROI();
                    }
                }
            }
            return total;
        }
        public decimal GetGoldROI(string username)
        {
            return GetAssetROI(AppPaths.GetUserGoldFolder(username));
        }

        public decimal GetRealEstateROI(string username)
        {
            return GetAssetROI(AppPaths.GetUserRealEstateFolder(username));
        }

        public decimal GetStockROI(string username)
        {
            return GetAssetROI(AppPaths.GetUserStockFolder(username));
        }

        public decimal GetCryptoROI(string username)
        {
            return GetAssetROI(AppPaths.GetUserCryptoFolder(username));
        }

        public decimal GetTotalROI(string username)
        {
            return GetGoldROI(username) +
                   GetRealEstateROI(username) +
                   GetStockROI(username) +
                   GetCryptoROI(username);
        }

    }
}
