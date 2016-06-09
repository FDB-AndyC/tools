// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvDataConverter.cs" company="First Databank">
//   Copyright (c) 2016 First Databank. All rights reserved.
// </copyright>
// <summary>
//   Defines the CsvDataConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisionAddressTool.Model
{
    using System.Data;
    using System.Text;

    public class CsvDataConverter
    {
        public static string ToCsv(DataTable table)
        {
            var sb = new StringBuilder();

            foreach (DataColumn column in table.Columns)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",");
                }

                sb.Append(GetQuotedText(column.ColumnName));
            }

            if (table.Rows?.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var isCommaNeeded = false;

                    sb.AppendLine();
                    foreach (DataColumn column in table.Columns)
                    {
                        if (isCommaNeeded)
                        {
                            sb.Append(",");
                        }
                        else
                        {
                            isCommaNeeded = true;
                        }

                        sb.Append(GetQuotedText(row[column.ColumnName]?.ToString() ?? string.Empty));
                    }
                }
            }
            else
            {
                sb.AppendLine();
                sb.Append("(no rows)");
            }

            return sb.ToString();
        }

        private static string GetQuotedText(string text)
        {
            return text == null ? "(NULL)" : $"\"{text}\"";
        }
    }
}
