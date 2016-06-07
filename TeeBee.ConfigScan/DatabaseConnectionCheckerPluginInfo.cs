
namespace TeeBee.ConfigScan
{
    /// <summary>
    /// Contains meta information about a database connection checker plugin which
    /// implements IDatabaseConnectionChecker.
    /// </summary>
    public class DatabaseConnectionCheckerPluginInfo
    {
        private string assemblyName;
        private string className;
        private string providerName;

        /// <summary>
        /// Constructor for DatabaseConnectionCheckerPluginInfo
        /// </summary>
        /// <param name="assemblyName">The assembly in which the IDatabaseConnectionChecker
        /// implementation resides.</param>
        /// <param name="className">The class which implements IDatabaseConnectionChecker.</param>
        /// <param name="providerName">The database providerName at which the
        /// IDatabaseConnectionChecker implementation is targetted.</param>
        public DatabaseConnectionCheckerPluginInfo(string assemblyName, string className, string providerName)
        {
            this.assemblyName = assemblyName;
            this.className = className;
            this.providerName = providerName;
        }

        /// <summary>
        /// The assembly in which the IDatabaseConnectionChecker
        /// implementation resides.
        /// </summary>
        public string AssemblyName { get { return this.assemblyName; } }

        /// <summary>
        /// The class which implements IDatabaseConnectionChecker.
        /// </summary>
        public string ClassName { get { return this.className; } }

        /// <summary>
        /// The database providerName at which the
        /// IDatabaseConnectionChecker implementation is targetted.
        /// </summary>
        public string ProviderName { get { return this.providerName; } }
    }
}
