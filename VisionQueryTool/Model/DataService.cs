// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataService.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Model
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Text;

    public sealed class DataService : IDataService, IDisposable
    {
        private const string VisionConnectionString = "provider=VisOLEDB";
        private const int InvalidPatientId = -1;

        private OleDbConnection connection;

        private int cachedPatientId = InvalidPatientId;

        private bool IsConnected => this.connection != null;

        public void GetPatientData(int patientId, Action<QueryResults, Exception> callback)
        {
            QueryResults results = null;
            Exception error = null;

            try
            {
                this.cachedPatientId = patientId;
                this.EnsureConnected();
                results = new QueryResults
                {
                    AddressOutput = this.GetAddressOutput(),
                    EthnicityOutput = this.GetEthnicityOutput(),
                    PatientOutput = this.GetPatientOutput(),
                    JoinedOutput = this.GetJoinedOutput()
                };
            }
            catch (Exception x)
            {
                error = x;
                this.Disconnect();
            }

            callback(results, error);
        }

        private string GetPatientOutput()
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("* ");
            sb.Append("FROM patient AS p ");
            sb.Append($"WHERE p.entity_id = {this.cachedPatientId}");

            return this.ProcessData(sb.ToString());
        }

        private string GetEthnicityOutput()
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("* ");
            sb.Append("FROM ethnicity AS eth ");
            sb.Append($"WHERE eth.master_id = {this.cachedPatientId}");

            return this.ProcessData(sb.ToString());
        }

        private string GetAddressOutput()
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("* ");
            sb.Append("FROM newadd AS add ");
            sb.Append($"WHERE add.master_id = {this.cachedPatientId}");

            return this.ProcessData(sb.ToString());
        }

        private string GetJoinedOutput()
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("add.house_name, add.house_no, add.road_name, add.local_name, add.town_name, add.county_nam, add.postcode, ");
            sb.Append("p.entity_id, p.surname, p.forename1, p.nhs_no, p.sex as sexcode, p.dob, p.title, p.reg_gp, p.usual_gp, eth.read_term AS ethnicity ");
            sb.Append("FROM patient AS p ");
            sb.Append("INNER JOIN newadd AS add ON add.master_id = p.entity_id ");
            sb.Append("LEFT JOIN ethnicity AS eth ON eth.master_id = p.entity_id AND eth.auditflag = 1 ");
            sb.Append($"WHERE p.auditflag = 1 AND add.auditflag = 1 AND add.master_ty = 1 AND p.entity_id = {this.cachedPatientId}");

            return this.ProcessData(sb.ToString());
        }

        private void Connect()
        {
            this.connection = new OleDbConnection { ConnectionString = VisionConnectionString };
            this.connection.Open();
        }

        private void EnsureConnected()
        {
            if (!this.IsConnected)
            {
                this.Connect();
            }
        }

        private string ProcessData(string sql)
        {
            return CsvDataConverter.ToCsv(this.Execute(sql).Tables[0]);
        }

        public DataSet Execute(string sql)
        {
            var data = new DataSet();

            this.EnsureConnected();

            using (var command = new OleDbCommand { CommandType = CommandType.Text, Connection = this.connection, CommandText = sql })
            using (var adapter = new OleDbDataAdapter { SelectCommand = command })
            {
                adapter.Fill(data);
            }

            return data;
        }

        public void Dispose()
        {
            this.Disconnect();
        }

        private void Disconnect()
        {
            if (this.connection != null)
            {
                try
                {
                    this.connection.Close();
                    this.connection.Dispose();
                }
                catch (Exception)
                {
                }

                this.connection = null;
            }
        }
    }
}