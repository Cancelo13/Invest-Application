using System;
using System.IO;
using System.Text.Json;

namespace InvestApp.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            Name = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            ID = GenerateID();
        }

        private static string GenerateID(){
            string newID = string.Empty;
            // implement ID generation after adding DB files to iterate through and set the first free ID 
            return newID;
        }

        public void Save(string path)
        {
            var jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(path, jsonString);
        }

        public static User Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("User data file not found");

            var jsonString = File.ReadAllText(path);
            var user = JsonSerializer.Deserialize<User>(jsonString);
            
            return user ?? throw new Exception("Failed to deserialize user data");
        }
    }
}