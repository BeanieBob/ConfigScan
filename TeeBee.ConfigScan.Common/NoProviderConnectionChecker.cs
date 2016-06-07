using System;

namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// "Null object" Connection checker for an unrecognized providerName.
    /// </summary>
    public class NoProviderConnectionChecker: IDatabaseConnectionChecker
    {
        /// <summary>
        /// Generates an appropriate error when an attempt is made to 
        /// perform a simple connection test for which there is no
        /// implementation.
        /// </summary>
        /// <param name="connectionString">The connection string
        /// for the database under test.</param>
        /// <param name="exception">The exception raised
        /// due to an appropriate test not being defined.</param>
        /// <returns>True if the connection test was successful.</returns>
        public bool TestConnection(string connectionString, out Exception exception)
        {
            exception = new Exception("No test defined for this Provider.");
            return false;
        }
    }
}
