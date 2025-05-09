namespace Invest_Application
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            Name = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }
        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

    }
}
