using System;
using System.Windows.Forms;

namespace DNS_Swapper
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void openLicenseFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
