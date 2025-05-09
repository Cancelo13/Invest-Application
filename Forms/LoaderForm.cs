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
                this.Hide();
                new MainForm(user).Show();
            }
        }
    }
}