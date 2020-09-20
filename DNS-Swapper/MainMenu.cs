using DNS_Swapper.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
        private readonly string Version = "1.5";

        public string version
        {
            get { return Version; }
        }

        public MainMenu()
        {
            InitializeComponent();

            // Upgrade settings file (user.config in %LOCALAPPDATA%\DNS_Swapper from previous version
            Settings.Default.Upgrade();

            // Load network interfaces
            scanNICs();

            // Load previously saved user settings
            NIC_select.SelectedIndex = NIC_select.FindStringExact(Settings.Default.NIC);

            // Remove blank in IP-Address
            string DNS1_var = Settings.Default.DNS_1.Replace(" ", string.Empty);
            string DNS2_var = Settings.Default.DNS_2.Replace(" ", string.Empty);
            // Variables used for validated IP-Addresses
            IPAddress DNS1_IP = new IPAddress(new byte[] { 127, 0, 0, 1 });
            IPAddress DNS2_IP = new IPAddress(new byte[] { 127, 0, 0, 1 });

            if (string.IsNullOrEmpty(DNS1_var) || string.IsNullOrEmpty(DNS2_var))
            {
                // No DNS servers configured
                MessageBox.Show("Tool not configured yet", "DNS-Swapper configuration missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
            }
            else
            {
                // Validate configuration
                if ((IPAddress.TryParse(DNS1_var, out DNS1_IP)) && (IPAddress.TryParse(DNS2_var, out DNS2_IP)))
                {
                    // DNS server IPs valid
                    // Set Loaded variables into settings text boxes
                    DNS_1.Text = DNS1_var;
                    DNS_2.Text = DNS2_var;

                    // Set taskbar icon color
                    if (NIC_select.SelectedItem != null && !string.IsNullOrEmpty(DNS_1.Text) && !string.IsNullOrEmpty(DNS_2.Text))
                    {
                        if (NetworkManagement.getDNS(NIC_select.SelectedItem.ToString()).Equals(DNS1_IP))
                        {
                            taskBarIcon.Icon = Resource1.icon_red;
                            changeToggleBtnPosition(false);
                        }
                        else if (NetworkManagement.getDNS(NIC_select.SelectedItem.ToString()).Equals(DNS2_IP))
                        {
                            taskBarIcon.Icon = Resource1.icon_blue;
                            changeToggleBtnPosition(true);
                        }
                    }
                }
                else
                {
                    // DNS server IP(s) invalid - display error message
                    MessageBox.Show("Invalid configuration detected. Resetting settings to default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetToolStripMenuItem_Click(null, null);
                    saveSettings();
                    Show();
                    WindowState = FormWindowState.Normal;
                    ShowInTaskbar = true;
                }
            }
        }

        private void changeToggleBtnPosition(bool state)
        {
            toggle_DNS.CheckedChanged -= toggle_DNS_CheckedChanged;
            toggle_DNS.Checked = state;
            toggle_DNS.CheckedChanged += toggle_DNS_CheckedChanged;
        }

        private static void JumpOnDot(object sender, KeyEventArgs e)
        {
            var mb = (MaskedTextBox)sender;
            if ((new[] { Keys.Oemcomma, Keys.Decimal, Keys.OemPeriod }.Contains(e.KeyCode)))
            {
                if (mb.SelectionStart <= 3)
                {
                    mb.SelectionStart = 4;
                }
                else if (mb.SelectionStart <= 7)
                {
                    mb.SelectionStart = 8;
                }
                else if (mb.SelectionStart <= 10)
                {
                    mb.SelectionStart = 12;
                }            }
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
            {
                Hide();
            }
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

                IPAddress DNS_servers = NetworkManagement.getDNS(NIC_select.SelectedItem.ToString());
                if (DNS_servers.Equals(IPAddress.Parse(Regex.Replace(DNS_1.Text, @"\s+", ""))))
                {
                    callSwapDNS(NIC_select.SelectedItem.ToString(), Regex.Replace(DNS_2.Text, @"\s+", ""));
                    IPAddress ip = NetworkManagement.getDNS(NIC_select.SelectedItem.ToString());
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

                    if (NetworkManagement.getDNS(NIC_select.SelectedItem.ToString()).Equals(IPAddress.Parse(Regex.Replace(DNS_1.Text, @"\s+", ""))))
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
                else
                {
                    MessageBox.Show("Couldn't find any of the given DNS servers configured on the selected network interface", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                NetworkManagement.FlushDNSCache();
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
            DisableControls(true);
            SwapDNS();
            DisableControls(false);
        }

        private void DisableControls(bool status)
        {
            if (status)
            {
                // Disable UI elements
                settingsGB.Enabled = false;
            }
            else
            {
                // Enable UI elements
                settingsGB.Enabled = true;
            }
        }

        private void callSwapDNS(string NIC, string DNS)
        {
            const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
            if (File.Exists(@"swap.exe"))
            {
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
                    {
                        MessageBox.Show("DNS-Swapper (swap.exe) requires elevated permissions to change your DNS-Server.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("swap.exe missing", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (DNS_1.Text == "..." && DNS_2.Text == "...")
            {
                Settings.Default.DNS_1 = "";
                Settings.Default.DNS_2 = "";
            }
            else
            {
                Settings.Default.DNS_1 = DNS_1.Text;
                Settings.Default.DNS_2 = DNS_2.Text;
            }
            if (NIC_select.SelectedItem != null)
            {
                ComboboxItem value = (ComboboxItem)NIC_select.SelectedItem;
                Settings.Default.NIC = value.Text;
            }
            else
            {
                Settings.Default.NIC = "";
            }
            Settings.Default.Save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            //RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, (int)Keys.F11);
        }

        private void taskBarIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SwapDNS();
            }
        }

        private void updateIP(object sender, EventArgs e)
        {
            bool IPv4IPfound = false;
            bool IPv6IPfound = false;
            bool IPv4GWfound = false;
            bool IPv6GWfound = false;

            ComboboxItem selectedNic = (ComboboxItem)NIC_select.SelectedItem;
            NetworkInterface nic = (NetworkInterface)selectedNic.Value;

                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            IPv4IPfound = true;
                            IPv4_Text.Text = ip.Address.ToString();
                            foreach (GatewayIPAddressInformation gwipv4 in nic.GetIPProperties().GatewayAddresses)
                            {
                                if (gwipv4.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    IPv4GWfound = true;
                                    IPv4_GW_Text.Text = gwipv4.Address.ToString();
                                }
                            }
                        }
                        else if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                        {
                            IPv6IPfound = true;
                            IPv6_Text.Text = ip.Address.ToString();
                            foreach (GatewayIPAddressInformation gwipv6 in nic.GetIPProperties().GatewayAddresses)
                            {
                                if (gwipv6.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                                {
                                    IPv6GWfound = true;
                                    IPv6_GW_Text.Text = gwipv6.Address.ToString();
                                }
                            }
                        }

            }
            if (!IPv4IPfound)
            {
                IPv4_Text.Text = "No IPv4 IP found";
            }
            if (!IPv6IPfound)
            {
                IPv6_Text.Text = "No IPv6 IP found";
            }
            if (!IPv4GWfound)
            {
                IPv4_GW_Text.Text = "No IPv4 Gateway found";
            }
            if (!IPv6GWfound)
            {
                IPv6_GW_Text.Text = "No IPv6 Gateway found";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show about form
            Form About = new About();
            About.ShowDialog();
        }

        private void ValidateIPField(object sender, EventArgs e)
        {
            Regex validIpV4AddressRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", RegexOptions.IgnoreCase);
            IPAddressControlLib.IPAddressControl IPvalidate = (IPAddressControlLib.IPAddressControl)sender;
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            string message = "";
            int VisibleTime = 1000;  //in milliseconds
            ToolTip tt = new ToolTip();
            if (IPvalidate.AnyBlank)
            {
                message = "Blank address fields found";
            }
            else if (!validIpV4AddressRegex.IsMatch(IPvalidate.Text.Trim()))
            {
                message = "Invalid IP address";
            }

            if (!string.IsNullOrEmpty(message))
            {
                tt.Show(message, IPvalidate, 0, -20, VisibleTime);
            }
        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            scanNICs();
        }

        private void scanNICs()
        {
            // Clear network interfaces if not empty already
            if (NIC_select.Items.Count > 0)
            {
                NIC_select.Items.Clear();
            }
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (activeNICsCB.Checked && nic.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }

                ComboboxItem item = new ComboboxItem();
                item.Text = nic.Description.ToString();
                item.Value = nic;

                NIC_select.Items.Add(item);

            }

            // Restore selected NIC from settings if saved
            if (!string.IsNullOrEmpty(Settings.Default.NIC))
            {
                NIC_select.SelectedIndex = NIC_select.FindStringExact(Settings.Default.NIC);
            }
        }

        private void activeNICsCB_CheckStateChanged(object sender, EventArgs e)
        {
            scanNICs();
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}