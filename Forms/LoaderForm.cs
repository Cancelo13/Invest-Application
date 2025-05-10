using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invest_Application;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvestApp.Forms
{
    public partial class LoaderForm : Form
    {
        public LoaderForm()
        {
            InitializeComponent();
            this.Load += LoaderForm_Load;
        }
        private static Random _random = new Random();
        private static DateTime RandomDate()
        {
            // Generate a date between 5 years ago and today
            DateTime start = DateTime.Now.AddYears(-5);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_random.Next(range));
        }

        private static string GetRandomGoldName()
        {
            string[] names = { "Gold Bar", "Gold Coin", "Gold Nugget", "Golden Ring" };
            return names[_random.Next(names.Length)];
        }

        private static string GetRandomStockName()
        {
            string[] names = { "AAPL", "GOOGL", "TSLA", "MSFT" };
            return names[_random.Next(names.Length)];
        }

        private static string GetRandomCryptoName()
        {
            string[] names = { "Bitcoin", "Ethereum", "Solana", "Dogecoin" };
            return names[_random.Next(names.Length)];
        }

        private static string GetRandomRealEstateName()
        {
            string[] names = { "Villa", "Apartment", "Studio", "Townhouse" };
            return names[_random.Next(names.Length)];
        }
        public static Gold GenerateRandomGold()
        {
            return new Gold(
                name: GetRandomGoldName(),
                quantity: _random.Next(1, 5),
                purchasePrice: _random.Next(500, 1000),
                purchaseDate: RandomDate()
            );
        }

        public static Stock GenerateRandomStock()
        {
            return new Stock(
                name: GetRandomStockName(),
                quantity: _random.Next(1, 50),
                purchasePrice: _random.Next(100, 400),
                purchaseDate: RandomDate()
            );
        }

        public static Crypto GenerateRandomCrypto()
        {
            return new Crypto(
                name: GetRandomCryptoName(),
                quantity: _random.Next(1, 3),
                purchasePrice: _random.Next(20_000, 40_000),
                purchaseDate: RandomDate()
            );
        }

        public static RealEstate GenerateRandomRealEstate()
        {
            return new RealEstate(
                name: GetRandomRealEstateName(),
                quantity: 1,
                purchasePrice: _random.Next(100_000, 400_000),
                purchaseDate: RandomDate()
            );
        }

        public void dummyData(string username)
        {
            for (int i = _random.Next(1, 5); i >= 1; i--)
            {
                DatabaseOrganizer.SaveUserGold(GenerateRandomGold(), username);
            }
            for (int i = _random.Next(1, 5); i >= 1; i--)
            {
                DatabaseOrganizer.SaveUserStock(GenerateRandomStock(), username);
            }
            for (int i = _random.Next(1, 5); i >= 1; i--)
            {
                DatabaseOrganizer.SaveUserCrypto(GenerateRandomCrypto(), username);
            }
            for (int i = _random.Next(1, 5); i >= 1; i--)
            {
                DatabaseOrganizer.SaveUserRealEstate(GenerateRandomRealEstate(), username);
            }
        }

        private async void LoaderForm_Load(object sender, EventArgs e)
        {
            AppPaths.EnsureDataStructure();
            User? user = JsonOrganizer.GetUserFromDB(AppPaths.GetLoginStateFile());
            await Task.Delay(500);
            if (user == null)
            {
                File.WriteAllText(AppPaths.GetLoginStateFile(), "");
                this.Hide();
                new LoginRegisterForm().Show();
            }
            else
            {
                dummyData(user.Username);
                this.Hide();
                new MainForm(user).Show();
            }
        }
    }
}