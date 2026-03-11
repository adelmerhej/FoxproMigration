using FoxproMigration.UI.Main.Configuration;
using FoxproMigration.UI.Models;
using FoxproMigration.UI.Repositories;
using FoxproMigration.UI.Utilities;
using FoxproMigration.UI.Utilities.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FoxproMigration.UI.Main
{
    public partial class MigrationForm : Form
    {
        private const string EmbeddedResourceName = "FoxproMigration.UI.jsonFiles.dbfiles.json";
        private static readonly string DbFilesPath =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonFiles", "dbfiles.json");

        private readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();

        public MigrationForm()
        {
            InitializeComponent();

            CheckjsonFile();
            LoadSavedConfiguration();
        }

        private void CheckjsonFile()
        {
            if (!File.Exists(DbFilesPath))
            {
                CreateDefaultDbFilesJson();
            }
        }

        private void LoadSavedConfiguration()
        {
            txtDbfFilesLocation.Text = Properties.Settings.Default.DbfFilesLocation;
            txtSQLDatabaseServer.Text = Properties.Settings.Default.SqlDatabaseServer;
            txtDatabaseName.Text = Properties.Settings.Default.SqlDatabaseName;
            txtDatabasePort.Text = Properties.Settings.Default.SqlDatabasePort.ToString();
            txtDatabaseUsername.Text = Properties.Settings.Default.SqlDatabaseUsername;

            try
            {
                txtDatabasePassword.Text = string.IsNullOrEmpty(Properties.Settings.Default.SqlDatabasePassword)
                    ? string.Empty
                    : SystemUtilities.Base64Decode(Properties.Settings.Default.SqlDatabasePassword);
            }
            catch (FormatException)
            {
                txtDatabasePassword.Text = Properties.Settings.Default.SqlDatabasePassword;
            }
        }

        private void SaveConfiguration()
        {
            Properties.Settings.Default.DbfFilesLocation = txtDbfFilesLocation.Text;
            Properties.Settings.Default.SqlDatabaseServer = txtSQLDatabaseServer.Text;
            Properties.Settings.Default.SqlDatabaseName = txtDatabaseName.Text;
            _ = int.TryParse(txtDatabasePort.Text, out int result);
            Properties.Settings.Default.SqlDatabasePort = result;
            Properties.Settings.Default.SqlDatabaseUsername = txtDatabaseUsername.Text;

            Properties.Settings.Default.SqlDatabasePassword = string.IsNullOrEmpty(txtDatabasePassword.Text)
                ? string.Empty
                : SystemUtilities.Base64Encode(txtDatabasePassword.Text);
            Properties.Settings.Default.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string sql = "";

            MigrateDbfToSql(sql);
            SaveConfiguration();
            Close();
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

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            FilesConfigurationForm filesConfigurationForm = new FilesConfigurationForm();
            filesConfigurationForm.ShowDialog();
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

        private void CreateDefaultDbFilesJson()
        {
            string directory = Path.GetDirectoryName(DbFilesPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (Stream resourceStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(EmbeddedResourceName))
            {
                if (resourceStream == null)
                {
                    throw new FileNotFoundException(
                        "Embedded resource not found: " + EmbeddedResourceName);
                }

                using (FileStream fileStream = new FileStream(DbFilesPath, FileMode.Create, FileAccess.Write))
                {
                    resourceStream.CopyTo(fileStream);
                }
            }
        }

        private void MigrateDbfToSql(string sql)
        {
            try
            {
                DbfReaderRepository dbfReaderRepository = new DbfReaderRepository(txtDbfFilesLocation.Text);

                string json = File.ReadAllText(DbFilesPath);
                var dbfFiles = _serializer.Deserialize<List<DbfFileInfoModel>>(json);

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionHelper.BuildConnectionString()))
                {
                    sqlConnection.Open();

                    var cmd = new SqlCommand(sql, sqlConnection);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Migration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
