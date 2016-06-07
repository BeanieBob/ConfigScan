using System.Threading;
using System.Threading.Tasks;

namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// Abstract base class, when implemented is capable of executing a database connection test.
    /// </summary>
    public abstract class DatabaseConnectionTestRunnerBase
    {   
        /// <summary>
        /// This IDatabaseConnectionCheckerFactory instance will be expected to provide the relevant
        /// IDatabaseConnectionChecker implementation when a database connection test is executed.</param>
        /// </summary>
        protected IDatabaseConnectionCheckerFactory databaseConnectionCheckerFactory;

        /// <summary>
        /// Constructor for DatabaseConnectionCheckerFactoryBase.
        /// </summary>
        /// <param name="databaseConnectionCheckerFactory">An IDatabaseConnectionCheckerFactory which
        /// will be expected to provide the relevant IDatabaseConnectionChecker implementation when a
        /// database connection test is executed.</param>
        public DatabaseConnectionTestRunnerBase(            
            IDatabaseConnectionCheckerFactory databaseConnectionCheckerFactory)
        {            
            this.databaseConnectionCheckerFactory = databaseConnectionCheckerFactory;
        }

        /// <summary>
        /// This method should be overridden to utilize the IDatabaseConnectionCheckerFactory
        /// provided in the constructor to execute the appropriate database connection test,
        /// and update the provided databaseConnectionTestDetails object according to the test
        /// results.
        /// </summary>
        /// <param name="databaseConnectionTestDetails">Provides details about the database connection
        /// under test, and records details of any executed test.</param>
        protected abstract void Run(DatabaseConnectionTestDetails databaseConnectionTestDetails);

        /// <summary>
        /// Asynchronously runs a database connection test.
        /// </summary>
        /// <param name="databaseConnectionTestDetails">Details of the database connection test
        /// to be run.</param>
        /// <param name="cancellationToken">Required to support cancellation of asnychronous task.</param>
        /// <returns>DatabaseConnectionTestDetails updated with test results.</returns>
        public async Task<DatabaseConnectionTestDetails> RunAsync(
            DatabaseConnectionTestDetails databaseConnectionTestDetails,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Task connectionTask = Task.Factory.StartNew( () =>
                Run(databaseConnectionTestDetails), cancellationToken);            
            await connectionTask;
            return databaseConnectionTestDetails;
        } 
    }
}
