using System;
using System.Configuration;
using System.Xml;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan
{
    /// <summary>
    /// Source of configuration entries which originate in an xml string.
    /// </summary>
    public class XmlConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// String containing the configuration settings as xml.
        /// </summary>
        private string configurationXml;

        /// <summary>
        /// Constructor for XmlConfigurationSource
        /// </summary>
        /// <param name="configurationXml">Configuration settings as xml.</param>
        public XmlConfigurationSource(string configurationXml)
        {
            this.configurationXml = configurationXml;
        }

        /// <summary>
        /// Returns the connection strings present in the xml string. 
        /// </summary>
        /// <returns>A collection of connection string settings</returns>
        public ConnectionStringSettingsCollection ReadConnectionStrings()
        {
            var configurationXmlDocument = new XmlDocument();
            configurationXmlDocument.LoadXml(configurationXml);
     
            var connectionStrings = new ConnectionStringSettingsCollection();
            XmlNodeList connectionStringSections = configurationXmlDocument.GetElementsByTagName("connectionStrings");
            if (connectionStringSections.Count == 0)
            {
                throw new ApplicationException("No connection strings found in XML");
            }
            XmlNode connectionStringsElement = connectionStringSections[0];

            foreach (var node in connectionStringsElement.ChildNodes)
            {
                var xmlNode = node as XmlNode;
                if (xmlNode == null)
                {
                    continue;
                }

                if ((xmlNode.NodeType != XmlNodeType.Element) || (xmlNode.LocalName != "add"))
                {
                    continue;
                }

                if (xmlNode.Attributes == null)
                {
                    continue;
                }

                string connectionName = xmlNode.Attributes["name"] == null ? string.Empty : xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"] == null ? string.Empty : xmlNode.Attributes["connectionString"].Value;
                string providerName = xmlNode.Attributes["providerName"] == null ? string.Empty : xmlNode.Attributes["providerName"].Value;

                var connectionStringSettings = new ConnectionStringSettings(
                    connectionName, connectionString, providerName);                
                connectionStrings.Add(connectionStringSettings);
            }
            if (connectionStrings.Count == 0)
            {
                throw new ApplicationException("No connection strings found in XML");
            }
            return connectionStrings;            
        }
    }
}
