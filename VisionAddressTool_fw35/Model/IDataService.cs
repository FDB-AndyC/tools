namespace VisionAddressTool.Model
{
    using System;

    public interface IDataService
    {
        void GetData(int patientId, Action<QueryResults, Exception> callback);
    }
}
