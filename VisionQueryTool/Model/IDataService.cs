// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataService.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the IDataService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Model
{
    using System;
    using System.Data;

    public interface IDataService
    {
        void GetPatientData(int patientId, Action<QueryResults, Exception> callback);

        DataSet Execute(string sql);
    }
}
