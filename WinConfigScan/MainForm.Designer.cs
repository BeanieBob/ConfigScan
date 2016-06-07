namespace WinConfigChecker
{
    partial class MainForm
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
                if (this.databaseConnectionCheckerFactory != null)
                { 
                this.databaseConnectionCheckerFactory.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControlConnectionStrings = new System.Windows.Forms.TabControl();
            this.tabPageWebConfig = new System.Windows.Forms.TabPage();
            this.btnTestWebConfig = new System.Windows.Forms.Button();
            this.lblWebApplications = new System.Windows.Forms.Label();
            this.lblWebSites = new System.Windows.Forms.Label();
            this.comboWebApplications = new System.Windows.Forms.ComboBox();
            this.comboWebSites = new System.Windows.Forms.ComboBox();
            this.btnRefreshSites = new System.Windows.Forms.Button();
            this.tabPageAppConfig = new System.Windows.Forms.TabPage();
            this.lblInheritanceNote = new System.Windows.Forms.Label();
            this.lblAppConfigFilePath = new System.Windows.Forms.Label();
            this.btnTestAppConfig = new System.Windows.Forms.Button();
            this.btnBrowseConfigXmlFile = new System.Windows.Forms.Button();
            this.txtConfigXmlFile = new System.Windows.Forms.TextBox();
            this.tabPageXml = new System.Windows.Forms.TabPage();
            this.txtConfigXml = new System.Windows.Forms.TextBox();
            this.btnTestConfigXml = new System.Windows.Forms.Button();
            this.tabPagePlugins = new System.Windows.Forms.TabPage();
            this.lblDatabasePlugins = new System.Windows.Forms.Label();
            this.dataGridDatabasePlugins = new System.Windows.Forms.DataGridView();
            this.dlgOpenConfigFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tabControlConnectionStrings.SuspendLayout();
            this.tabPageWebConfig.SuspendLayout();
            this.tabPageAppConfig.SuspendLayout();
            this.tabPageXml.SuspendLayout();
            this.tabPagePlugins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDatabasePlugins)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControlConnectionStrings);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 543);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Connection Strings";
            // 
            // tabControlConnectionStrings
            // 
            this.tabControlConnectionStrings.Controls.Add(this.tabPageWebConfig);
            this.tabControlConnectionStrings.Controls.Add(this.tabPageAppConfig);
            this.tabControlConnectionStrings.Controls.Add(this.tabPageXml);
            this.tabControlConnectionStrings.Controls.Add(this.tabPagePlugins);
            this.tabControlConnectionStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlConnectionStrings.Location = new System.Drawing.Point(3, 18);
            this.tabControlConnectionStrings.Name = "tabControlConnectionStrings";
            this.tabControlConnectionStrings.SelectedIndex = 0;
            this.tabControlConnectionStrings.Size = new System.Drawing.Size(762, 522);
            this.tabControlConnectionStrings.TabIndex = 8;
            // 
            // tabPageWebConfig
            // 
            this.tabPageWebConfig.Controls.Add(this.btnTestWebConfig);
            this.tabPageWebConfig.Controls.Add(this.lblWebApplications);
            this.tabPageWebConfig.Controls.Add(this.lblWebSites);
            this.tabPageWebConfig.Controls.Add(this.comboWebApplications);
            this.tabPageWebConfig.Controls.Add(this.comboWebSites);
            this.tabPageWebConfig.Controls.Add(this.btnRefreshSites);
            this.tabPageWebConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPageWebConfig.Name = "tabPageWebConfig";
            this.tabPageWebConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWebConfig.Size = new System.Drawing.Size(754, 493);
            this.tabPageWebConfig.TabIndex = 0;
            this.tabPageWebConfig.Text = "IIS Web Sites";
            this.tabPageWebConfig.UseVisualStyleBackColor = true;
            // 
            // btnTestWebConfig
            // 
            this.btnTestWebConfig.Location = new System.Drawing.Point(100, 156);
            this.btnTestWebConfig.Name = "btnTestWebConfig";
            this.btnTestWebConfig.Size = new System.Drawing.Size(266, 33);
            this.btnTestWebConfig.TabIndex = 5;
            this.btnTestWebConfig.Text = "Test Web.Config";
            this.btnTestWebConfig.UseVisualStyleBackColor = true;
            this.btnTestWebConfig.Click += new System.EventHandler(this.btnTestWebConfig_Click);
            // 
            // lblWebApplications
            // 
            this.lblWebApplications.AutoSize = true;
            this.lblWebApplications.Location = new System.Drawing.Point(12, 98);
            this.lblWebApplications.Name = "lblWebApplications";
            this.lblWebApplications.Size = new System.Drawing.Size(81, 17);
            this.lblWebApplications.TabIndex = 4;
            this.lblWebApplications.Text = "Application:";
            // 
            // lblWebSites
            // 
            this.lblWebSites.AutoSize = true;
            this.lblWebSites.Location = new System.Drawing.Point(57, 50);
            this.lblWebSites.Name = "lblWebSites";
            this.lblWebSites.Size = new System.Drawing.Size(36, 17);
            this.lblWebSites.TabIndex = 3;
            this.lblWebSites.Text = "Site:";
            // 
            // comboWebApplications
            // 
            this.comboWebApplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWebApplications.FormattingEnabled = true;
            this.comboWebApplications.Location = new System.Drawing.Point(99, 95);
            this.comboWebApplications.Name = "comboWebApplications";
            this.comboWebApplications.Size = new System.Drawing.Size(266, 24);
            this.comboWebApplications.TabIndex = 2;
            // 
            // comboWebSites
            // 
            this.comboWebSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWebSites.FormattingEnabled = true;
            this.comboWebSites.Location = new System.Drawing.Point(99, 47);
            this.comboWebSites.Name = "comboWebSites";
            this.comboWebSites.Size = new System.Drawing.Size(266, 24);
            this.comboWebSites.TabIndex = 1;
            this.comboWebSites.SelectedIndexChanged += new System.EventHandler(this.comboWebSites_SelectedIndexChanged);
            // 
            // btnRefreshSites
            // 
            this.btnRefreshSites.Location = new System.Drawing.Point(371, 48);
            this.btnRefreshSites.Name = "btnRefreshSites";
            this.btnRefreshSites.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSites.TabIndex = 0;
            this.btnRefreshSites.Text = "Refresh";
            this.btnRefreshSites.UseVisualStyleBackColor = true;
            this.btnRefreshSites.Click += new System.EventHandler(this.btnRefreshSites_Click);
            // 
            // tabPageAppConfig
            // 
            this.tabPageAppConfig.Controls.Add(this.lblInheritanceNote);
            this.tabPageAppConfig.Controls.Add(this.lblAppConfigFilePath);
            this.tabPageAppConfig.Controls.Add(this.btnTestAppConfig);
            this.tabPageAppConfig.Controls.Add(this.btnBrowseConfigXmlFile);
            this.tabPageAppConfig.Controls.Add(this.txtConfigXmlFile);
            this.tabPageAppConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPageAppConfig.Name = "tabPageAppConfig";
            this.tabPageAppConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppConfig.Size = new System.Drawing.Size(754, 493);
            this.tabPageAppConfig.TabIndex = 1;
            this.tabPageAppConfig.Text = "App Config";
            this.tabPageAppConfig.UseVisualStyleBackColor = true;
            // 
            // lblInheritanceNote
            // 
            this.lblInheritanceNote.BackColor = System.Drawing.SystemColors.Info;
            this.lblInheritanceNote.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblInheritanceNote.Location = new System.Drawing.Point(18, 411);
            this.lblInheritanceNote.Margin = new System.Windows.Forms.Padding(5);
            this.lblInheritanceNote.Name = "lblInheritanceNote";
            this.lblInheritanceNote.Padding = new System.Windows.Forms.Padding(5);
            this.lblInheritanceNote.Size = new System.Drawing.Size(711, 64);
            this.lblInheritanceNote.TabIndex = 7;
            this.lblInheritanceNote.Text = "[ inheritance note ]";
            // 
            // lblAppConfigFilePath
            // 
            this.lblAppConfigFilePath.AutoSize = true;
            this.lblAppConfigFilePath.Location = new System.Drawing.Point(52, 50);
            this.lblAppConfigFilePath.Name = "lblAppConfigFilePath";
            this.lblAppConfigFilePath.Size = new System.Drawing.Size(41, 17);
            this.lblAppConfigFilePath.TabIndex = 4;
            this.lblAppConfigFilePath.Text = "Path:";
            // 
            // btnTestAppConfig
            // 
            this.btnTestAppConfig.Location = new System.Drawing.Point(100, 156);
            this.btnTestAppConfig.Name = "btnTestAppConfig";
            this.btnTestAppConfig.Size = new System.Drawing.Size(266, 33);
            this.btnTestAppConfig.TabIndex = 5;
            this.btnTestAppConfig.Text = "Test App.Config";
            this.btnTestAppConfig.UseVisualStyleBackColor = true;
            this.btnTestAppConfig.Click += new System.EventHandler(this.btnTestAppConfig_Click);
            // 
            // btnBrowseConfigXmlFile
            // 
            this.btnBrowseConfigXmlFile.Location = new System.Drawing.Point(371, 47);
            this.btnBrowseConfigXmlFile.Name = "btnBrowseConfigXmlFile";
            this.btnBrowseConfigXmlFile.Size = new System.Drawing.Size(29, 23);
            this.btnBrowseConfigXmlFile.TabIndex = 6;
            this.btnBrowseConfigXmlFile.Text = " ... ";
            this.btnBrowseConfigXmlFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowseConfigXmlFile.UseVisualStyleBackColor = true;
            this.btnBrowseConfigXmlFile.Click += new System.EventHandler(this.btnBrowseConfigXmlFile_Click);
            // 
            // txtConfigXmlFile
            // 
            this.txtConfigXmlFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WinConfigScan.Properties.Settings.Default, "ConfigFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtConfigXmlFile.Location = new System.Drawing.Point(99, 47);
            this.txtConfigXmlFile.Name = "txtConfigXmlFile";
            this.txtConfigXmlFile.Size = new System.Drawing.Size(266, 22);
            this.txtConfigXmlFile.TabIndex = 3;
            this.txtConfigXmlFile.Text = global::WinConfigScan.Properties.Settings.Default.ConfigFilePath;
            // 
            // tabPageXml
            // 
            this.tabPageXml.Controls.Add(this.txtConfigXml);
            this.tabPageXml.Controls.Add(this.btnTestConfigXml);
            this.tabPageXml.Location = new System.Drawing.Point(4, 25);
            this.tabPageXml.Name = "tabPageXml";
            this.tabPageXml.Size = new System.Drawing.Size(754, 493);
            this.tabPageXml.TabIndex = 2;
            this.tabPageXml.Text = "XML";
            this.tabPageXml.UseVisualStyleBackColor = true;
            // 
            // txtConfigXml
            // 
            this.txtConfigXml.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WinConfigScan.Properties.Settings.Default, "XmlText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtConfigXml.Location = new System.Drawing.Point(12, 14);
            this.txtConfigXml.Multiline = true;
            this.txtConfigXml.Name = "txtConfigXml";
            this.txtConfigXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConfigXml.Size = new System.Drawing.Size(722, 418);
            this.txtConfigXml.TabIndex = 0;
            this.txtConfigXml.Text = global::WinConfigScan.Properties.Settings.Default.XmlText;
            this.txtConfigXml.TextChanged += new System.EventHandler(this.txtConfigXml_TextChanged);
            // 
            // btnTestConfigXml
            // 
            this.btnTestConfigXml.Location = new System.Drawing.Point(572, 447);
            this.btnTestConfigXml.Name = "btnTestConfigXml";
            this.btnTestConfigXml.Size = new System.Drawing.Size(162, 29);
            this.btnTestConfigXml.TabIndex = 1;
            this.btnTestConfigXml.Text = "Test XML Config";
            this.btnTestConfigXml.UseVisualStyleBackColor = true;
            this.btnTestConfigXml.Click += new System.EventHandler(this.BtnTestConfigXmlClick);
            // 
            // tabPagePlugins
            // 
            this.tabPagePlugins.Controls.Add(this.lblDatabasePlugins);
            this.tabPagePlugins.Controls.Add(this.dataGridDatabasePlugins);
            this.tabPagePlugins.Location = new System.Drawing.Point(4, 25);
            this.tabPagePlugins.Name = "tabPagePlugins";
            this.tabPagePlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlugins.Size = new System.Drawing.Size(754, 493);
            this.tabPagePlugins.TabIndex = 3;
            this.tabPagePlugins.Text = "Plugins";
            this.tabPagePlugins.UseVisualStyleBackColor = true;
            this.tabPagePlugins.Enter += new System.EventHandler(this.tabPagePlugins_Enter);
            // 
            // lblDatabasePlugins
            // 
            this.lblDatabasePlugins.AutoSize = true;
            this.lblDatabasePlugins.Location = new System.Drawing.Point(20, 42);
            this.lblDatabasePlugins.Name = "lblDatabasePlugins";
            this.lblDatabasePlugins.Size = new System.Drawing.Size(226, 17);
            this.lblDatabasePlugins.TabIndex = 1;
            this.lblDatabasePlugins.Text = "Database Connection Test Plugins";
            // 
            // dataGridDatabasePlugins
            // 
            this.dataGridDatabasePlugins.AllowUserToAddRows = false;
            this.dataGridDatabasePlugins.AllowUserToDeleteRows = false;
            this.dataGridDatabasePlugins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDatabasePlugins.Location = new System.Drawing.Point(20, 65);
            this.dataGridDatabasePlugins.Name = "dataGridDatabasePlugins";
            this.dataGridDatabasePlugins.ReadOnly = true;
            this.dataGridDatabasePlugins.RowHeadersVisible = false;
            this.dataGridDatabasePlugins.RowTemplate.Height = 24;
            this.dataGridDatabasePlugins.Size = new System.Drawing.Size(703, 200);
            this.dataGridDatabasePlugins.TabIndex = 0;
            // 
            // dlgOpenConfigFile
            // 
            this.dlgOpenConfigFile.DefaultExt = "config";
            this.dlgOpenConfigFile.Filter = "Config Files|*.config|XML files|*.xml|All files|*.*";
            this.dlgOpenConfigFile.Title = "Open Config File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Config Scan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControlConnectionStrings.ResumeLayout(false);
            this.tabPageWebConfig.ResumeLayout(false);
            this.tabPageWebConfig.PerformLayout();
            this.tabPageAppConfig.ResumeLayout(false);
            this.tabPageAppConfig.PerformLayout();
            this.tabPageXml.ResumeLayout(false);
            this.tabPageXml.PerformLayout();
            this.tabPagePlugins.ResumeLayout(false);
            this.tabPagePlugins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDatabasePlugins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestConfigXml;
        private System.Windows.Forms.TextBox txtConfigXml;
        private System.Windows.Forms.Button btnBrowseConfigXmlFile;
        private System.Windows.Forms.Button btnTestAppConfig;
        private System.Windows.Forms.Label lblAppConfigFilePath;
        private System.Windows.Forms.TextBox txtConfigXmlFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenConfigFile;
        private System.Windows.Forms.TabControl tabControlConnectionStrings;
        private System.Windows.Forms.TabPage tabPageWebConfig;
        private System.Windows.Forms.TabPage tabPageAppConfig;
        private System.Windows.Forms.TabPage tabPageXml;
        private System.Windows.Forms.Label lblWebApplications;
        private System.Windows.Forms.Label lblWebSites;
        private System.Windows.Forms.ComboBox comboWebApplications;
        private System.Windows.Forms.ComboBox comboWebSites;
        private System.Windows.Forms.Button btnRefreshSites;
        private System.Windows.Forms.Button btnTestWebConfig;
        private System.Windows.Forms.TabPage tabPagePlugins;
        private System.Windows.Forms.DataGridView dataGridDatabasePlugins;
        private System.Windows.Forms.Label lblDatabasePlugins;
        private System.Windows.Forms.Label lblInheritanceNote;
    }
}

