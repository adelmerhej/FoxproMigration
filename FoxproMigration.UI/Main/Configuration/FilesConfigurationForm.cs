using FoxproMigration.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FoxproMigration.UI.Main.Configuration
{
    public partial class FilesConfigurationForm : Form
    {
        private const string EmbeddedResourceName = "FoxproMigration.UI.jsonFiles.dbfiles.json";

        private static readonly string DbFilesPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonFiles", "dbfiles.json");

        private readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();

        public FilesConfigurationForm()
        {
            InitializeComponent();

            dgDbfFiles.SelectionChanged += dgDbfFiles_SelectionChanged;

            LoadDbfFiles();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateSave()) return;

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
            MessageBox.Show(this, "Configuration saved.", "Save",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
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
    }
}
