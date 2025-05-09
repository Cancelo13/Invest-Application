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

        private async void LoaderForm_Load(object sender, EventArgs e)
        {
            AppPaths.EnsureDataStructure();
            string filePath = AppPaths.GetLoginStateFile();

            User? user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath).Trim();

                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        user = JsonSerializer.Deserialize<User>(json);
                    }
                    catch (JsonException)
                    {
                        File.WriteAllText(AppPaths.GetLoginStateFile(), "");
                        user = null;
                    }
                }
            }
            await Task.Delay(500);
            if (user == null)
            {
                this.Hide();
                new LoginRegisterForm().Show();
            }
            else
            {
                this.Hide();
                new MainForm().Show();
            }
        }
    }
}