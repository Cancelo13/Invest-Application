using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.IO;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

// ─────────────────────────────────────────────────────────────────────────────
//  DatabaseOrganizer - Database Utility Class
// 
//  void SaveUser(User)                                : Save the user in the DB
//  User GetUser(username)                             : Returns the user from DB
//  void DeleteUser(username)                          : Delete the user from DB
//  bool IsUserExists(username)                        : Returns true if the username exists in the DB
//  void SaveUserGold(Gold gold, string username)
//  void SaveUserRealEstate(RealEstate realEstate, string username)
//  void SaveUserStock(Stock stock, string username)
//  void SaveUserCrypto(Crypto crypto, string username)
//  void DeleteUserGold(Gold gold, string username, string fileName)
//  void DeleteUserRealEstate(RealEstate realEstate, string username, string fileName)
//  void DeleteUserStock(Stock stock, string username, string fileName)
//  void DeleteUserCrypto(Crypto crypto, string username, string fileName)

//  
// ─────────────────────────────────────────────────────────────────────────────


namespace Invest_Application
{
    public static class DatabaseOrganizer
    {

        public static void SaveUser(User user)
        {
            if (!IsUserExists(user.Username))
            {
                Directory.CreateDirectory(AppPaths.GetUserAssetsFolder(user.Username));
                Directory.CreateDirectory(AppPaths.GetUserGoldFolder(user.Username));
                Directory.CreateDirectory(AppPaths.GetUserCryptoFolder(user.Username));
                Directory.CreateDirectory(AppPaths.GetUserRealEstateFolder(user.Username));
                Directory.CreateDirectory(AppPaths.GetUserStockFolder(user.Username));
            }
            var jsonString = JsonSerializer.Serialize(user);
            File.WriteAllText(AppPaths.GetUserFile(user.Username), jsonString);
        }

        public static void DeleteUser(string username)
        {
            string filePath = AppPaths.GetUserFile(username);
            string folderPath = AppPaths.GetUserAssetsFolder(username);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath);
            }
        }

        public static bool IsUserExists(string username)
        {
            string path = AppPaths.GetUserFile(username);
            return File.Exists(path);
        }

        public static User GetUser(string username)
        {
            if (!IsUserExists(username))
            {
                throw new FileNotFoundException("User data file not found");
            }

            string path = AppPaths.GetUserFile(username);
            var jsonString = File.ReadAllText(path);
            var user = JsonSerializer.Deserialize<User>(jsonString);

            return user ?? throw new Exception("Failed to deserialize user data");

        }

        private static void SaveUserAsset(Asset asset, string folder)
        {
            if (!Directory.Exists(folder))
            {
                throw new DirectoryNotFoundException("User asset not exist");
            }
            for (int i = 0; ; i++)
            {
                string fileName = (i == 0) ? asset.Name : $"{asset.Name}-{i}";
                string currPath = Path.Combine(folder, fileName + ".json");
                if (!File.Exists(currPath))
                {
                    var jsonString = JsonSerializer.Serialize(asset);
                    File.WriteAllText(currPath, jsonString);
                    break;
                }
            }
        }

        public static void SaveUserGold(Gold gold, string username)
        {
            SaveUserAsset(gold, AppPaths.GetUserGoldFolder(username));
        }

        public static void SaveUserRealEstate(RealEstate realEstate, string username)
        {
            SaveUserAsset(realEstate, AppPaths.GetUserRealEstateFolder(username));
        }

        public static void SaveUserStock(Stock stock, string username)
        {
            SaveUserAsset(stock, AppPaths.GetUserStockFolder(username));
        }

        public static void SaveUserCrypto(Crypto crypto, string username)
        {
            SaveUserAsset(crypto, AppPaths.GetUserCryptoFolder(username));
        }

        public static void DeleteUserGold(string username, string fileName)
        {
            string filePath = Path.Combine(AppPaths.GetUserGoldFolder(username), fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void DeleteUserRealEstate(string username, string fileName)
        {
            string filePath = Path.Combine(AppPaths.GetUserRealEstateFolder(username), fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void DeleteUserStock(string username, string fileName)
        {
            string filePath = Path.Combine(AppPaths.GetUserStockFolder(username), fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void DeleteUserCrypto(string username, string fileName)
        {
            string filePath = Path.Combine(AppPaths.GetUserCryptoFolder(username), fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void OverwriteUserGold(Gold gold, string username, string fileName)
        {
            DeleteUserGold(username, fileName);
            SaveUserGold(gold, username);
        }

        public static void OverwriteUserRealEstate(RealEstate realEstate, string username, string fileName)
        {
            DeleteUserRealEstate(username, fileName);
            SaveUserRealEstate(realEstate, username);
        }

        public static void OverwriteUserStock(Stock stock, string username, string fileName)
        {
            DeleteUserStock(username, fileName);
            SaveUserStock(stock, username);
        }

        public static void OverwriteUserCrypto(Crypto crypto, string username, string fileName)
        {
            DeleteUserCrypto(username, fileName);
            SaveUserCrypto(crypto, username);
        }

        private static decimal ExtractDecimalFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified API file does not exist.", filePath);

            string content = File.ReadAllText(filePath).Trim();

            if (decimal.TryParse(content, out decimal result))
                return result;
            else
                throw new FormatException("The API file does not contain a valid decimal number.");
        }


        public static decimal GetGoldMarketPrice()
        {
            return ExtractDecimalFromFile(AppPaths.GetGoldAPIFile());
        }
        public static decimal GetRealEstateMarketExponent()
        {
            return ExtractDecimalFromFile(AppPaths.GetRealEstateAPIFile());
        }

        public static decimal GetStockMarketPrice()
        {
            return ExtractDecimalFromFile(AppPaths.GetStockAPIFile());
        }

        public static decimal GetCryptoMarketPrice()
        {
            return ExtractDecimalFromFile(AppPaths.GetCryptoAPIFile());
        }

    }
}
