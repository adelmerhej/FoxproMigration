using System;
using System.Data;

namespace FoxproMigration.UI.Utilities
{
    public static class HelperApplication
    {
        public static string GenerateSqlServerTable(string tableName, DataTable schema)
        {
            var sql = $"CREATE TABLE {tableName} (\n";

            foreach (DataRow row in schema.Rows)
            {
                string name = row["ColumnName"].ToString();
                Type type = (Type)row["DataType"];
                int size = Convert.ToInt32(row["ColumnSize"]);

                string sqlType = MapType(type, size);

                sql += $"  [{name}] {sqlType},\n";
            }

            sql = sql.TrimEnd(',', '\n');
            sql += "\n);";

            return sql;
        }

        static string MapType(Type type, int size)
        {
            if (type == typeof(string))
                return $"VARCHAR({size})";

            if (type == typeof(int))
                return "INT";

            if (type == typeof(decimal))
                return "DECIMAL(18,4)";

            if (type == typeof(double))
                return "FLOAT";

            if (type == typeof(DateTime))
                return "DATETIME";

            if (type == typeof(bool))
                return "BIT";

            return "VARCHAR(255)";
        }
    }
}
