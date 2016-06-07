using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.OracleClient;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan.Oracle
{    
    /// <summary>
    /// Connection checker for Oracle databases using System.Data.OracleClient.
    /// </summary>
    [Export(typeof(IDatabaseConnectionChecker))]
    [ExportMetadata("ProviderName", "System.Data.OracleClient")]
    public class OracleConnectionChecker : IDatabaseConnectionChecker
    {
        /// <summary>
        /// Performs a simple connection test.
        /// </summary>
        /// <param name="connectionString">The connection string
        /// for the database under test.</param>
        /// <param name="exception">The exception raised if the connection test
        /// was unsuccessful.</param>
        /// <returns>True if the connection test was successful.</returns>
        public bool TestConnection(string connectionString, out Exception exception)
        {
            decimal oracleResult = 0;
            exception = null;
            try
            {
                using (IDbConnection connection = new OracleConnection(connectionString))
                {
                    using (IDbCommand oracleCommand = connection.CreateCommand())
                    {
                        oracleCommand.CommandType = CommandType.Text;
                        oracleCommand.CommandText = "SELECT 1 FROM DUAL";
                        connection.Open();
                        oracleResult = (decimal)oracleCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return (oracleResult == 1);
        }
    }
}
