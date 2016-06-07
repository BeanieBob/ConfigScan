using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeeBee.ConfigChecker.Common;
using TeeBee.ConfigChecker.MsSqlServer;
using TeeBee.ConfigChecker.Oracle;
using TeeBee.ConfigChecker.Oracle.ODP;
using TeeBee.ConfigChecker.ProgreSql;

namespace TeeBee.ConfigChecker
{
    public class DatabaseConnectionCheckerFactory : IDatabaseConnectionCheckerFactory
    {
        public IDatabaseConnectionChecker CreateDatabaseConnectionChecker(string providerName)
        {
            IDatabaseConnectionChecker databaseConnectionChecker = new NoProviderConnectionChecker();
            switch (providerName)
            {
                case "System.Data.SqlClient":
                    databaseConnectionChecker = new MsSqlServerConnectionChecker();
                    break;
                case "System.Data.OracleClient":
                    databaseConnectionChecker = new OracleConnectionChecker();
                    break;
                case "Oracle.DataAccess.Client":
                    databaseConnectionChecker = new OdpConnectionChecker();
                    break;
                case "Npgsql":
                    databaseConnectionChecker = new PostgreSqlConnectionChecker();
                    break;
            }
            return databaseConnectionChecker;
        }
    }
}
