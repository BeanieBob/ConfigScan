
namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// IDatabaseConnection Metadata. For the purpose of MEF based plugin
    /// architecture, the MetaData fields identify plugin properties.
    /// </summary>
    public interface IDatabaseConnectionMetadata
    {
        /// <summary>
        /// Database providerName, as specified in config files.
        /// </summary>
        string ProviderName { get; }
    }
}
