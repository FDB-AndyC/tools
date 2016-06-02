namespace VisionAddressTool_fw35
{
    using System;
    using System.Windows.Forms;
    using VisionAddressTool.Model;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new DataService()));
        }
    }
}
