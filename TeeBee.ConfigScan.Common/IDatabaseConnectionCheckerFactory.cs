
namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// A factory designed to provide the appropriate IDatabaseConnectionChecker
    /// for a given database.
    /// </summary>
    public interface IDatabaseConnectionCheckerFactory
    {
        /// <summary>
        /// Gets an appropriate implementation of IDatabaseConnectionChecker
        /// according to the specified database provider.
        /// </summary>
        /// <param name="providerName">Specifies the databae provider.</param>
        /// <returns>An implementation of IDatabaseConnectionChecker 
        /// appropriate for the given providerName.</returns>
        IDatabaseConnectionChecker CreateDatabaseConnectionChecker(string providerName);
    }
}
