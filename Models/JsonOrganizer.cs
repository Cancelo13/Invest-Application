using System.Text.Json;

namespace Invest_Application
{
    public class JsonOrganizer
    {

        public static void SaveLogin(User user)
        {
            string saveFile = AppPaths.GetLoginStateFile();
            string json = JsonSerializer.Serialize(user);
            File.WriteAllText(saveFile, json);
        }

        public static User? GetUserFromDB(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            string json = File.ReadAllText(filePath).Trim();
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    return JsonSerializer.Deserialize<User>(json);
                }
                catch (JsonException)
                {

                }
            }
            return null;
        }

        public static Gold? GetGoldFromDB(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            string json = File.ReadAllText(filePath).Trim();
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    return JsonSerializer.Deserialize<Gold>(json);
                }
                catch (JsonException)
                {

                }
            }
            return null;
        }

        public static Crypto? GetCryptoFromDB(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            string json = File.ReadAllText(filePath).Trim();
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    return JsonSerializer.Deserialize<Crypto>(json);
                }
                catch (JsonException)
                {

                }
            }
            return null;
        }

        public static RealEstate? GetRealEstateFromDB(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            string json = File.ReadAllText(filePath).Trim();
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    return JsonSerializer.Deserialize<RealEstate>(json);
                }
                catch (JsonException)
                {

                }
            }
            return null;
        }

        public static Stock? GetStockFromDB(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            string json = File.ReadAllText(filePath).Trim();
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    return JsonSerializer.Deserialize<Stock>(json);
                }
                catch (JsonException)
                {

                }
            }
            return null;
        }


    }
}
