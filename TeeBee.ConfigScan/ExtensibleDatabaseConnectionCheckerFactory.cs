using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using TeeBee.ConfigScan.Common;

namespace TeeBee.ConfigScan
{
    /// <summary>
    /// This is an extensible implementation of IDatabaseConnectionCheckerFactory
    /// which relies on MEF to compile a list of IDatabaseConnectionChecker plugins.    
    /// </summary>
    public class ExtensibleDatabaseConnectionCheckerFactory : IDatabaseConnectionCheckerFactory,
        IDisposable
    {
        /// <summary>
        /// The relative path to the IDatabaseConnectionChecker plugins.
        /// </summary>
        public const string PLUGIN_RELATIVE_DIR_PATH = ".\\Plugins";
        
        /// <summary>
        /// The search pattern filter to use when trying to compile a list of valid plugins.
        /// </summary>
        public const string PLUGIN_FILE_SEARCH_PATTERN = "*.dll";

        /// <summary>
        /// The catalog of Plugins collected from the plugin directory.
        /// </summary>
        private DirectoryCatalog pluginCatalog;
        
        #pragma warning disable 0649

        /// <summary>
        /// A MEF compatible list of plugins which implment IDatabaseConnectionChecker. 
        /// </summary>
        [ImportMany(AllowRecomposition=true)]
        private IEnumerable<Lazy<IDatabaseConnectionChecker, IDatabaseConnectionMetadata>>
          databaseConnectionPluginList;

        #pragma warning restore 0649
        
        /// <summary>
        /// Constructor for ExtensibleDatabaseConnectionCheckerFactory.         
        /// </summary>
        public ExtensibleDatabaseConnectionCheckerFactory()
        {
            this.pluginCatalog = new DirectoryCatalog(
                PLUGIN_RELATIVE_DIR_PATH,
                PLUGIN_FILE_SEARCH_PATTERN);
            
            CompositionContainer container = new CompositionContainer(pluginCatalog);
            container.ComposeParts(this);            
        }

        /// <summary>
        /// Refresh the plugin catalog to account for plugin directory content changes.
        /// </summary>
        public void RefreshPlugins()
        {
            this.pluginCatalog.Refresh();
        }

        /// <summary>
        /// Returns the correct IDatabaseConnectionChecker implementation
        /// from the catalog of discovered plugins, based on the providerName.
        /// </summary>
        /// <param name="providerName">The relevant database providerName</param>
        /// <returns></returns>
        public IDatabaseConnectionChecker CreateDatabaseConnectionChecker(string providerName)
        {
            Lazy<IDatabaseConnectionChecker, IDatabaseConnectionMetadata> databaseConnectionCheckerPlugin =
                this.databaseConnectionPluginList.FirstOrDefault<Lazy<IDatabaseConnectionChecker,
                IDatabaseConnectionMetadata>>(x => x.Metadata.ProviderName == providerName);
            if (databaseConnectionCheckerPlugin == null)
                return new NoProviderConnectionChecker();
            return databaseConnectionCheckerPlugin.Value;
        }

        /// <summary>
        /// Gets a descriptive list of currently loaded plugins, for informational purposes.
        /// </summary>
        public List<DatabaseConnectionCheckerPluginInfo> PluginInfo
        {
            get
            {
                List<DatabaseConnectionCheckerPluginInfo> pluginInfoList =
                    new List<DatabaseConnectionCheckerPluginInfo>();
                
                foreach(Lazy<IDatabaseConnectionChecker, IDatabaseConnectionMetadata>
                    pluginItem in this.databaseConnectionPluginList)
                {
                    IDatabaseConnectionChecker importedClass
                        = pluginItem.Value;                   
                    pluginInfoList.Add(
                        new DatabaseConnectionCheckerPluginInfo(
                            Assembly.GetAssembly(importedClass.GetType()).FullName,
                            importedClass.GetType().ToString(),
                            pluginItem.Metadata.ProviderName));
                }             
                
                return pluginInfoList;
            }
        }        

        /// <summary>
        /// Required to implement IDisposable 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Required to implement IDisposable. 
        /// Needed for disposing of the directory catalog.
        /// </summary>
        /// <param name="disposing">True if this method was called fom Dispose() method.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.pluginCatalog.Dispose();
            }
        }

    }
}
