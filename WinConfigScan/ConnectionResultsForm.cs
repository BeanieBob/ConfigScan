using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TeeBee.ConfigScan;
using TeeBee.ConfigScan.Common;

namespace WinConfigChecker
{
    /// <summary>
    /// The form which displays the list of database connections and their test status.
    /// </summary>
    public partial class ConnectionResultsForm : Form
    {
        /// <summary>
        /// The ConfigurationTestRunnerBase implementation which can perform configuration tests. 
        /// </summary>
        private ConfigurationTestRunnerBase configurationTestRunner;

        /// <summary>
        /// The IDatabaseConnectionCheckerFactory implementation which can return the 
        /// appropriate IDatabaseConnectionChecker implementation.
        /// </summary>
        private IDatabaseConnectionCheckerFactory databaseConnectionCheckerFactory;

        /// <summary>
        /// The default description which will be associated with the source of a 
        /// database connection string if another description is not present.
        /// </summary>
        private string connectionSourceDefaultDescription;

        /// <summary>
        /// The list of database connection test details which includes
        /// the connection strings and a record of the test details.
        /// </summary>
        private List<DatabaseConnectionTestDetails> databaseConnectionTestList;

        /// <summary>
        /// The list of database connection test details in the
        /// form of a typed dataset.
        /// </summary>
        private DatabaseConnectionTestDetailsDataSet databaseConnectionTestData = new DatabaseConnectionTestDetailsDataSet();

        /// <summary>
        /// CancellationTokenSource object required for async cancellation.
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Records if an exception was thrown when the 
        /// database connection tests were initiated.
        /// </summary>
        private Exception databaseConnectionTestException;        


        /// <summary>
        /// Constructor for ConectionResultsForm.
        /// </summary>
        /// <param name="configurationTestRunner">The ConfigurationTestRunnerBase implementation which can
        /// perform configuration tests.</param>
        /// <param name="databaseConnectionCheckerFactory">
        /// The IDatabaseConnectionCheckerFactory implementation which can return the 
        /// appropriate IDatabaseConnectionChecker implementation.</param>
        /// <param name="connectionSourceDefaultDescription">The default description which will be associated
        /// with the source of a database connection string if another description is not present.</param>
        public ConnectionResultsForm(
            ConfigurationTestRunnerBase configurationTestRunner,
            IDatabaseConnectionCheckerFactory databaseConnectionCheckerFactory,
            string connectionSourceDefaultDescription)
        {
            InitializeComponent();
            this.configurationTestRunner = configurationTestRunner;
            this.databaseConnectionCheckerFactory = databaseConnectionCheckerFactory;
            this.connectionSourceDefaultDescription = connectionSourceDefaultDescription;
        }

        /// <summary>
        /// Gets the list of database connection tests that are intended to be 
        /// executed by the form.
        /// </summary>
        public List<DatabaseConnectionTestDetails> DatabaseConnectionTestList
        {
            get { return this.databaseConnectionTestList; }
        }

        /// <summary>
        /// Runs the database connection tests asynchronously.
        /// </summary>
        public async void ConnectionTestsRunAsync()
        {
            this.databaseConnectionTestException = null;
            try
            {
                this.databaseConnectionTestList = this.configurationTestRunner.GetDatabaseConnectionTestList();
            }
            catch (Exception ex)
            {
                this.databaseConnectionTestException = ex;
                return;
            }

            this.progressBar.Maximum = 100;
            this.progressBar.Value = 0;

            this.databaseConnectionTestData = DatabaseConnectionTestDetails.ConvertToDataSet(
                this.databaseConnectionTestList);
            this.connectionTestBindingSource.DataSource = this.databaseConnectionTestData;

            IProgress<DatabaseConnectionTestProgressInfo> progress =
                new Progress<DatabaseConnectionTestProgressInfo>(
                    (connectionTestProgressInfo) =>
                        this.UpdateConnectionTestResult(connectionTestProgressInfo));

            this.cancellationTokenSource = new CancellationTokenSource();

            await configurationTestRunner.DatabaseConnectionTestsRunAsync(
                new DatabaseConnectionTestRunner(this.databaseConnectionCheckerFactory),
                cancellationTokenSource.Token,
                progress);
        }       

        /// <summary>
        /// Updates the local database connection test datasource according to newly
        /// reported progress info.
        /// </summary>
        /// <param name="connectionTestProgressInfo">A report of newly updated data
        /// relating to a revcently executed database connection test.</param>
        private void UpdateConnectionTestResult(DatabaseConnectionTestProgressInfo connectionTestProgressInfo)
        {            
            DatabaseConnectionTestDetails latestConnectionTest = connectionTestProgressInfo.ConnectionTestDetails;
            DatabaseConnectionTestDetailsDataSet.DatabaseConnectionTestDetailsRow connectionDataRow =
                this.databaseConnectionTestData.DatabaseConnectionTestDetails.Rows.Find(latestConnectionTest.ConnectionName)
                as DatabaseConnectionTestDetailsDataSet.DatabaseConnectionTestDetailsRow;

            connectionDataRow.WasTestRun = latestConnectionTest.WasTestRun;
            connectionDataRow.WasTestSuccessful = latestConnectionTest.WasTestSuccessful;
            connectionDataRow.ConnectionErrorText = latestConnectionTest.ConnectionErrorText;
            connectionDataRow.TestStatusDescription = latestConnectionTest.TestStatusDescription;

            this.progressBar.Value = connectionTestProgressInfo.ConnectionTestPercentComplete;
            if (this.progressBar.Value == this.progressBar.Maximum)
                this.ConnectionTestsCompleted();            
        }

        /// <summary>
        /// Performs any required actions when the database connection
        /// tests are complete.
        /// </summary>
        private void ConnectionTestsCompleted()
        {
            if ( (this.cancellationTokenSource != null) && (this.cancellationTokenSource.IsCancellationRequested) )
                return;
            MessageBox.Show(this, "Connection tests have completed.", "Complete", MessageBoxButtons.OK);
            this.progressBar.Value = 0;
        }

        /// <summary>
        /// Performs required checks as the form is loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ConnectionResultsForm_Load(object sender, EventArgs e)
        {
            if (this.databaseConnectionTestException != null)
            {
                MessageBox.Show(this.databaseConnectionTestException.Message, "Config Error", MessageBoxButtons.OK);
                this.Close();
            }            
        }        

        /// <summary>
        /// Customizes the appearance of the database connection test datagrid
        /// as a new or updated row is being painted.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void dataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dataGridViewRow = this.dataGrid.Rows[e.RowIndex];
            DataRowView dataRowView = dataGridViewRow.DataBoundItem as DataRowView;
            if (dataRowView == null)
                return;

            DatabaseConnectionTestDetailsDataSet.DatabaseConnectionTestDetailsRow connectionDataRow =
                dataRowView.Row as DatabaseConnectionTestDetailsDataSet.DatabaseConnectionTestDetailsRow;
            
            DataGridViewCellStyle rowStyle = this.dataGrid.Rows[e.RowIndex].DefaultCellStyle;

            if (!connectionDataRow.WasTestRun)
            {
                rowStyle.BackColor = Color.Silver;
                return;
            }            

            if (connectionDataRow.WasTestSuccessful)
            {
                rowStyle.BackColor = Color.LightGreen;
            }
            else
            {
                rowStyle.BackColor = Color.Tomato;
            }

            if ( connectionDataRow.IsSourceNull() )
                connectionDataRow.Source = this.connectionSourceDefaultDescription;
        }

        /// <summary>
        /// Performs any clean up required as the database connection
        /// results form is closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ConnectionResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
            }             
        }     
       
    }
}
