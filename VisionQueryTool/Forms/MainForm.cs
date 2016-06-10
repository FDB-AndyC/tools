// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the MainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Forms
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    using FDB.VisionQueryTool.Factories;
    using FDB.VisionQueryTool.Model;

    public partial class MainForm : Form
    {
        private readonly IDataService dataService;

        private QueryForm queryForm;

        private int PatientId => int.Parse(this.PatientIdTextBox.Text);

        public MainForm(IDataService dataService)
        {
            this.dataService = dataService;
            this.InitializeComponent();
            this.queryForm = new QueryForm(dataService);
        }

        private void ExecuteQuery()
        {
            this.dataService.GetPatientData(
                this.PatientId,
                (results, error) =>
                {
                    if (results != null)
                    {
                        this.PopulateResults(results);
                    }

                    this.OutputTextBox.ForeColor = error == null ? DefaultForeColor : Color.Red;
                    if (error != null)
                    {
                        this.AppendOutput(error.Message);
                    }
                });
        }

        private void PopulateResults(QueryResults results)
        {
            this.ClearOutput();

            this.AppendOutput("------------- Address -------------");
            this.AppendOutput(results.AddressOutput);
            this.AppendOutput("-----------------------------------");
            this.AppendOutput(null);

            this.AppendOutput("------------ Ethnicity ------------");
            this.AppendOutput(results.EthnicityOutput);
            this.AppendOutput("-----------------------------------");
            this.AppendOutput(null);

            this.AppendOutput("------------- Patient -------------");
            this.AppendOutput(results.PatientOutput);
            this.AppendOutput("-----------------------------------");
            this.AppendOutput(null);

            this.AppendOutput("------------- Joined --------------");
            this.AppendOutput(results.JoinedOutput);
            this.AppendOutput("-----------------------------------");
        }

        private void ClearOutput()
        {
            this.OutputTextBox.Clear();
        }

        private void AppendOutput(string message)
        {
            if (!string.IsNullOrEmpty(this.OutputTextBox.Text))
            {
                this.OutputTextBox.AppendText(Environment.NewLine);
            }

            this.OutputTextBox.AppendText(message ?? string.Empty);
        }

        private void PatientIdTextBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var me = sender as TextBox;
            int value;
            e.Cancel = !int.TryParse(me?.Text, out value);
            this.QueryButton.Enabled = !e.Cancel;
        }

        private void QueryButtonClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var start = DateTime.UtcNow;

            this.ExecuteQuery();

            var epoch = DateTime.UtcNow - start;
            this.AppendOutput($"Query({this.PatientId}) took {epoch.TotalMilliseconds}ms");
            this.Cursor = Cursors.Default;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            this.queryForm.ForceClose();
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("Application exiting");
            Application.Exit();
        }

        private void QueryToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.queryForm.Show(this);
        }

        private void DummyDataToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dummyService = new DummyDataService();
            var dummyResults = dummyService.Execute("blah");

            ResultsFormFactory.Generate(this, dummyResults);
        }
    }
}
