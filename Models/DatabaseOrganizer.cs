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

        private static bool HasGoldId(string username, string id)
        {
            string path = Path.Combine(AppPaths.GetUserGoldFolder(username), id + ".json");
            return File.Exists(path);
        }

        private static bool HasStockId(string username, string id)
        {
            string path = Path.Combine(AppPaths.GetUserStockFolder(username), id + ".json");
            return File.Exists(path);
        }

        private static bool HasCryptoId(string username, string id)
        {
            string path = Path.Combine(AppPaths.GetUserCryptoFolder(username), id + ".json");
            return File.Exists(path);
        }

        private static bool HasRealEstateId(string username, string id)
        {
            string path = Path.Combine(AppPaths.GetUserRealEstateFolder(username), id + ".json");
            return File.Exists(path);
        }


        public static void DeleteUserAsset(string username, Asset asset)
        {
            string filePath = "";
            if (HasGoldId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserGoldFolder(username), asset.Id + ".json");
            }
            else if (HasRealEstateId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserRealEstateFolder(username), asset.Id + ".json");
            }
            else if (HasStockId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserStockFolder(username), asset.Id + ".json");
            }
            else if (HasCryptoId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserCryptoFolder(username), asset.Id + ".json");
            }
            else
            {
                return;
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private static void SaveUserAsset(Asset asset, string folder)
        {
            if (!Directory.Exists(folder))
            {
                throw new DirectoryNotFoundException("User asset not exist");
            }
            string currPath = Path.Combine(folder, asset.Id + ".json");
            if (!File.Exists(currPath))
            {
                var jsonString = JsonSerializer.Serialize(asset);
                File.WriteAllText(currPath, jsonString);
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

        public static void OverwriteUserAsset(string username, Asset asset)
        {
            DeleteUserAsset(username, asset);
            string filePath = "";
            if (HasGoldId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserGoldFolder(username), asset.Id + ".json");
            }
            else if (HasRealEstateId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserRealEstateFolder(username), asset.Id + ".json");
            }
            else if (HasStockId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserStockFolder(username), asset.Id + ".json");
            }
            else if (HasCryptoId(username, asset.Id))
            {
                filePath = Path.Combine(AppPaths.GetUserCryptoFolder(username), asset.Id + ".json");
            }
            else
            {
                return;
            }
            SaveUserAsset(asset, filePath);
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

        public static List<Gold> GetAllUserGold(string username)
        {
            List<Gold> theList = new List<Gold>();
            string folderPath = AppPaths.GetUserGoldFolder(username);
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    Gold? tmpAsset = JsonOrganizer.GetGoldFromDB(file);
                    if (tmpAsset != null)
                    {
                        theList.Add(tmpAsset);
                    }
                }
            }
            return theList;
        }

        public static List<Crypto> GetAllUserCrypto(string username)
        {
            List<Crypto> theList = new List<Crypto>();
            string folderPath = AppPaths.GetUserCryptoFolder(username);
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    Crypto? tmpAsset = JsonOrganizer.GetCryptoFromDB(file);
                    if (tmpAsset != null)
                    {
                        theList.Add(tmpAsset);
                    }
                }
            }
            return theList;
        }

        public static List<RealEstate> GetAllUserRealEstate(string username)
        {
            List<RealEstate> theList = new List<RealEstate>();
            string folderPath = AppPaths.GetUserRealEstateFolder(username);
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    RealEstate? tmpAsset = JsonOrganizer.GetRealEstateFromDB(file);
                    if (tmpAsset != null)
                    {
                        theList.Add(tmpAsset);
                    }
                }
            }
            return theList;
        }

        public static List<Stock> GetAllUserStock(string username)
        {
            List<Stock> theList = new List<Stock>();
            string folderPath = AppPaths.GetUserStockFolder(username);
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    Stock? tmpAsset = JsonOrganizer.GetStockFromDB(file);
                    if (tmpAsset != null)
                    {
                        theList.Add(tmpAsset);
                    }
                }
            }
            return theList;
        }

        public static int GetUserGoldCount(string username)
        {
            List<Gold> lst = GetAllUserGold(username);
            return lst.Count;
        }

        public static int GetUserCryptoCount(string username)
        {
            List<Crypto> lst = GetAllUserCrypto(username);
            return lst.Count;
        }

        public static int GetUserRealEstateCount(string username)
        {
            List<RealEstate> lst = GetAllUserRealEstate(username);
            return lst.Count;
        }

        public static int GetUserStockCount(string username)
        {
            List<Stock> lst = GetAllUserStock(username);
            return lst.Count;
        }
    }
}