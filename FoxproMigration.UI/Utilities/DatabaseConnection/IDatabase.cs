using System.Data;
using System.Configuration;

namespace FoxproMigration.UI.Utilities.DatabaseConnection
{
    public interface IDatabase
    {
        bool AllowCreateDataBase();
        ConnectionState CheckConnection();
        bool CheckDatabaseExists(string databaseName);
        void CreateDatabase(string databaseName);
        Configuration DatabaseConfiguration();
    }
}
