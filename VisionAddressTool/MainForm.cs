// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the MainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisionAddressTool
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using VisionAddressTool.Model;

    public partial class MainForm : Form
    {
        private readonly IDataService _dataService;

        private int PatientId => int.Parse(this.PatientIdTextBox.Text);

        public MainForm(IDataService dataService)
        {
            this._dataService = dataService;
            this.InitializeComponent();
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var start = DateTime.UtcNow;

            this.ExecuteQuery();

            var epoch = DateTime.UtcNow - start;
            this.AppendOutput($"Query({this.PatientId}) took {epoch.TotalMilliseconds}ms");
            this.Cursor = Cursors.Default;
        }

        private void ExecuteQuery()
        {
            this._dataService.GetData(
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

        private void PatientIdTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var me = sender as TextBox;
            int value;
            e.Cancel = !int.TryParse(me?.Text, out value);
            this.QueryButton.Enabled = !e.Cancel;
        }
    }
}
