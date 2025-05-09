using System.Text.Json;

namespace Invest_Application
{
    public class InvestmentAnalyzer
    {
        public decimal GetGoldCurrentValue(string username)
        {
            List<Gold> assets = DatabaseOrganizer.GetAllUserGold(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public decimal GetGoldPurchaseValue(string username)
        {
            List<Gold> assets = DatabaseOrganizer.GetAllUserGold(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice;
            }
            return totalSpent;
        }

        public decimal GetGoldROI(string username)
        {
            decimal gain = GetGoldCurrentValue(username);
            decimal spent = GetGoldPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public decimal GetRealEstateCurrentValue(string username)
        {
            List<RealEstate> assets = DatabaseOrganizer.GetAllUserRealEstate(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public decimal GetRealEstatePurchaseValue(string username)
        {
            List<RealEstate> assets = DatabaseOrganizer.GetAllUserRealEstate(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice;
            }
            return totalSpent;
        }

        public decimal GetRealEstateROI(string username)
        {
            decimal gain = GetRealEstateCurrentValue(username);
            decimal spent = GetRealEstatePurchaseValue(username);
            return (gain - spent) / spent;
        }


        public decimal GetStockCurrentValue(string username)
        {
            List<Stock> assets = DatabaseOrganizer.GetAllUserStock(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public decimal GetStockPurchaseValue(string username)
        {
            List<Stock> assets = DatabaseOrganizer.GetAllUserStock(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice;
            }
            return totalSpent;
        }

        public decimal GetStockROI(string username)
        {
            decimal gain = GetStockCurrentValue(username);
            decimal spent = GetStockPurchaseValue(username);
            return (gain - spent) / spent;
        }

        public decimal GetCryptoCurrentValue(string username)
        {
            List<Crypto> assets = DatabaseOrganizer.GetAllUserCrypto(username);
            decimal totalGain = 0;
            foreach (var asset in assets)
            {
                totalGain += asset.CurrentPrice();
            }
            return totalGain;
        }

        public decimal GetCryptoPurchaseValue(string username)
        {
            List<Crypto> assets = DatabaseOrganizer.GetAllUserCrypto(username);
            decimal totalSpent = 0;
            foreach (var asset in assets)
            {
                totalSpent += asset.PurchasePrice;
            }
            return totalSpent;
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
