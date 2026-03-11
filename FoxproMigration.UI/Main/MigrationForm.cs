using FoxproMigration.UI.Main.Configuration;
using FoxproMigration.UI.Models;
using FoxproMigration.UI.Repositories;
using FoxproMigration.UI.Utilities.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FoxproMigration.UI.Main
{
    public partial class MigrationForm : Form
    {
        private ConnectionModel _connectionModel = new ConnectionModel();

        private const string EmbeddedResourceName = "FoxproMigration.UI.jsonFiles.dbfiles.json";
        private static readonly string DbFilesPath =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonFiles", "dbfiles.json");

        private readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();

        public MigrationForm()
        {
            InitializeComponent();

            dgDbfFiles.SelectionChanged += dgDbfFiles_SelectionChanged;

            CheckjsonFile();
            LoadDbfFiles();
            ResetProgressStatus();
        }

        private void ResetProgressStatus()
        {
            lblProgress.Text = "Progress:";
            lblFilesCompleted.Text = "Files Completed: 0";
            lblRemainingFiles.Text = "Remaining Files: 0";
            lblTimeRemaining.Text = "Time Remaining: 00:00:00";
            progressBar.Minimum = 0;
            progressBar.Maximum = 1;
            progressBar.Value = 0;
        }

        private void InitializeProgressStatus(string phaseName, int totalFiles)
        {
            lblProgress.Text = "Progress: " + phaseName;
            lblFilesCompleted.Text = "Files Completed: 0/" + totalFiles;
            lblRemainingFiles.Text = "Remaining Files: " + totalFiles;
            lblTimeRemaining.Text = totalFiles > 0
                ? "Time Remaining: calculating..."
                : "Time Remaining: 00:00:00";

            progressBar.Minimum = 0;
            progressBar.Maximum = totalFiles > 0 ? totalFiles : 1;
            progressBar.Value = 0;

            RefreshProgressStatus();
        }

        private void UpdateProgressStatus(string phaseName, int completedFiles, int totalFiles, Stopwatch stopwatch)
        {
            int remainingFiles = Math.Max(totalFiles - completedFiles, 0);

            lblProgress.Text = "Progress: " + phaseName;
            lblFilesCompleted.Text = "Files Completed: " + completedFiles + "/" + totalFiles;
            lblRemainingFiles.Text = "Remaining Files: " + remainingFiles;
            progressBar.Value = Math.Min(completedFiles, progressBar.Maximum);

            if (completedFiles > 0 && remainingFiles > 0)
            {
                long averageTicksPerFile = stopwatch.ElapsedTicks / completedFiles;
                var remainingTime = new TimeSpan(averageTicksPerFile * remainingFiles);
                lblTimeRemaining.Text = "Time Remaining: " + remainingTime.ToString(@"hh\:mm\:ss");
            }
            else
            {
                lblTimeRemaining.Text = "Time Remaining: 00:00:00";
            }

            RefreshProgressStatus();
        }

        private void RefreshProgressStatus()
        {
            lblProgress.Refresh();
            lblFilesCompleted.Refresh();
            lblRemainingFiles.Refresh();
            lblTimeRemaining.Refresh();
            progressBar.Refresh();
            Application.DoEvents();
        }

        private void CheckjsonFile()
        {
            if (!File.Exists(DbFilesPath))
            {
                CreateDefaultDbFilesJson();
            }
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

        private void LoadDbfFiles()
        {
            string json = File.ReadAllText(DbFilesPath);
            var dbfFiles = _serializer.Deserialize<List<DbfFileInfoModel>>(json);

            dgDbfFiles.DataSource = dbfFiles;
        }

        private void dgDbfFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDbfFiles.CurrentRow == null)
            {
                return;
            }

            var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
            if (dbfFiles == null || dgDbfFiles.CurrentRow.Index < 0 || dgDbfFiles.CurrentRow.Index >= dbfFiles.Count)
            {
                return;
            }

            var selected = dbfFiles[dgDbfFiles.CurrentRow.Index];
            txtFileName.Text = selected.Name ?? string.Empty;
            txtFilePath.Text = selected.Path ?? string.Empty;
            txtFileType.Text = selected.Type ?? string.Empty;

        }

        private void ApplyTextBoxValuesToSelectedRow()
        {
            if (dgDbfFiles.CurrentRow == null)
            {
                return;
            }

            var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
            if (dbfFiles == null || dgDbfFiles.CurrentRow.Index < 0 || dgDbfFiles.CurrentRow.Index >= dbfFiles.Count)
            {
                return;
            }

            var selected = dbfFiles[dgDbfFiles.CurrentRow.Index];
            selected.Name = txtFileName.Text;
            selected.Path = txtFilePath.Text;
            selected.Type = txtFileType.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateSave()) return;
            SaveChanges();
        }

        private bool ValidateSave()
        {
            var validateReturnValue = true;
            var messageNumber = 0;
            var validateMessage = new StringBuilder();

            if (txtFileName.Text == "")
            {
                messageNumber += 1;
                validateMessage.Append("\n- File Name cannot be empty.");
                validateReturnValue = false;
                txtFileName.Focus();
            }

            if (txtFilePath.Text == "")
            {
                messageNumber += 1;
                validateMessage.Append("\n- File Path cannot be empty.");
                validateReturnValue = false;
                txtFilePath.Focus();
            }

            if (txtFileType.Text == "")
            {
                messageNumber += 1;
                validateMessage.Append("\n- File Type cannot be empty.");
                validateReturnValue = false;
                txtFileType.Focus();
            }

            if (!validateReturnValue)
            {
                validateMessage.Insert(0, "The following need your attention:");
                if (messageNumber > 1) validateMessage.Replace("following", "followings");
                MessageBox.Show(validateMessage + " \nPlease try again.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return validateReturnValue;
        }

        private void SaveChanges()
        {
            try
            {
                ApplyTextBoxValuesToSelectedRow();

                var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
                if (dbfFiles == null)
                {
                    return;
                }

                string json = _serializer.Serialize(dbfFiles);
                string directory = Path.GetDirectoryName(DbFilesPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(DbFilesPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CreateschemaInSql();
            MigrateDbfToSql();
            Close();
        }

        private void CreateschemaInSql()
        {
            try
            {
                _connectionModel = DatabaseFactory.ConnectionParamsGet();

                ApplyTextBoxValuesToSelectedRow();

                var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
                if (dbfFiles == null || dbfFiles.Count == 0)
                {
                    ResetProgressStatus();
                    return;
                }

                InitializeProgressStatus("Creating schema", dbfFiles.Count);
                var stopwatch = Stopwatch.StartNew();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionHelper.BuildConnectionString()))
                {
                    sqlConnection.Open();

                    for (int index = 0; index < dbfFiles.Count; index++)
                    {
                        var dbfFile = dbfFiles[index];

                        if (dbfFile == null)
                        {
                            UpdateProgressStatus("Creating schema", index + 1, dbfFiles.Count, stopwatch);
                            continue;
                        }

                        string filePath = dbfFile.Path;
                        string fileDirectory = !string.IsNullOrWhiteSpace(filePath)
                            ? Path.GetDirectoryName(filePath)
                            : _connectionModel.DbfFilesLocation;

                        string fileName = !string.IsNullOrWhiteSpace(filePath)
                            ? Path.GetFileName(filePath)
                            : dbfFile.Name;

                        string tableName = !string.IsNullOrWhiteSpace(dbfFile.Name)
                            ? Path.GetFileNameWithoutExtension(dbfFile.Name)
                            : Path.GetFileNameWithoutExtension(fileName);

                        if (string.IsNullOrWhiteSpace(fileDirectory) || string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(tableName))
                        {
                            throw new InvalidOperationException("Each DBF entry must include a valid name and path.");
                        }

                        var dbfReaderRepository = new DbfReaderRepository(fileDirectory);
                        var schema = dbfReaderRepository.GetSchema(fileName);
                        var sql = dbfReaderRepository.GenerateSqlServerTable(tableName, schema);

                        using (var cmd = new SqlCommand(sql, sqlConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        UpdateProgressStatus("Creating schema", index + 1, dbfFiles.Count, stopwatch);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Migration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            FilesConfigurationForm filesConfigurationForm = new FilesConfigurationForm();
            filesConfigurationForm.ShowDialog();
        }

        private void MigrateDbfToSql()
        {
            try
            {
                _connectionModel = DatabaseFactory.ConnectionParamsGet();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionHelper.BuildConnectionString()))
                {
                    sqlConnection.Open();

                    var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
                    if (dbfFiles == null || dbfFiles.Count == 0)
                    {
                        ResetProgressStatus();
                        return;
                    }

                    InitializeProgressStatus("Migrating data", dbfFiles.Count);
                    var stopwatch = Stopwatch.StartNew();

                    for (int index = 0; index < dbfFiles.Count; index++)
                    {
                        var dbfFile = dbfFiles[index];

                        if (dbfFile == null)
                        {
                            UpdateProgressStatus("Migrating data", index + 1, dbfFiles.Count, stopwatch);
                            continue;
                        }

                        string filePath = dbfFile.Path;
                        string fileDirectory = !string.IsNullOrWhiteSpace(filePath)
                            ? Path.GetDirectoryName(filePath)
                            : _connectionModel.DbfFilesLocation;

                        string fileName = !string.IsNullOrWhiteSpace(filePath)
                            ? Path.GetFileName(filePath)
                            : dbfFile.Name;

                        string tableName = !string.IsNullOrWhiteSpace(dbfFile.Name)
                            ? Path.GetFileNameWithoutExtension(dbfFile.Name)
                            : Path.GetFileNameWithoutExtension(fileName);

                        if (string.IsNullOrWhiteSpace(fileDirectory) || string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(tableName))
                        {
                            throw new InvalidOperationException("Each DBF entry must include a valid name and path.");
                        }

                        var dbfReaderRepository = new DbfReaderRepository(fileDirectory);

                        var dataTable = dbfReaderRepository.ReadTable(tableName, "");
                        using (var bulk = new SqlBulkCopy(sqlConnection))
                        {
                            bulk.DestinationTableName = tableName;
                            bulk.WriteToServer(dataTable);
                        }

                        UpdateProgressStatus("Migrating data", index + 1, dbfFiles.Count, stopwatch);

                    }

                    //var cmd = new SqlCommand(sql, sqlConnection);
                    //cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Migration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
            if (dbfFiles == null)
            {
                dbfFiles = new List<DbfFileInfoModel>();
            }

            var newFile = new DbfFileInfoModel();

            dbfFiles.Add(newFile);

            // Rebind so the grid picks up the new row
            dgDbfFiles.DataSource = null;
            dgDbfFiles.DataSource = dbfFiles;

            // Select the newly added row
            dgDbfFiles.ClearSelection();
            int lastRowIndex = dgDbfFiles.Rows.Count - 1;
            dgDbfFiles.Rows[lastRowIndex].Selected = true;
            dgDbfFiles.CurrentCell = dgDbfFiles.Rows[lastRowIndex].Cells[0];

            var selected = dbfFiles[dgDbfFiles.CurrentRow.Index];
            txtFileName.Text = selected.Name ?? string.Empty;
            txtFilePath.Text = selected.Path ?? string.Empty;
            txtFileType.Text = selected.Type ?? string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgDbfFiles.CurrentRow == null)
            {
                return;
            }
            var dbfFiles = dgDbfFiles.DataSource as List<DbfFileInfoModel>;
            if (dbfFiles == null || dgDbfFiles.CurrentRow.Index < 0 || dgDbfFiles.CurrentRow.Index >= dbfFiles.Count)
            {
                return;
            }
            var selected = dbfFiles[dgDbfFiles.CurrentRow.Index];
            var confirmResult = MessageBox.Show(this,
                $"Are you sure you want to delete '{selected.Name}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                dbfFiles.RemoveAt(dgDbfFiles.CurrentRow.Index);
                // Rebind to update the grid
                dgDbfFiles.DataSource = null;
                dgDbfFiles.DataSource = dbfFiles;
                // Clear text boxes
                txtFileName.Text = string.Empty;
                txtFilePath.Text = string.Empty;
                txtFileType.Text = string.Empty;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select a file";

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                    txtFileName.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    txtFileType.Text = Path.GetExtension(openFileDialog.FileName).TrimStart('.');
                }
            }
        }
    }
}
