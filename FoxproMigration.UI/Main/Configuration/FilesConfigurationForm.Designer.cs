namespace FoxproMigration.UI.Main.Configuration
{
    partial class FilesConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesConfigurationForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpLine2 = new System.Windows.Forms.GroupBox();
            this.lblConfigurationInfo = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpLine1 = new System.Windows.Forms.GroupBox();
            this.txtDatabasePassword = new System.Windows.Forms.TextBox();
            this.lblDbfFilesLocation = new System.Windows.Forms.Label();
            this.txtDatabaseUsername = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtDbfFilesLocation = new System.Windows.Forms.TextBox();
            this.lblDatabasePassword = new System.Windows.Forms.Label();
            this.lblSourceFiles = new System.Windows.Forms.Label();
            this.lblDatabaseUsername = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblSQLDatabaseServer = new System.Windows.Forms.Label();
            this.lblDestinaton = new System.Windows.Forms.Label();
            this.txtDatabasePort = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.lblSqlPort = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnShowHidePassword = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSQLDatabaseServer = new System.Windows.Forms.TextBox();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(709, 394);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(609, 394);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpLine2
            // 
            this.grpLine2.Location = new System.Drawing.Point(23, 373);
            this.grpLine2.Name = "grpLine2";
            this.grpLine2.Size = new System.Drawing.Size(790, 10);
            this.grpLine2.TabIndex = 5;
            this.grpLine2.TabStop = false;
            // 
            // lblConfigurationInfo
            // 
            this.lblConfigurationInfo.AutoSize = true;
            this.lblConfigurationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigurationInfo.Location = new System.Drawing.Point(18, 27);
            this.lblConfigurationInfo.Name = "lblConfigurationInfo";
            this.lblConfigurationInfo.Size = new System.Drawing.Size(183, 25);
            this.lblConfigurationInfo.TabIndex = 7;
            this.lblConfigurationInfo.Text = "Configuration Info";
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 4;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.4372F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.5628F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.mainLayout.Controls.Add(this.grpLine1, 0, 2);
            this.mainLayout.Controls.Add(this.txtDatabasePassword, 1, 7);
            this.mainLayout.Controls.Add(this.lblDbfFilesLocation, 0, 1);
            this.mainLayout.Controls.Add(this.txtDatabaseUsername, 1, 6);
            this.mainLayout.Controls.Add(this.txtDatabaseName, 1, 5);
            this.mainLayout.Controls.Add(this.txtDbfFilesLocation, 1, 1);
            this.mainLayout.Controls.Add(this.lblDatabasePassword, 0, 7);
            this.mainLayout.Controls.Add(this.lblSourceFiles, 0, 0);
            this.mainLayout.Controls.Add(this.lblDatabaseUsername, 0, 6);
            this.mainLayout.Controls.Add(this.lblDatabaseName, 0, 5);
            this.mainLayout.Controls.Add(this.lblSQLDatabaseServer, 0, 4);
            this.mainLayout.Controls.Add(this.lblDestinaton, 0, 3);
            this.mainLayout.Controls.Add(this.txtDatabasePort, 3, 4);
            this.mainLayout.Controls.Add(this.btnBrowseFolder, 3, 1);
            this.mainLayout.Controls.Add(this.lblSqlPort, 2, 4);
            this.mainLayout.Controls.Add(this.btnTestConnection, 3, 7);
            this.mainLayout.Controls.Add(this.btnShowHidePassword, 2, 7);
            this.mainLayout.Controls.Add(this.txtSQLDatabaseServer, 1, 4);
            this.mainLayout.Location = new System.Drawing.Point(23, 67);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 8;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.77419F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.22581F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.mainLayout.Size = new System.Drawing.Size(790, 300);
            this.mainLayout.TabIndex = 6;
            // 
            // grpLine1
            // 
            this.mainLayout.SetColumnSpan(this.grpLine1, 4);
            this.grpLine1.Location = new System.Drawing.Point(3, 72);
            this.grpLine1.Name = "grpLine1";
            this.grpLine1.Size = new System.Drawing.Size(784, 10);
            this.grpLine1.TabIndex = 3;
            this.grpLine1.TabStop = false;
            // 
            // txtDatabasePassword
            // 
            this.txtDatabasePassword.Location = new System.Drawing.Point(161, 265);
            this.txtDatabasePassword.Multiline = true;
            this.txtDatabasePassword.Name = "txtDatabasePassword";
            this.txtDatabasePassword.PasswordChar = '*';
            this.txtDatabasePassword.Size = new System.Drawing.Size(459, 28);
            this.txtDatabasePassword.TabIndex = 3;
            // 
            // lblDbfFilesLocation
            // 
            this.lblDbfFilesLocation.AutoSize = true;
            this.lblDbfFilesLocation.Location = new System.Drawing.Point(3, 32);
            this.lblDbfFilesLocation.Name = "lblDbfFilesLocation";
            this.lblDbfFilesLocation.Size = new System.Drawing.Size(123, 16);
            this.lblDbfFilesLocation.TabIndex = 0;
            this.lblDbfFilesLocation.Text = "DBF Files Location:";
            // 
            // txtDatabaseUsername
            // 
            this.mainLayout.SetColumnSpan(this.txtDatabaseUsername, 2);
            this.txtDatabaseUsername.Location = new System.Drawing.Point(161, 231);
            this.txtDatabaseUsername.Name = "txtDatabaseUsername";
            this.txtDatabaseUsername.Size = new System.Drawing.Size(513, 22);
            this.txtDatabaseUsername.TabIndex = 3;
            // 
            // txtDatabaseName
            // 
            this.mainLayout.SetColumnSpan(this.txtDatabaseName, 2);
            this.txtDatabaseName.Location = new System.Drawing.Point(161, 196);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(513, 22);
            this.txtDatabaseName.TabIndex = 3;
            // 
            // txtDbfFilesLocation
            // 
            this.mainLayout.SetColumnSpan(this.txtDbfFilesLocation, 2);
            this.txtDbfFilesLocation.Location = new System.Drawing.Point(161, 35);
            this.txtDbfFilesLocation.Name = "txtDbfFilesLocation";
            this.txtDbfFilesLocation.Size = new System.Drawing.Size(513, 22);
            this.txtDbfFilesLocation.TabIndex = 1;
            // 
            // lblDatabasePassword
            // 
            this.lblDatabasePassword.AutoSize = true;
            this.lblDatabasePassword.Location = new System.Drawing.Point(3, 262);
            this.lblDatabasePassword.Name = "lblDatabasePassword";
            this.lblDatabasePassword.Size = new System.Drawing.Size(133, 16);
            this.lblDatabasePassword.TabIndex = 0;
            this.lblDatabasePassword.Text = "Database Password:";
            // 
            // lblSourceFiles
            // 
            this.lblSourceFiles.AutoSize = true;
            this.lblSourceFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceFiles.Location = new System.Drawing.Point(3, 0);
            this.lblSourceFiles.Name = "lblSourceFiles";
            this.lblSourceFiles.Size = new System.Drawing.Size(115, 20);
            this.lblSourceFiles.TabIndex = 0;
            this.lblSourceFiles.Text = "Source Files";
            // 
            // lblDatabaseUsername
            // 
            this.lblDatabaseUsername.AutoSize = true;
            this.lblDatabaseUsername.Location = new System.Drawing.Point(3, 228);
            this.lblDatabaseUsername.Name = "lblDatabaseUsername";
            this.lblDatabaseUsername.Size = new System.Drawing.Size(136, 16);
            this.lblDatabaseUsername.TabIndex = 0;
            this.lblDatabaseUsername.Text = "Database Username:";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(3, 193);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(110, 16);
            this.lblDatabaseName.TabIndex = 0;
            this.lblDatabaseName.Text = "Database Name:";
            // 
            // lblSQLDatabaseServer
            // 
            this.lblSQLDatabaseServer.AutoSize = true;
            this.lblSQLDatabaseServer.Location = new System.Drawing.Point(3, 156);
            this.lblSQLDatabaseServer.Name = "lblSQLDatabaseServer";
            this.lblSQLDatabaseServer.Size = new System.Drawing.Size(142, 16);
            this.lblSQLDatabaseServer.TabIndex = 0;
            this.lblSQLDatabaseServer.Text = "SQL Database Server:";
            // 
            // lblDestinaton
            // 
            this.lblDestinaton.AutoSize = true;
            this.lblDestinaton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinaton.Location = new System.Drawing.Point(3, 111);
            this.lblDestinaton.Name = "lblDestinaton";
            this.lblDestinaton.Size = new System.Drawing.Size(100, 20);
            this.lblDestinaton.TabIndex = 0;
            this.lblDestinaton.Text = "Destinaton";
            // 
            // txtDatabasePort
            // 
            this.txtDatabasePort.Location = new System.Drawing.Point(680, 159);
            this.txtDatabasePort.Name = "txtDatabasePort";
            this.txtDatabasePort.Size = new System.Drawing.Size(96, 22);
            this.txtDatabasePort.TabIndex = 3;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(680, 35);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(47, 25);
            this.btnBrowseFolder.TabIndex = 3;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lblSqlPort
            // 
            this.lblSqlPort.AutoSize = true;
            this.lblSqlPort.Location = new System.Drawing.Point(626, 156);
            this.lblSqlPort.Name = "lblSqlPort";
            this.lblSqlPort.Size = new System.Drawing.Size(34, 16);
            this.lblSqlPort.TabIndex = 0;
            this.lblSqlPort.Text = "Port:";
            this.lblSqlPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(680, 265);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(103, 28);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Test";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnShowHidePassword
            // 
            this.btnShowHidePassword.ImageIndex = 1;
            this.btnShowHidePassword.ImageList = this.imageList1;
            this.btnShowHidePassword.Location = new System.Drawing.Point(626, 265);
            this.btnShowHidePassword.Name = "btnShowHidePassword";
            this.btnShowHidePassword.Size = new System.Drawing.Size(47, 28);
            this.btnShowHidePassword.TabIndex = 3;
            this.btnShowHidePassword.Text = "...";
            this.btnShowHidePassword.UseVisualStyleBackColor = true;
            this.btnShowHidePassword.Click += new System.EventHandler(this.btnShowHidePassword_Click);
            this.btnShowHidePassword.MouseLeave += new System.EventHandler(this.btnShowHidePassword_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "HidePassword.png");
            this.imageList1.Images.SetKeyName(1, "ShowPassword.png");
            // 
            // txtSQLDatabaseServer
            // 
            this.txtSQLDatabaseServer.Location = new System.Drawing.Point(161, 159);
            this.txtSQLDatabaseServer.Name = "txtSQLDatabaseServer";
            this.txtSQLDatabaseServer.Size = new System.Drawing.Size(459, 22);
            this.txtSQLDatabaseServer.TabIndex = 3;
            // 
            // FilesConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(838, 449);
            this.Controls.Add(this.lblConfigurationInfo);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.grpLine2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.Name = "FilesConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Files Configuration";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpLine2;
        private System.Windows.Forms.Label lblConfigurationInfo;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox grpLine1;
        private System.Windows.Forms.TextBox txtDatabasePassword;
        private System.Windows.Forms.Label lblDbfFilesLocation;
        private System.Windows.Forms.TextBox txtDatabaseUsername;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtSQLDatabaseServer;
        private System.Windows.Forms.TextBox txtDbfFilesLocation;
        private System.Windows.Forms.Label lblDatabasePassword;
        private System.Windows.Forms.Label lblSourceFiles;
        private System.Windows.Forms.Label lblDatabaseUsername;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblSQLDatabaseServer;
        private System.Windows.Forms.Label lblDestinaton;
        private System.Windows.Forms.TextBox txtDatabasePort;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label lblSqlPort;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnShowHidePassword;
        private System.Windows.Forms.ImageList imageList1;
    }
}