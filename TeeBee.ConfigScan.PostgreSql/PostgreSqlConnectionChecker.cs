using Npgsql;
using System;
using System.ComponentModel.Composition;
using System.Data;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan.ProgreSql
{
    /// <summary>
    /// Connection checker for PostgreSql databases.
    /// </summary>    
    [Export(typeof(IDatabaseConnectionChecker))]
    [ExportMetadata("ProviderName", "Npgsql")]    
    public class PostgreSqlConnectionChecker : IDatabaseConnectionChecker
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
            int progreSqlResult = 0;
            exception = null;
            try
            {
                using (IDbConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (IDbCommand npgsqlCommand = connection.CreateCommand())
                    {
                        npgsqlCommand.CommandType = CommandType.Text;
                        npgsqlCommand.CommandText = "SELECT 1 ";
                        connection.Open();
                        progreSqlResult = (int)npgsqlCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return (progreSqlResult == 1);
        }
    }
}
