using System;
using System.Management;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkManagement.setDNS(args[0], args[1]);
        }

        public class NetworkManagement
        {
            // Method to prepare the WMI query connection options.
            public static ConnectionOptions PrepareOptions()
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = ImpersonationLevel.Impersonate;
                options.Authentication = AuthenticationLevel.Default;
                options.EnablePrivileges = true;
                return options;
            }

            // Method to prepare WMI query management scope.
            public static ManagementScope PrepareScope(string machineName, ConnectionOptions options, string path)
            {
                ManagementScope scope = new ManagementScope();
                scope.Path = new ManagementPath(@"\\" + machineName + path);
                scope.Options = options;
                scope.Connect();
                return scope;
            }

            /// <summary>
            /// Set's the DNS Server of the local machine
            /// </summary>
            /// <param name="NIC">NIC address</param>
            /// <param name="DNS">DNS server address</param>
            /// <remarks>Requires a reference to the System.Management namespace</remarks>
            public static void setDNS(string NIC, string DNS)
            {
                ConnectionOptions options = PrepareOptions();
                ManagementScope scope = PrepareScope(Environment.MachineName, options, @"\root\CIMV2");
                ManagementPath managementPath = new ManagementPath("Win32_NetworkAdapterConfiguration");
                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                ManagementClass mc = new ManagementClass(scope, managementPath, objectGetOptions);
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        if (mo["Caption"].ToString().Contains(NIC))
                        {
                            try
                            {
                                ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
                                newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                                ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                            }
                            catch (Exception e)
                            {
                                throw;
                            }
                        }
                    }
                }
            }
        }
    }

}
