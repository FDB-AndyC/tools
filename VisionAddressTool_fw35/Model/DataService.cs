namespace VisionAddressTool.Model
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
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        private DataSet dataSet;

        private int cachedPatientId = InvalidPatientId;

        private bool IsConnected => this.connection != null;

        public void GetData(int patientId, Action<QueryResults, Exception> callback)
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
            sb.Append("p.entity_id, p.surname, p.forename1, p.nhs_no, p.sex as sexcode, p.dob, p.title, p.reg_gp, p.usual_gp ");
            sb.Append("FROM patient AS p ");

            sb.Append($"WHERE p.entity_id = {this.cachedPatientId}");

            return this.ProcessData(sb.ToString());
        }

        private string GetEthnicityOutput()
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("eth.read_term AS ethnicity ");
            sb.Append("FROM ethnicity AS eth ");

            sb.Append($"WHERE eth.master_id = {this.cachedPatientId}");

            return this.ProcessData(sb.ToString());
        }

        private string GetAddressOutput()
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("add.house_name, add.house_no, add.road_name, add.local_name, add.town_name, add.county_nam, add.postcode ");
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

            this.command = new OleDbCommand { CommandType = CommandType.Text, Connection = this.connection };
            this.adapter = new OleDbDataAdapter { SelectCommand = this.command };
            this.dataSet = new DataSet();
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
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;
            this.dataSet = new DataSet();

            this.adapter.Fill(this.dataSet);

            return CsvDataConverter.ToCsv(this.dataSet.Tables[0]);
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

            if (this.adapter != null)
            {
                try
                {
                    this.adapter.Dispose();
                }
                catch (Exception)
                {
                }

                this.adapter = null;
            }

            if (this.command != null)
            {
                try
                {
                    this.command.Dispose();
                }
                catch (Exception)
                {
                }

                this.command = null;
            }

            if (this.dataSet != null)
            {
                try
                {
                    this.dataSet.Dispose();
                }
                catch (Exception)
                {
                }

                this.dataSet = null;
            }
        }
    }
}