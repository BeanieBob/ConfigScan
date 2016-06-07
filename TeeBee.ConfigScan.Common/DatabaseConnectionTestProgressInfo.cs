
namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// Class to monitor the progress of a batch of Database Connection tests.
    /// </summary>
    public class DatabaseConnectionTestProgressInfo
    {
        /// <summary>
        /// Constructor for DatabaseConnectionTestProgressInfo
        /// </summary>
        /// <param name="connectionTestDetails">The current state of a connection test.</param>
        /// <param name="connectionTestPercentComplete">A number used to monitor the progress through
        /// a list of connection tests.</param>
        public DatabaseConnectionTestProgressInfo(
            DatabaseConnectionTestDetails connectionTestDetails,
            int connectionTestPercentComplete)
        {
            this.ConnectionTestDetails = connectionTestDetails;
            this.ConnectionTestPercentComplete = connectionTestPercentComplete;
        }

        /// <summary>
        /// The current state of a connection test.
        /// </summary>
        public readonly DatabaseConnectionTestDetails ConnectionTestDetails;

        /// <summary>
        /// A number used to monitor the progress through
        /// a list of connection tests.
        /// </summary>
        public readonly int ConnectionTestPercentComplete;

    }
}
