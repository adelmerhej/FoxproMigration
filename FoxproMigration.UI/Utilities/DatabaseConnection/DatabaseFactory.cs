using FoxproMigration.UI.Models;
using FoxproMigration.UI.Properties;
using FoxproMigration.UI.Utilities.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoxproMigration.UI.Utilities.EnumsLibrary;

namespace FoxproMigration.UI.Utilities.DatabaseConnection
{
    public class DatabaseFactory
    {
        public static IDatabase Get(string application, string databaseType, string databaseHost, int databasePort,
            string databaseName, string databaseUser, string databasePassword)
        {
            switch ((DatabaseTypes)Enum.Parse(typeof(DatabaseTypes), databaseType))
            {
                case DatabaseTypes.MySql:
                    //return new MySQLDatabaseModel()
                    //{
                    //    Server = databaseHost,
                    //    Port = databasePort,
                    //    Database = databaseName,
                    //    User = databaseUser,
                    //    Password = databasePassword
                    //};

                    return null;

                case DatabaseTypes.SqLite:
                    //return (IDatabase)new SqlLiteDatabaseModel()
                    //{
                    //    Application = application
                    //};

                    return null;

                case DatabaseTypes.SqlServer:
                    return new SqlServerDatabaseModel()
                    {
                        Server = databaseHost,
                        Database = databaseName,
                        User = databaseUser,
                        Password = databasePassword
                    };

                default:
                    return null;
            }
        }

        public static void ConnectionParamsSet(ConnectionModel connection)
        {
            Settings.Default.DatabaseType = connection.DatabaseType;
            Settings.Default.SqlDatabaseServer = connection.SqlDatabaseServer;
            Settings.Default.SqlDatabasePort = connection.SqlDatabasePort;
            Settings.Default.SqlDatabaseName = connection.SqlDatabaseName;
            Settings.Default.SqlDatabaseUsername = connection.SqlDatabaseUsername;
            Settings.Default.SqlDatabasePassword = connection.SqlDatabasePassword;

            Settings.Default.Save();
        }

        public static ConnectionModel ConnectionParamsGet()
        {
            ConnectionModel connection = new ConnectionModel();

            connection.DatabaseType = Settings.Default.DatabaseType;
            connection.SqlDatabaseServer = Settings.Default.SqlDatabaseServer;
            connection.SqlDatabasePort = Settings.Default.SqlDatabasePort;
            connection.SqlDatabaseName = Settings.Default.SqlDatabaseName;
            connection.SqlDatabaseUsername = Settings.Default.SqlDatabaseUsername;
            connection.SqlDatabasePassword = Settings.Default.SqlDatabasePassword;

            return connection;
        }

    }
}
