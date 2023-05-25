using System;
using System.Windows.Forms;

namespace DNS_Swapper
{
    public partial class About : Form
    {
        public About(string AppVersion)
        {
            InitializeComponent();
            CenterToScreen();
            version.Text = AppVersion;
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void OpenLicenseFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
