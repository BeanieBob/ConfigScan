using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan.MsSqlServer
{
    /// <summary>
    /// Connection checker for PostgreSql databases.
    /// </summary>
    [Export(typeof(IDatabaseConnectionChecker))]
    [ExportMetadata("ProviderName", "System.Data.SqlClient")]
    public class MsSqlServerConnectionChecker : IDatabaseConnectionChecker
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
            int sqlResult = 0;
            exception = null;
            try
            {            
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    using (IDbCommand sqlCommand = connection.CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "SELECT 1";
                        connection.Open();
                        sqlResult = (int)sqlCommand.ExecuteScalar();
                    }
                }               
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return (sqlResult == 1);
        }
    }
}
