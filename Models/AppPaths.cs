using System;
using System.IO;

namespace Invest_Application
{
    public static class AppPaths
    {
        public static readonly string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        public static readonly string dataBaseFolder = Path.Combine(dataPath, "DB");

        public static readonly string usersFolder = Path.Combine(dataBaseFolder, "users");
        public static readonly string assetsFolder = Path.Combine(dataBaseFolder, "assets");
        public static readonly string APIequivalentFolder = Path.Combine(dataBaseFolder, "APIs");

        public static readonly string goldAPIFile = Path.Combine(APIequivalentFolder, "gold.txt");
        public static readonly string realEstateAPIFile = Path.Combine(APIequivalentFolder, "realEstate.txt");
        public static readonly string stockAPIFile = Path.Combine(APIequivalentFolder, "stock.txt");
        public static readonly string cryptoAPIFile = Path.Combine(APIequivalentFolder, "crypto.txt");

        public static readonly string loginStateFile = Path.Combine(dataPath, "loginStatus.txt");



        public static string GetUserFile(string userName)
        {
            return Path.Combine(usersFolder, "userName");
        }

        public static string GetUserAssetsFolder(string userName)
        {
            return Path.Combine(assetsFolder, "userName");
        }

        public static string GetUserGoldFolder(string userName)
        {
            return Path.Combine(GetUserAssetsFolder(userName), "Gold");
        }

        public static string GetUserCryptoFolder(string userName)
        {
            return Path.Combine(GetUserAssetsFolder(userName), "Crypto");
        }
        public static string GetUserStockFolder(string userName)
        {
            return Path.Combine(GetUserAssetsFolder(userName), "Stock");
        }

        public static string GetUserRealEstateFolder(string userName)
        {
            return Path.Combine(GetUserAssetsFolder(userName), "RealEstate");
        }

        public static string GetGoldAPIFile()
        {
            return goldAPIFile;
        }

        public static string GetRealEstateAPIFile()
        {
            return realEstateAPIFile;
        }

        public static string GetStockAPIFile()
        {
            return stockAPIFile;
        }

        public static string GetCryptoAPIFile()
        {
            return cryptoAPIFile;
        }
    }
}
