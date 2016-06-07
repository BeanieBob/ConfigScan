using Oracle.DataAccess.Client;
using System;
using System.ComponentModel.Composition;
using System.Data;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan.Oracle
{
    /// <summary>
    /// Connection checker for Oracle databases using Oracle.DataAccess.OracleClient.
    /// </summary>
    [Export(typeof(IDatabaseConnectionChecker))]
    [ExportMetadata("ProviderName", "Oracle.DataAccess.OracleClient")]
    public class OdpConnectionChecker : IDatabaseConnectionChecker
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
            decimal odpResult = 0;
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
                        odpResult = (decimal)oracleCommand.ExecuteScalar();
                    }
                }                 
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return (odpResult == 1);
        }
    }
}
