using System.Configuration;

namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// Provides access to configuration entries from a particular source.
    /// </summary>
    public interface IConfigurationSource
    {
        /// <summary>
        /// Returns the connection strings from the configuration source. 
        /// </summary>
        /// <returns>A collection of connection string settings</returns>
        ConnectionStringSettingsCollection ReadConnectionStrings();
    }
}
