using System.Text.Json;

namespace Invest_Application
{
    public static class InvestmentAnalyzer
    {
        public static decimal GetGoldCurrentValue(string username)
        {
            List<Gold> assets = DatabaseOrganizer.GetAllUserGold(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public static decimal GetGoldPurchaseValue(string username)
        {
            List<Gold> assets = DatabaseOrganizer.GetAllUserGold(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice() * asset.Quantity;
            }
            return totalSpent;
        }

        public static decimal GetGoldROI(string username)
        {
            decimal gain = GetGoldCurrentValue(username);
            decimal spent = GetGoldPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public static decimal GetRealEstateCurrentValue(string username)
        {
            List<RealEstate> assets = DatabaseOrganizer.GetAllUserRealEstate(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public static decimal GetRealEstatePurchaseValue(string username)
        {
            List<RealEstate> assets = DatabaseOrganizer.GetAllUserRealEstate(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice() * asset.Quantity;
            }
            return totalSpent;
        }

        public static decimal GetRealEstateROI(string username)
        {
            decimal gain = GetRealEstateCurrentValue(username);
            decimal spent = GetRealEstatePurchaseValue(username);
            return (gain - spent) / spent;
        }


        public static decimal GetStockCurrentValue(string username)
        {
            List<Stock> assets = DatabaseOrganizer.GetAllUserStock(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public static decimal GetStockPurchaseValue(string username)
        {
            List<Stock> assets = DatabaseOrganizer.GetAllUserStock(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice() * asset.Quantity;
            }
            return totalSpent;
        }

        public static decimal GetStockROI(string username)
        {
            decimal gain = GetStockCurrentValue(username);
            decimal spent = GetStockPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public static decimal GetCryptoCurrentValue(string username)
        {
            List<Crypto> assets = DatabaseOrganizer.GetAllUserCrypto(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public static decimal GetCryptoPurchaseValue(string username)
        {
            List<Crypto> assets = DatabaseOrganizer.GetAllUserCrypto(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice() * asset.Quantity;
            }
            return totalSpent;
        }

        public static decimal GetCryptoROI(string username)
        {
            decimal gain = GetCryptoCurrentValue(username);
            decimal spent = GetCryptoPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public static decimal GetTotalCurrentValue(string username)
        {
            return GetGoldCurrentValue(username)
                 + GetRealEstateCurrentValue(username)
                 + GetStockCurrentValue(username)
                 + GetCryptoCurrentValue(username);
        }

        public static decimal GetTotalPurchaseValue(string username)
        {
            return GetGoldPurchaseValue(username)
                 + GetRealEstatePurchaseValue(username)
                 + GetStockPurchaseValue(username)
                 + GetCryptoPurchaseValue(username);
        }

        public static decimal GetTotalROI(string username)
        {
            decimal gain = GetTotalCurrentValue(username);
            decimal spent = GetTotalPurchaseValue(username);
            return (gain - spent) / spent;
        }
    }
}
