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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            // Cleanup
        }
    }
}
