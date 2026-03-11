using FoxproMigration.UI.Models;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using static FoxproMigration.UI.Utilities.EnumsLibrary;

namespace FoxproMigration.UI.Utilities.DatabaseConnection
{
    internal static class ConnectionHelper
    {
        private static ConnectionModel _connectionModel = new ConnectionModel();

        public static string BuildConnectionString(bool includeDatabaseName = true)
        {
            _connectionModel = DatabaseFactory.ConnectionParamsGet();

            string connectionString = string.Concat("Server=", _connectionModel.SqlDatabaseServer, ";" +
                "User Id=", _connectionModel.SqlDatabaseUsername, ";Password=", _connectionModel.SqlDatabasePassword);

            if (includeDatabaseName)
            {
                connectionString = connectionString + ";Database=" + _connectionModel.SqlDatabaseName;
            }
            return connectionString;
        }

        public static DbConnection DataConnection()
        {
            switch ((DatabaseTypes)Enum.Parse(typeof(DatabaseTypes), _connectionModel.DatabaseType))
            {
                case DatabaseTypes.SqlServer:
                    return new SqlConnection(BuildConnectionString());

                case DatabaseTypes.MySql:
                    return null;

                case DatabaseTypes.SqLite:
                    return null;

                default:
                    return null;
            }
        }
    }
}
