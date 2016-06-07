using System;
using System.Configuration;
using System.IO;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan
{
    /// <summary>
    /// Source of configuration entries which originate in a config file.
    /// </summary>
    public class AppConfigurationSource: IConfigurationSource
    {
        /// <summary>
        /// The path to the config file.
        /// </summary>
        private string appConfigPath;

        /// <summary>
        /// Constructor for AppConfigurationSource
        /// </summary>
        /// <param name="appConfigPath">Path to the config file to be loaded.</param>
        public AppConfigurationSource(string appConfigPath)
        {
            this.appConfigPath = appConfigPath;
        }

        /// <summary>
        /// Returns the connection strings from the configuration file. 
        /// </summary>
        /// <returns>A collection of connection string settings</returns>
        public ConnectionStringSettingsCollection ReadConnectionStrings()
        {
            if (!File.Exists(this.appConfigPath))
                throw new ArgumentException("File path does not exist.");
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = appConfigPath;
            Configuration mappedConfiguration = ConfigurationManager.OpenMappedExeConfiguration(
                fileMap,
                ConfigurationUserLevel.None);
            return mappedConfiguration.ConnectionStrings.ConnectionStrings;            
        }
    }
}
