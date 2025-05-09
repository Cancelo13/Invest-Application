using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            await Task.Delay(2000); // Simulate loading for 2 seconds
            this.Hide();
            new LoginRegisterForm().Show();
        }
    }
}