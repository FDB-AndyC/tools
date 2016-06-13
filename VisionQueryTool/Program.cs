// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool
{
    using System;
    using System.Windows.Forms;

    using FDB.VisionQueryTool.Forms;
    using FDB.VisionQueryTool.Model;

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
            Application.Run(new QueryForm(new DataService()));
        }
    }
}
