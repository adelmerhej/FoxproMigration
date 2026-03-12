namespace FoxproMigration.UI.Main
{
    partial class MigrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MigrationForm));
            this.lblFilesList = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpMigrationLog = new System.Windows.Forms.GroupBox();
            this.txtMigrationLog = new System.Windows.Forms.TextBox();
            this.grpLine2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.lblRemainingFiles = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblFilesCompleted = new System.Windows.Forms.Label();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgDbfFiles = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDbfFiles = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpMigrationLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDbfFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDbfFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilesList
            // 
            this.lblFilesList.AutoSize = true;
            this.lblFilesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesList.Location = new System.Drawing.Point(14, 19);
            this.lblFilesList.Name = "lblFilesList";
            this.lblFilesList.Size = new System.Drawing.Size(160, 25);
            this.lblFilesList.TabIndex = 0;
            this.lblFilesList.Text = "Files to Migrate";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "HidePassword.png");
            this.imageList1.Images.SetKeyName(1, "ShowPassword.png");
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(749, 704);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 43);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(893, 704);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 43);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpMigrationLog
            // 
            this.grpMigrationLog.Controls.Add(this.txtMigrationLog);
            this.grpMigrationLog.Location = new System.Drawing.Point(17, 450);
            this.grpMigrationLog.Name = "grpMigrationLog";
            this.grpMigrationLog.Size = new System.Drawing.Size(1014, 146);
            this.grpMigrationLog.TabIndex = 4;
            this.grpMigrationLog.TabStop = false;
            this.grpMigrationLog.Text = "Migration Log";
            // 
            // txtMigrationLog
            // 
            this.txtMigrationLog.BackColor = System.Drawing.Color.White;
            this.txtMigrationLog.Location = new System.Drawing.Point(8, 21);
            this.txtMigrationLog.Multiline = true;
            this.txtMigrationLog.Name = "txtMigrationLog";
            this.txtMigrationLog.ReadOnly = true;
            this.txtMigrationLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMigrationLog.Size = new System.Drawing.Size(996, 118);
            this.txtMigrationLog.TabIndex = 0;
            this.txtMigrationLog.TabStop = false;
            // 
            // grpLine2
            // 
            this.grpLine2.Location = new System.Drawing.Point(19, 689);
            this.grpLine2.Name = "grpLine2";
            this.grpLine2.Size = new System.Drawing.Size(1008, 10);
            this.grpLine2.TabIndex = 4;
            this.grpLine2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.lblTimeRemaining);
            this.groupBox1.Controls.Add(this.lblRemainingFiles);
            this.groupBox1.Controls.Add(this.lblProgress);
            this.groupBox1.Controls.Add(this.lblFilesCompleted);
            this.groupBox1.Location = new System.Drawing.Point(18, 602);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1013, 88);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(182, 51);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(826, 23);
            this.progressBar.TabIndex = 1;
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Location = new System.Drawing.Point(703, 18);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(109, 16);
            this.lblTimeRemaining.TabIndex = 0;
            this.lblTimeRemaining.Text = "Time Remaining:";
            // 
            // lblRemainingFiles
            // 
            this.lblRemainingFiles.AutoSize = true;
            this.lblRemainingFiles.Location = new System.Drawing.Point(331, 18);
            this.lblRemainingFiles.Name = "lblRemainingFiles";
            this.lblRemainingFiles.Size = new System.Drawing.Size(107, 16);
            this.lblRemainingFiles.TabIndex = 0;
            this.lblRemainingFiles.Text = "Remaining Files:";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(9, 54);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(65, 16);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Progress:";
            // 
            // lblFilesCompleted
            // 
            this.lblFilesCompleted.AutoSize = true;
            this.lblFilesCompleted.Location = new System.Drawing.Point(6, 18);
            this.lblFilesCompleted.Name = "lblFilesCompleted";
            this.lblFilesCompleted.Size = new System.Drawing.Size(108, 16);
            this.lblFilesCompleted.TabIndex = 0;
            this.lblFilesCompleted.Text = "Files Completed:";
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Location = new System.Drawing.Point(19, 706);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(51, 38);
            this.btnConfiguration.TabIndex = 3;
            this.btnConfiguration.Text = "...";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseFile);
            this.groupBox2.Controls.Add(this.txtFileType);
            this.groupBox2.Controls.Add(this.lblFileType);
            this.groupBox2.Controls.Add(this.txtFilePath);
            this.groupBox2.Controls.Add(this.lblFilePath);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Location = new System.Drawing.Point(19, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 115);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Path Info";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(955, 54);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(47, 25);
            this.btnBrowseFile.TabIndex = 6;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(74, 82);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(315, 22);
            this.txtFileType.TabIndex = 5;
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(6, 85);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(42, 16);
            this.lblFileType.TabIndex = 4;
            this.lblFileType.Text = "Type:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(74, 54);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(879, 22);
            this.txtFilePath.TabIndex = 5;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(6, 57);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(62, 16);
            this.lblFilePath.TabIndex = 4;
            this.lblFilePath.Text = "File Path:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(74, 26);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(879, 22);
            this.txtFileName.TabIndex = 5;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 29);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(47, 16);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(18, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1008, 10);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // dgDbfFiles
            // 
            this.dgDbfFiles.AutoGenerateColumns = false;
            this.dgDbfFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDbfFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
            this.dgDbfFiles.DataSource = this.bsDbfFiles;
            this.dgDbfFiles.Location = new System.Drawing.Point(23, 202);
            this.dgDbfFiles.Name = "dgDbfFiles";
            this.dgDbfFiles.RowHeadersWidth = 51;
            this.dgDbfFiles.RowTemplate.Height = 24;
            this.dgDbfFiles.Size = new System.Drawing.Size(1008, 242);
            this.dgDbfFiles.TabIndex = 9;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.Width = 450;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 150;
            // 
            // bsDbfFiles
            // 
            this.bsDbfFiles.DataSource = typeof(FoxproMigration.UI.Models.DbfFileInfoModel);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 704);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 43);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(200, 704);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(101, 43);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(307, 704);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 43);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MigrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1044, 757);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dgDbfFiles);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.grpLine2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMigrationLog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblFilesList);
            this.MaximizeBox = false;
            this.Name = "MigrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FoxPro to SQL Database Migration Tool";
            this.grpMigrationLog.ResumeLayout(false);
            this.grpMigrationLog.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDbfFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDbfFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFilesList;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpMigrationLog;
        private System.Windows.Forms.GroupBox grpLine2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFilesCompleted;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label lblRemainingFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtMigrationLog;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgDbfFiles;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource bsDbfFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    }
}

