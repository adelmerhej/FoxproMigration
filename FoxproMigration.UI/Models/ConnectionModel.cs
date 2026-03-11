namespace FoxproMigration.UI.Models
{
    public class ConnectionModel
    {
        public string DatabaseType { get; set; }
        public string SqlDatabaseServer { get; set; }
        public int SqlDatabasePort { get; set; }
        public string SqlDatabaseName { get; set; }
        public string SqlDatabaseUsername { get; set; }
        public string SqlDatabasePassword { get; set; }
    }
}
