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
            MainMenu menu = new MainMenu();
            Application.Run();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            // Cleanup
        }
    }
}
