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
    using System.Windows.Forms;

    using FDB.VisionQueryTool.Factories;
    using FDB.VisionQueryTool.Model;

    public partial class QueryForm : Form
    {
        private readonly IDataService dataService;

        private IDataService dummyDataService;

        private IDataService DummyDataService => this.dummyDataService ?? (this.dummyDataService = new DummyDataService());

        public QueryForm(IDataService dataService)
        {
            this.dataService = dataService;
            this.InitializeComponent();
        }

        private void ExecuteButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.BeginLongWait();
                var results = this.dataService.Execute(this.queryTextBox.Text);

                ResultsFormFactory.Generate(this, results);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "SQL error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.EndLongWait();
            }
        }

        private void QueryTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    this.ExecuteButtonClick(this.executeButton, new EventArgs());
                    break;

                case Keys.F10:
                    ResultsFormFactory.Generate(this, this.DummyDataService.Execute(null));
                    break;

                case Keys.A:
                    if (e.Control)
                    {
                        this.queryTextBox.SelectAll();
                    }
                    break;
            }
        }

        private void CloseMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatientMenuItemClick(object sender, EventArgs e)
        {
            this.ReplaceSelectedSql(VisionSqlGenerator.GetPatientSql());
        }

        private void EthnicityMenuItemClick(object sender, EventArgs e)
        {
            this.ReplaceSelectedSql(VisionSqlGenerator.GetEthnicitySql());
        }

        private void AddressMenuItemClick(object sender, EventArgs e)
        {
            this.ReplaceSelectedSql(VisionSqlGenerator.GetAddressSql());
        }

        private void JoinedMenuItemClick(object sender, EventArgs e)
        {
            this.ReplaceSelectedSql(VisionSqlGenerator.GetSidebarJoinedAddressDetailsSql());
        }

        private void ReferralsMenuItemClick(object sender, EventArgs e)
        {
            this.ReplaceSelectedSql(VisionSqlGenerator.GetReferralsSql());
        }

        private void ReplaceSelectedSql(string sql)
        {
            this.queryTextBox.SelectedText = sql;
        }

        private void QueryFormLoad(object sender, EventArgs e)
        {
            this.queryTextBox.SelectAll();
            this.ReferralsMenuItemClick(this.queryTextBox, new EventArgs());
        }

        private void QueryFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BeginLongWait()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.queryTextBox.Enabled = this.executeButton.Enabled = false;
        }

        private void EndLongWait()
        {
            this.queryTextBox.Enabled = this.executeButton.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
    }
}
