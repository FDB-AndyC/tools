// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisionAddressTool
{
    using System;
    using System.Windows.Forms;

    using VisionAddressTool.Model;

    using VisionAddressTool_fw35;

    public static class Program
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
