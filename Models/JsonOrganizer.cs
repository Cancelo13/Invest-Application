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
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException)
            {

            }
            return null;
        }
    }
}
