// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryForm.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the QueryForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Forms
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Windows.Forms;

    using FDB.VisionQueryTool.Factories;
    using FDB.VisionQueryTool.Model;

    public partial class QueryForm : Form
    {
        private readonly IDataService dataService;
        private bool forceClose;

        public QueryForm(IDataService dataService)
        {
            this.dataService = dataService;
            this.InitializeComponent();
        }

        private void QueryFormClosing(object sender, FormClosingEventArgs e)
        {
            // ReSharper disable once AssignmentInConditionalExpression
            if (e.Cancel = !this.forceClose)
            {
                Debug.WriteLine("Hide");
                this.Hide();
            }
        }

        public void ForceClose()
        {
            Debug.WriteLine("Forcing close");
            this.forceClose = true;
            this.Close();
        }

        private void ExecuteButtonClick(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var results = this.dataService.Execute(this.queryTextBox.Text);

                ResultsFormFactory.Generate(this, results);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "SQL error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void QueryTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.ExecuteButtonClick(this.executeButton, new EventArgs());
            }
        }
    }
}
