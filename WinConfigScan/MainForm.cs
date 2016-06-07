using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinConfigChecker
{
    using Microsoft.Web.Administration;
    using System.Security.Principal;
    using TeeBee.ConfigScan;
    using TeeBee.ConfigScan.Common;
    using WinConfigScan;
    using WinConfigScan.Properties;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {        

        /// <summary>
        /// Field storing the ExtensibleDatabaseConnectionCheckerFactory implementation of
        /// IDatabaseConnectionCheckerFactory which is used when testing database connections.
        /// </summary>
        private ExtensibleDatabaseConnectionCheckerFactory databaseConnectionCheckerFactory; 
     
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();            
        }

        /// <summary>
        /// Checks if the current use has adminstrative access.
        /// </summary>
        public bool UserIsAdministrator
        {
            get
            {
                bool isAdministrator = false;
                try
                {
                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(user);
                    isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch
                {
                    // Not adminstrator by default
                }
                return isAdministrator;
            }
        }

        /// <summary>
        /// Event triggered on load of the main form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.lblInheritanceNote.Text = Resources.APP_CONFIG_INHERITANCE_NOTE;
            this.InitializeWebsiteTabsheet();
            this.databaseConnectionCheckerFactory = 
                new ExtensibleDatabaseConnectionCheckerFactory();
        }

        /// <summary>
        /// Populates dropdown values on the tabsheet concerned with
        /// testing web.config files.
        /// </summary>
        public void InitializeWebsiteTabsheet()
        {
            // Adminstrative access is required to read the IIS web 
            // application information programatically.
            if (!this.UserIsAdministrator)
            {
                this.tabPageWebConfig.Controls.Clear();
                Label errorLabel = new Label();
                errorLabel.ForeColor = Color.Red;
                errorLabel.AutoSize = true;
                errorLabel.Text = Resources.WEB_CONFIG_RIGHTS_NOTE;
                errorLabel.Left = 50;
                errorLabel.Top = 50;
                this.tabPageWebConfig.Controls.Add(errorLabel);
                return;                
            }
            this.RefreshWebSiteDropdown();
            if (Settings.Default.SelectedSiteIndex < this.comboWebSites.Items.Count)
                this.comboWebSites.SelectedIndex = Settings.Default.SelectedSiteIndex;
            if (Settings.Default.SelectedApplicationIndex < this.comboWebApplications.Items.Count)
                this.comboWebApplications.SelectedIndex = Settings.Default.SelectedApplicationIndex;
        }

        /// <summary>
        /// Event fired when the main form has closed.        
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.databaseConnectionCheckerFactory.Dispose();
            Settings.Default.SelectedSiteIndex = this.comboWebSites.SelectedIndex;
            Settings.Default.SelectedApplicationIndex = this.comboWebApplications.SelectedIndex;
            Settings.Default.Save();
        }
        
        /// <summary>
        /// Run database connection tests on a given configuration source.
        /// </summary>
        /// <param name="configurationSource">The source of the configuration 
        /// which contains the database connection strings.</param>
        /// <param name="connectionSourceDefaultDescription">The default 
        /// description of the configuration source when a more
        /// meaningful description is not available at runtime.</param>
        private void RunConnectionTests(IConfigurationSource configurationSource,
            string connectionSourceDefaultDescription = "")
        {
            ConfigurationTestRunnerBase configurationTestRunner =
              new ConfigurationTestRunner(configurationSource);

            this.databaseConnectionCheckerFactory.RefreshPlugins();

            var connectionResultsForm = new ConnectionResultsForm(
                configurationTestRunner,
                this.databaseConnectionCheckerFactory,
                connectionSourceDefaultDescription);

            connectionResultsForm.ConnectionTestsRunAsync();
            DialogResult dialogResult = connectionResultsForm.ShowDialog(this);
        }

        /// <summary>
        /// Button click event to trigger testing of selected web configuration.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnTestWebConfig_Click(object sender, EventArgs e)
        {
            IConfigurationSource configurationSource = new WebConfigurationSource(
                this.comboWebSites.Text,
                this.comboWebApplications.Text);

            this.RunConnectionTests(configurationSource, Resources.CONFIG_SOURCE_INHERITED_TEXT);
        }

        /// <summary>
        /// Button click event to trigger testing of selected configuration file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnTestAppConfig_Click(object sender, EventArgs e)
        {
            IConfigurationSource configurationSource = new AppConfigurationSource(
                this.txtConfigXmlFile.Text);

            this.RunConnectionTests(configurationSource, Resources.CONFIG_SOURCE_INHERITED_TEXT);
        }

        /// <summary>
        /// Button click event to trigger testing of supplied XML in the txtConfigXml textbox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnTestConfigXmlClick(object sender, EventArgs e)
        {
            IConfigurationSource configurationSource = new XmlConfigurationSource(
                this.txtConfigXml.Text);

            this.RunConnectionTests(configurationSource, "XML");
        }

        /// <summary>
        /// Button click event to trigger browsing for a config file on disk.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnBrowseConfigXmlFile_Click(object sender, EventArgs e)
        {
            if (this.dlgOpenConfigFile.ShowDialog(this) == DialogResult.OK)
            {
                this.txtConfigXmlFile.Text = this.dlgOpenConfigFile.FileName;
            }            
        }

        /// <summary>
        /// Button click event to trigger a rescan of local IIS hosted web sites and applications.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRefreshSites_Click(object sender, EventArgs e)
        {
            this.RefreshWebSiteDropdown();
        }

        /// <summary>
        /// Populate the web site dropdown with latest values 
        /// of IIS websites as reported by the ServerManager.
        /// </summary>
        private void RefreshWebSiteDropdown()
        {
            this.comboWebSites.Items.Clear();
            this.comboWebApplications.Items.Clear();
            ServerManager serverManager = new ServerManager();
            foreach (Site site in serverManager.Sites)
            {
                this.comboWebSites.Items.Add(site.Name);                
            }
            if (this.comboWebSites.Items.Count > 0)
            {
                this.comboWebSites.SelectedIndex = 0;
                this.RefreshWebApplicationDropdown();
            }
        }

        /// <summary>
        /// Populate the web application dropdown with latest values 
        /// of IIS web applications for the currently selected web site
        /// as reported by the ServerManager.
        /// </summary>
        private void RefreshWebApplicationDropdown()
        {           
            this.comboWebApplications.Items.Clear();
            ServerManager serverManager = new ServerManager();
            Site currentSite = serverManager.Sites.FirstOrDefault<Site>(
                 site => site.Name == this.comboWebSites.Text);
            if (currentSite == null)
                return;
            foreach (Application application in currentSite.Applications)
            {
                this.comboWebApplications.Items.Add(application.Path);                
            }
            if (this.comboWebApplications.Items.Count > 0)
            {
                this.comboWebApplications.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// Event triggered whenever the selected item from the
        /// Web Sites dropdown changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void comboWebSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshWebApplicationDropdown();
        }        

        /// <summary>
        /// Refreshs the datasource for the Database PlugIns dataGrid.        
        /// </summary>
        private void RefreshDatabasePlugins()
        {
            this.databaseConnectionCheckerFactory.RefreshPlugins();
            this.dataGridDatabasePlugins.AutoGenerateColumns = true;
            this.dataGridDatabasePlugins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;        
            this.dataGridDatabasePlugins.DataSource = this.databaseConnectionCheckerFactory.PluginInfo;          
        }      
       

        /// <summary>
        /// Event triggered by the user entering the Plugins tab page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void tabPagePlugins_Enter(object sender, EventArgs e)
        {
            this.RefreshDatabasePlugins();
        }

        /// <summary>
        /// Event triggered by the text being changed in the
        /// txtConfiXml edit control.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void txtConfigXml_TextChanged(object sender, EventArgs e)
        {
            // When user has cleared the XML config text, set it to
            // a default value.
            if (this.txtConfigXml.Text == string.Empty)
                this.txtConfigXml.Text = Resources.XML_CONFIG_DEFAULT_TEXT;
        }      

    }   
}
