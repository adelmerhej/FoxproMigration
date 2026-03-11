using System;
using System.Data;
using System.Data.Odbc;

namespace FoxproMigration.UI.Repositories
{
    public class DbfReaderRepository
    {
        private string conn;

        public DbfReaderRepository(string path)
        {
            conn = $"Driver={{Microsoft Visual FoxPro Driver}};SourceType=DBF;SourceDB={path};Exclusive=No;";
        }

        public DataTable ReadTable(string table, string filter)
        {
            using (var connection = new OdbcConnection(conn))
            {
                connection.Open();

                string sql = $"SELECT * FROM {table} {filter}";
                var adapter = new OdbcDataAdapter(sql, connection);

                var dt = new DataTable();
                adapter.Fill(dt);

                return dt;

            }
        }

        public DataTable GetSchema(string table)
        {
            using (var connection = new OdbcConnection(conn))
            {
                connection.Open();

                var cmd = new OdbcCommand($"SELECT * FROM {table} WHERE 1=0", connection);
                var reader = cmd.ExecuteReader();

                return reader.GetSchemaTable();
            }
        }

        public string GenerateSqlServerTable(string tableName, DataTable schema)
        {
            var escapedTableName = EscapeSqlIdentifier(tableName);
            var sql = $"IF OBJECT_ID(N'{escapedTableName}', N'U') IS NOT NULL\nDROP TABLE {escapedTableName};\nCREATE TABLE {escapedTableName} (\n";

            foreach (DataRow row in schema.Rows)
            {
                string name = row["ColumnName"].ToString();
                Type type = (Type)row["DataType"];
                int size = Convert.ToInt32(row["ColumnSize"]);

                string sqlType = MapType(type, size);

                sql += $"  {EscapeSqlIdentifier(name)} {sqlType},\n";
            }

            sql = sql.TrimEnd(',', '\n');
            sql += "\n);";

            return sql;
        }

        internal static string MapType(Type type, int size)
        {
            if (type == typeof(string))
                return size > 8000 ? "VARCHAR(MAX)" : $"VARCHAR({Math.Max(size, 1)})";

            if (type == typeof(int))
                return "INT";

            if (type == typeof(decimal))
                return "DECIMAL(19,4)";

            if (type == typeof(double))
                return "FLOAT";

            if (type == typeof(DateTime))
                return "DATETIME";

            if (type == typeof(bool))
                return "BIT";

            return "VARCHAR(255)";
        }

        private static string EscapeSqlIdentifier(string identifier)
        {
            return $"[{identifier.Replace("]", "]]" )}]";
        }

    }
}
