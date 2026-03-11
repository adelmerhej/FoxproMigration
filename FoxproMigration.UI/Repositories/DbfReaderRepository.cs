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

    }
}
