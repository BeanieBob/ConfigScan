using System.Configuration;
using System.Web.Configuration;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan
{
    /// <summary>
    /// Source of configuration entries which originate at the web application level.
    /// </summary>
    public class WebConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Name of the website.
        /// </summary>
        private string siteName;

        /// <summary>
        /// Name of the web application.
        /// </summary>
        private string webApplicationName;

        /// <summary>
        /// Constructor for WebConfigurationSource.
        /// </summary>
        /// <param name="siteName">Name of the website.</param>
        /// <param name="webApplicationName">Name of the web application.</param>
        public WebConfigurationSource(string siteName, string webApplicationName)
        {
            this.siteName = siteName;
            this.webApplicationName = webApplicationName;
        }

        /// <summary>
        /// Returns the connection strings accessible from the web application.
        /// </summary>
        /// <returns>A collection of connection string settings</returns>
        public ConnectionStringSettingsCollection ReadConnectionStrings()
        {
            Configuration mappedConfiguration = WebConfigurationManager.OpenWebConfiguration(
                this.webApplicationName,
                this.siteName);
            return mappedConfiguration.ConnectionStrings.ConnectionStrings;
        }
    }
}
