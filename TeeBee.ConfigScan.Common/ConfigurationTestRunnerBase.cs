using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// Abstract base class which can be implemented to execute configuration tests.
    /// </summary>
    public abstract class ConfigurationTestRunnerBase
    {
        /// <summary>
        /// The source of the configuration to be tested.
        /// </summary>
        protected IConfigurationSource configurationSource;

        /// <summary>
        /// Constructor for ConfigurationTestRunnerBase.
        /// </summary>
        /// <param name="configurationSource">The source of the configuration to be tested.</param>
        public ConfigurationTestRunnerBase(IConfigurationSource configurationSource) 
        {
            this.configurationSource = configurationSource;
        }

        /// <summary>
        /// This method should be overridden to compile a list of database test details originating
        /// from the configuration source which was supplied to this objects's constructor.
        /// </summary>
        /// <returns>The list of DatabaseConnectionTestDetails originating from the 
        /// given configuration source.</returns>
        public abstract List<DatabaseConnectionTestDetails> GetDatabaseConnectionTestList();

        /// <summary>
        /// This method should be overridden to implement asynchronous database connection
        /// tests based on the given configuration source. Implementations of this method
        /// should be decorated with the async modifier.
        /// </summary>
        /// <param name="databaseConnectionTestRunnerBase">An imlementation of
        /// DatabaseConnectionTestRunnerBase which will perform the database tests.</param>
        /// <param name="cancellationToken">Required to support cancellation of the
        /// asynchronous database copnnection tests.</param>
        /// <param name="progress">Required to support progress reporting on
        /// the testing of database connections.</param>
        /// <returns>List of database Connection Test details.</returns>
        public abstract Task<List<DatabaseConnectionTestDetails>> DatabaseConnectionTestsRunAsync(
            DatabaseConnectionTestRunnerBase databaseConnectionTestRunnerBase,        
            CancellationToken cancellationToken = default(CancellationToken),
            IProgress<DatabaseConnectionTestProgressInfo> progress = null);      
    }
}
