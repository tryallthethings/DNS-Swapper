using NBug.Events;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace DNS_Swapper
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            //add handler on application load
            NBug.Settings.CustomSubmissionEvent += Settings_CustomSubmissionEvent;

            // Custom Submission Event handler
            void Settings_CustomSubmissionEvent(object sender, CustomSubmissionEventArgs e)
            {
                //your sumbmission code here...
                MessageBox.Show(e.FileName.ToString());
                // 
                // var url = "mailto:dns-swapper@fire.fundersclub.com?subject=DNS-Swapper&body=crash";
                // Process.Start(url);
                //tell NBug if submission was successfull or not
                e.Result = true;
            }


            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            
            // Load network interfaces
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    if (!NIC_select.Items.Cast<string>().Contains(nic.Description))
                    {
                        NIC_select.Items.Add(nic.Description);
                    }
                }
            }

            // Load previously saved user settings
            NIC_select.SelectedItem = Properties.Settings.Default.NIC;
            DNS_1.Text = Properties.Settings.Default.DNS_1;
            DNS_2.Text = Properties.Settings.Default.DNS_2;

            if (NIC_select.SelectedItem != null && !string.IsNullOrEmpty(DNS_1.Text) && !string.IsNullOrEmpty(DNS_2.Text))
            {
                if (NetworkManagement.getDNS().Equals(IPAddress.Parse(DNS_1.Text)))
                {
                    taskBarIcon.Icon = Resource1.icon_red;
                    changeToggleBtnPosition(false);
                }
                else if (NetworkManagement.getDNS().Equals(IPAddress.Parse(DNS_2.Text)))
                {
                    taskBarIcon.Icon = Resource1.icon_blue;
                    changeToggleBtnPosition(true);
                }
            }
        }

        private void changeToggleBtnPosition(bool state)
        {
            toggle_DNS.CheckedChanged -= new EventHandler(toggle_DNS_CheckedChanged);
            toggle_DNS.Checked = state;
            toggle_DNS.CheckedChanged += new EventHandler(toggle_DNS_CheckedChanged);
        }

        private void JumpOnDot(object sender, KeyEventArgs e)
        {
            var mb = (MaskedTextBox)sender;
            if ((new[] { Keys.Oemcomma, Keys.Decimal, Keys.OemPeriod }.Contains(e.KeyCode)))
            {
                if (mb.SelectionStart <= 3)
                    mb.SelectionStart = 4;
                else if (mb.SelectionStart <= 7)
                    mb.SelectionStart = 8;
                else if (mb.SelectionStart <= 10)
                    mb.SelectionStart = 12;
            }
        }

        private void ValidateIP(object sender, CancelEventArgs e)
        {
            var mb = (MaskedTextBox)sender;
            string ip = Regex.Replace(mb.Text, @"\s+", "");
            if (ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
            {
                IPAddress ipAddr;
                if (IPAddress.TryParse(ip, out ipAddr))
                {
                    // valid IP
                    IPerrorProvider.SetError(mb, String.Empty);
                }
                else
                {
                    // invalid IP
                    IPerrorProvider.SetError(mb, "Invalid IP entered");
                }
            }
            else
            {
                // invalid IP
                IPerrorProvider.SetError(mb, "Invalid IP entered");
            }
        }

        private void menuStrip1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void taskBarIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void SwapDNS()
        {
            if (NIC_select.SelectedIndex != -1 && string.IsNullOrEmpty(IPerrorProvider.GetError(DNS_1)) && string.IsNullOrEmpty(IPerrorProvider.GetError(DNS_2)))
            {
                // Get current DNS server

                IPAddress DNS_servers = NetworkManagement.getDNS();
                if (DNS_servers.Equals(IPAddress.Parse(Regex.Replace(DNS_1.Text, @"\s+", ""))))
                {
                    callSwapDNS(NIC_select.SelectedItem.ToString(), Regex.Replace(DNS_2.Text, @"\s+", ""));
                    IPAddress ip = NetworkManagement.getDNS();
                    if (ip.Equals(IPAddress.Parse(Regex.Replace(DNS_2.Text, @"\s+", ""))))
                    {
                        taskBarIcon.Icon = Resource1.icon_blue;
                        Icon = Resource1.icon_blue;
                        changeToggleBtnPosition(true);
                    }
                    else
                    {
                        taskBarIcon.Icon = Resource1.error;
                    }

                }
                else if (DNS_servers.Equals(IPAddress.Parse(Regex.Replace(DNS_2.Text, @"\s+", ""))))
                {
                    callSwapDNS(NIC_select.SelectedItem.ToString(), Regex.Replace(DNS_1.Text, @"\s+", ""));
                    
                    if (NetworkManagement.getDNS().Equals(IPAddress.Parse(Regex.Replace(DNS_1.Text, @"\s+", ""))))
                    {
                        taskBarIcon.Icon = Resource1.icon_red;
                        Icon = Resource1.icon_red;
                        changeToggleBtnPosition(false);
                    }
                    else
                    {
                        taskBarIcon.Icon = Resource1.error;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a network interface and enter 2 valid IPs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveSettings();
            Application.Exit();
        }

        private void toggle_DNS_CheckedChanged(object sender, EventArgs e)
        {
            SwapDNS();
        }

        private void callSwapDNS(string NIC, string DNS)
        {
            const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
            ProcessStartInfo info = new ProcessStartInfo(@"swap.exe");
            string wrapped = string.Format(@"""{0}"" ""{1}""", NIC, DNS);
            info.Arguments = wrapped;
            info.UseShellExecute = true;
            info.Verb = "runas";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(info);
                Thread.Sleep(500);
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_CANCELLED)
                    MessageBox.Show("Why you no select Yes?");
                else
                    throw;
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NIC_select.SelectedIndex = -1;
            DNS_1.Text = "";
            DNS_2.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings();
            Application.Exit();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.DNS_1 = DNS_1.Text;
            Properties.Settings.Default.DNS_2 = DNS_2.Text;
            if (NIC_select.SelectedItem != null)
            {
                Properties.Settings.Default.NIC = NIC_select.SelectedItem.ToString();
            }
            else
            {
                Properties.Settings.Default.NIC = "";
            }
            Properties.Settings.Default.Save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void taskBarIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SwapDNS();
            }
        }
    }
}
