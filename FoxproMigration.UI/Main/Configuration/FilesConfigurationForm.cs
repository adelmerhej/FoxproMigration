using FoxproMigration.UI.Models;
using FoxproMigration.UI.Utilities;
using FoxproMigration.UI.Utilities.DatabaseConnection;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FoxproMigration.UI.Main.Configuration
{
    public partial class FilesConfigurationForm : Form
    {
        private ConnectionModel _connectionModel = new ConnectionModel();

        public FilesConfigurationForm()
        {
            InitializeComponent();

            ConnectionParams();
            LoadSavedConfiguration();
        }

        private void ConnectionParams()
        {
            _connectionModel = DatabaseFactory.ConnectionParamsGet();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
            Close();
        }

        private void LoadSavedConfiguration()
        {
            txtDbfFilesLocation.Text = _connectionModel.DbfFilesLocation;
            //cboDatabaseType.EditValue = _connectionModel.DatabaseType;
            txtSQLDatabaseServer.Text = _connectionModel.SqlDatabaseServer;
            txtDatabasePort.Text = _connectionModel.SqlDatabasePort.ToString();
            txtDatabaseName.Text = _connectionModel.SqlDatabaseName;
            txtDatabaseUsername.Text = _connectionModel.SqlDatabaseUsername;
    
            try
            {
                txtDatabasePassword.Text = string.IsNullOrEmpty(_connectionModel.SqlDatabasePassword)
                    ? string.Empty
                    : SystemUtilities.Base64Decode(_connectionModel.SqlDatabasePassword);
            }
            catch (FormatException)
            {
                txtDatabasePassword.Text = _connectionModel.SqlDatabasePassword;
            }
        }

        private void SaveConfiguration()
        {
            _connectionModel.DatabaseType = "Sql";
            _connectionModel.DbfFilesLocation = txtDbfFilesLocation.Text;
            _connectionModel.SqlDatabaseServer = txtSQLDatabaseServer.Text.Trim();
            int.TryParse(txtDatabasePort.Text, out var result);
            _connectionModel.SqlDatabasePort = result;
            _connectionModel.SqlDatabaseName = txtDatabaseName.Text.Trim();
            _connectionModel.SqlDatabaseUsername = txtDatabaseUsername.Text;
            _connectionModel.SqlDatabasePassword = SystemUtilities.Base64Encode(txtDatabasePassword.Text);

            DatabaseFactory.ConnectionParamsSet(_connectionModel);
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrWhiteSpace(txtDbfFilesLocation.Text) && Directory.Exists(txtDbfFilesLocation.Text))
                {
                    folderBrowserDialog.SelectedPath = txtDbfFilesLocation.Text;
                }

                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtDbfFilesLocation.Text = Path.GetFullPath(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            txtDatabasePassword.PasswordChar = (txtDatabasePassword.PasswordChar == '*') ? '\0' : '*';
            btnShowHidePassword.ImageIndex = 0;
        }

        private void btnShowHidePassword_MouseLeave(object sender, EventArgs e)
        {
            txtDatabasePassword.PasswordChar = txtDatabasePassword.PasswordChar = '*';
            btnShowHidePassword.ImageIndex = 1;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = string.IsNullOrWhiteSpace(txtDatabasePort.Text)
                    ? txtSQLDatabaseServer.Text.Trim()
                    : string.Format("{0},{1}", txtSQLDatabaseServer.Text.Trim(), txtDatabasePort.Text.Trim()),
                InitialCatalog = txtDatabaseName.Text.Trim(),
                UserID = txtDatabaseUsername.Text.Trim(),
                Password = txtDatabasePassword.Text,
                IntegratedSecurity = false,
                ConnectTimeout = 5
            };

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                }

                MessageBox.Show(this, "SQL connection successful.", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
