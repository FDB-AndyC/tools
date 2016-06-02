namespace VisionAddressTool.Design
{
    using System;
    using Model;

    public class DesignDataService : IDataService
    {
        public void GetData(int patientId, Action<QueryResults, Exception> callback)
        {
            // Use this to create design time data
            var results = new QueryResults { AddressOutput = "(Address output here)", EthnicityOutput = "(Ethnicity output here)", PatientOutput = "(patient output here)"};
            callback(results, null);
        }
    }
}