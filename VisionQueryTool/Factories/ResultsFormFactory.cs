// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultsFormFactory.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the ResultsFormFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Factories
{
    using System.Data;
    using System.Windows.Forms;

    using Forms;

    public static class ResultsFormFactory
    {
        public static void Generate(IWin32Window owner, DataSet data)
        {
            foreach (DataTable table in data.Tables)
            {
                var form = new ResultsForm(table);
                form.Show();
            }
        }
    }
}
