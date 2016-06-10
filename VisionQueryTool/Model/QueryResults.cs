// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryResults.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the QueryResults type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FDB.VisionQueryTool.Model
{
    public class QueryResults
    {
        public string PatientOutput { get; set; }

        public string AddressOutput { get; set; }

        public string EthnicityOutput { get; set; }

        public string JoinedOutput { get; set; }
    }
}