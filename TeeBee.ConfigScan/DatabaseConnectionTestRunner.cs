using System;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan
{
    /// <summary>
    /// This class is capable of executing a database connection test.
    /// </summary>
    public class DatabaseConnectionTestRunner : DatabaseConnectionTestRunnerBase
    {
        /// <summary>
        /// Constructor for DatabaseConnectionTestRunner.
        /// </summary>
        /// <param name="databaseConnectionCheckerFactory">An object which can return the 
        /// appropriate IDatabaseConnectionChecker implementation when required.</param>
        public DatabaseConnectionTestRunner(           
           IDatabaseConnectionCheckerFactory databaseConnectionCheckerFactory) :
            base(databaseConnectionCheckerFactory) { }        

        /// <summary>
        /// Run a database connection test. 
        /// </summary>
        /// <param name="databaseConnectionTestDetails">Details about the database connection
        /// test that needs to be executed. The result of the connection test is applied to properties
        /// of this object.</param>
        protected override void Run(DatabaseConnectionTestDetails databaseConnectionTestDetails)
        {            
            IDatabaseConnectionChecker databaseConnectionChecker = 
                this.databaseConnectionCheckerFactory.CreateDatabaseConnectionChecker(
                databaseConnectionTestDetails.ProviderName);
            Exception testException = null;
            databaseConnectionTestDetails.WasTestSuccessful = databaseConnectionChecker.TestConnection(
                databaseConnectionTestDetails.ConnectionString, out testException);
            databaseConnectionTestDetails.WasTestRun = true;
            databaseConnectionTestDetails.ConnectionError = testException;
            if (testException != null)
                databaseConnectionTestDetails.ConnectionErrorText = testException.ToString();
        }
    }
}
