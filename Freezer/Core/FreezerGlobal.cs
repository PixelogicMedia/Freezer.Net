using Freezer.Configurations;
using Freezer.Pools;

namespace Freezer.Core
{
    /// <summary>
    /// FreezerGlobal
    /// </summary>
    public static class FreezerGlobal
    {
        private static readonly FreezerGlobalInstance<IWorker> GlobalInstance;
        private static IFreezerConfigurationHolder _lazyConfigurationHolder; 

        private static readonly object InitLocker = new object();

        static FreezerGlobal()
        {
            GlobalInstance = new FreezerGlobalInstance<IWorker>(
                CurrentConfiguration,
                new XulDeployer(Resources.xulpackage), 
                new LocalPoolProvider(new LocalWorkerFactory())
                );
        }

        /// <summary>
        /// Get the value indicating whether current Freezer instance is initialized
        /// </summary>
        public static bool Initialized
        {
            get { return GlobalInstance.Initialized; }
        }

        internal static string XulLocation
        {
            get { return CurrentConfiguration.XulLocation;  }
        }

        internal static IWorkerPool<IWorker> Workers
        {
            get
            {
                EnsureInitialize();
                return GlobalInstance.Workers;
            }
        }

        internal static IFreezerConfigurationHolder CurrentConfiguration
        {
            get
            {
                return _lazyConfigurationHolder ?? 
                    (_lazyConfigurationHolder = (IFreezerConfigurationHolder) 
                    System.Configuration.ConfigurationManager.GetSection("freezerGlobal/freezerConfiguration")

                   ?? new FreezerConfigurationHandler());
            }
        }

        /// <summary>
        /// Initialize Freezer, warm-up the worker pool according to configuration file if exists
        /// </summary>
        public static void Initialize()
        {
            lock (InitLocker)
            {
                GlobalInstance.Initialize();
            }
        }

        internal static void EnsureInitialize()
        {
            if (!Initialized)
                Initialize();
        }
        

    }
}
