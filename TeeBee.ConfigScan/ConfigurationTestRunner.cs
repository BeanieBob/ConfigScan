using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan
{
    /// <summary>
    /// Class from which configuration tests can be invoked.
    /// </summary>
    public class ConfigurationTestRunner : ConfigurationTestRunnerBase
    {
        /// <summary>
        /// List of database connection tests including connection strings and test statuses.
        /// </summary>
        private List<DatabaseConnectionTestDetails> databaseConnectionTestDetailsList;

        /// <summary>
        /// Constructor for ConfigurationTestRunner
        /// </summary>
        /// <param name="configurationSource">The source of the configuration to be tested.</param>
        public ConfigurationTestRunner(IConfigurationSource configurationSource)
            : base(configurationSource) {    
        }

        /// <summary>
        /// Compiles a list of database test details originating from the configuration
        /// source which was supplied to this objects's constructor.
        /// </summary>
        /// <returns>The list of DatabaseConnectionTestDetails orginating from the 
        /// given configuration source.</returns>
        public override List<DatabaseConnectionTestDetails> GetDatabaseConnectionTestList()
        {
            if (this.databaseConnectionTestDetailsList == null)
            {
                this.databaseConnectionTestDetailsList = new List<DatabaseConnectionTestDetails>();
                ConnectionStringSettingsCollection connectionStringSettingsCollection =
                    this.configurationSource.ReadConnectionStrings();
                foreach (ConnectionStringSettings connectionStringSettings in connectionStringSettingsCollection)
                {
                    this.databaseConnectionTestDetailsList.Add(
                        new DatabaseConnectionTestDetails(connectionStringSettings));
                }
            }
            return this.databaseConnectionTestDetailsList;
        }

        /// <summary>
        /// Implements asynchronous database connection tests based on the given
        /// configuration source.
        /// </summary>
        /// <param name="databaseConnectionTestRunnerBase">An imlementation of
        /// DatabaseConnectionTestRunnerBase which will perform the database tests.</param>
        /// <param name="cancellationToken">Required to support cancellation of the
        /// asynchronous database connection tests.</param>
        /// <param name="progress">Required to support progress reporting on
        /// the testing of database connections.</param>
        /// <returns>List of database Connection Test details.</returns>
        public async override Task<List<DatabaseConnectionTestDetails>> DatabaseConnectionTestsRunAsync(
            DatabaseConnectionTestRunnerBase databaseConnectionTestRunner,
            CancellationToken cancellationToken = default(CancellationToken),
            IProgress<DatabaseConnectionTestProgressInfo> progress = null)
        {               
            List<Task<DatabaseConnectionTestDetails>> taskList = new List<Task<DatabaseConnectionTestDetails>>();
            foreach(DatabaseConnectionTestDetails databaseConnectionTestDetails
                in this.databaseConnectionTestDetailsList)
            {   
                Task<DatabaseConnectionTestDetails> newTask = (
                    databaseConnectionTestRunner.RunAsync(
                    databaseConnectionTestDetails,
                    cancellationToken));
                taskList.Add(newTask); 
            }

            int connectionTestNumber = 1;
            int connectionTestCount = this.databaseConnectionTestDetailsList.Count;

            while (taskList.Count > 0)
            {
                Task<DatabaseConnectionTestDetails> connectionTestTask = await Task.WhenAny(taskList);
                taskList.Remove(connectionTestTask);
                if (connectionTestTask.IsCanceled)
                    continue;
                DatabaseConnectionTestDetails latestConnectionTestDetails = await connectionTestTask;
                if (progress != null)
                {
                    int connectionTestPercentComplete = 100 * connectionTestNumber / connectionTestCount;
                    progress.Report(new DatabaseConnectionTestProgressInfo(
                        latestConnectionTestDetails, 
                        connectionTestPercentComplete
                        ));
                    connectionTestNumber++;
                }
            }
            return this.databaseConnectionTestDetailsList;
        }
    }

}
