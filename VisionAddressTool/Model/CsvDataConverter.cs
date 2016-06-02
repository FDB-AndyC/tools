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

            foreach (DataRow row in table.Rows)
            {
                var isCommandNeeded = false;

                foreach (DataColumn column in table.Columns)
                {
                    if (isCommandNeeded)
                    {
                        sb.Append(",");
                    }
                    else
                    {
                        isCommandNeeded = true;
                    }

                    sb.Append(GetQuotedText(row[column.ColumnName]?.ToString() ?? string.Empty));
                }
            }

            return sb.ToString();
        }

        private static string GetQuotedText(string text)
        {
            return $"\"{text}\"";
        }

        //private static string OutputLine(IEnumerable<string> cells)
        //{
        //    var sb = new StringBuilder();

        //    foreach (var cell in cells)
        //    {
        //        if (sb.Length > 0)
        //        {
        //            sb.Append(",");
        //        }
        //        sb.Append($"\"{cell}\"");
        //    }

        //    return sb.ToString();
        //}
    }
}
