// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultsForm.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the ResultsForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Forms
{
    using System.Data;
    using System.Windows.Forms;

    public partial class ResultsForm : Form
    {
        private readonly DataTable data;

        public ResultsForm(DataTable dataTable)
        {
            this.data = dataTable;
            this.InitializeComponent();
            this.resultsGridView.AutoGenerateColumns = true;
        }

        private void PopulateGrid()
        {
            this.resultsBindingSource.DataSource = this.data;
        }

        private void ResultsFormLoad(object sender, System.EventArgs e)
        {
            this.PopulateGrid();
        }
    }
}
