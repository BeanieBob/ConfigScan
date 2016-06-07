using System;

namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// Provides the ability to check a database connection 
    /// </summary>
    public interface IDatabaseConnectionChecker
    {
        /// <summary>
        /// Performs a simple connection test.
        /// </summary>
        /// <param name="connectionString">The connection string
        /// for the database under test.</param>
        /// <param name="exception">The exception raised if the connection test
        /// was unsuccessful.</param>
        /// <returns>True if the connection test was successful.</returns>
        bool TestConnection(string connectionString, out Exception exception);
    }
}
