// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyDataService.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the DummyDataService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Model
{
    using System;
    using System.Data;

    public class DummyDataService : IDataService
    {
        public void GetPatientData(int patientId, Action<QueryResults, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public DataSet Execute(string sql)
        {
            var dummyData = new DataSet();

            FillDataSet(ref dummyData);

            return dummyData;
        }

        private static void FillDataSet(ref DataSet dataSet)
        {
            dataSet.Tables.Add(CreateDummyTable());
            dataSet.Tables.Add(CreateDummyTable());
            dataSet.Tables.Add(CreateDummyTable());
        }

        private static DataTable CreateDummyTable()
        {
            var table = new DataTable();

            table.Columns.AddRange(new[]
                                       {
                                           new DataColumn("Column 1"), 
                                           new DataColumn("Column 2"), 
                                           new DataColumn("Column 3"), 
                                           new DataColumn("Column 4"), 
                                           new DataColumn("Column 5"), 
                                           new DataColumn("Column 6")
                                       });

            for (var row = 1; row <= 10; ++row)
            {
                var rowData = table.NewRow();
                for (var column = 0; column < 6; ++column)
                {
                    rowData[column] = $"Data {row}.{column+1}";
                }
                table.Rows.Add(rowData);
            }

            return table;
        }
    }
}
