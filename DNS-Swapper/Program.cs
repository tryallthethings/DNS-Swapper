using System;
using System.Windows.Forms;


namespace DNS_Swapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //NBug Crash Handling
            //NBug.Settings.ReleaseMode = false;
            NBug.Settings.HandleProcessCorruptedStateExceptions = true;
            NBug.Settings.MiniDumpType = NBug.Enums.MiniDumpType.Normal;
            NBug.Settings.StopReportingAfter = 365;
            NBug.Settings.WriteLogToDisk = true;
            NBug.Settings.ExitApplicationImmediately = true;
            NBug.Settings.SleepBeforeSend = 5;
            NBug.Settings.StoragePath = "WindowsTemp";
            
            AppDomain.CurrentDomain.UnhandledException += NBug.Handler.UnhandledException;
            Application.ThreadException += NBug.Handler.ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            // Cleanup
        }
    }
}
