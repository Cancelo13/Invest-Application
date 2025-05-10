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

        public static readonly string cookiesFolder = Path.Combine(dataPath, "cookies");
        public static readonly string loginStateFile = Path.Combine(cookiesFolder, "loginStatus.json");

        public static string GetExcelSaveFile(string username)
        {
            return Path.Combine(cookiesFolder, username + " Investment Report.xlsx");
        }

        public static string GetPdfSaveFile(string username)
        {
            return Path.Combine(cookiesFolder, username + " Investment Report.pdf");
        }

        public static string GetTextSaveFile()
        {
            return Path.Combine(cookiesFolder, "temporary.txt");
        }

        public static string GetUserFile(string userName)
        {
            return Path.Combine(usersFolder, userName) + ".json";
        }

        public static string GetUserAssetsFolder(string userName)
        {
            return Path.Combine(assetsFolder, userName);
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

        public static string GetAssetFolder()
        {
            return assetsFolder;
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

        public static string GetLoginStateFile()
        {
            return loginStateFile;
        }

        public static void EnsureDataStructure()
        {

            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);

            if (!Directory.Exists(dataBaseFolder))
                Directory.CreateDirectory(dataBaseFolder);

            if (!Directory.Exists(usersFolder))
                Directory.CreateDirectory(usersFolder);

            if (!Directory.Exists(assetsFolder))
                Directory.CreateDirectory(assetsFolder);

            if (!Directory.Exists(APIequivalentFolder))
                Directory.CreateDirectory(APIequivalentFolder);

            if (!Directory.Exists(cookiesFolder))
                Directory.CreateDirectory(cookiesFolder);

            CreateEmptyFileIfNotExists(goldAPIFile, "4800");
            CreateEmptyFileIfNotExists(realEstateAPIFile, "1.15");
            CreateEmptyFileIfNotExists(stockAPIFile, "50000");
            CreateEmptyFileIfNotExists(cryptoAPIFile, "1000000");
            CreateEmptyFileIfNotExists(loginStateFile, "");
        }

        private static void CreateEmptyFileIfNotExists(string filePath, string content)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, content);
            }
        }
    }
}
