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

        public static T? GetAssetFromDB<T>(string filePath) where T : Asset
        {
            if (!File.Exists(filePath)) return null;

            string json = File.ReadAllText(filePath).Trim();
            if (string.IsNullOrWhiteSpace(json)) return null;

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize to a temporary object to get the basic properties
                using JsonDocument document = JsonDocument.Parse(json);
                var root = document.RootElement;

                // Extract the properties
                string name = root.GetProperty("Name").GetString() ?? "";
                int quantity = root.GetProperty("Quantity").GetInt32();
                decimal purchasePrice = root.GetProperty("PurchasePrice").GetDecimal();
                DateTime purchaseDate = root.GetProperty("PurchaseDate").GetDateTime();

                // Create the concrete type based on T
                if (typeof(T) == typeof(Gold))
                    return (T)(Asset)new Gold(name, quantity, purchasePrice, purchaseDate);
                else if (typeof(T) == typeof(Stock))
                    return (T)(Asset)new Stock(name, quantity, purchasePrice, purchaseDate);
                else if (typeof(T) == typeof(Crypto))
                    return (T)(Asset)new Crypto(name, quantity, purchasePrice, purchaseDate);
                else if (typeof(T) == typeof(RealEstate))
                    return (T)(Asset)new RealEstate(name, quantity, purchasePrice, purchaseDate);
                else
                    throw new ArgumentException($"Unsupported asset type: {typeof(T).Name}");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
