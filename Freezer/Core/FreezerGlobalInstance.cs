using System;
using Freezer.Configurations;
using Freezer.Pools;

namespace Freezer.Core
{
    internal class FreezerGlobalInstance<T> where T : class
    {
        private readonly IFreezerConfigurationHolder _configurationHandler;
        private readonly IXulDeployer _xulDeployer;
        private readonly IWorkerPoolProvider<T> _poolProvider;

        private IWorkerPool<T> _workers;
        private bool _initialized; 

        internal FreezerGlobalInstance(
            IFreezerConfigurationHolder configurationHandler, 
            IXulDeployer xulDeployer, 
            IWorkerPoolProvider<T> poolProvider)
        {
            if (configurationHandler == null)
                throw new ArgumentNullException(nameof(configurationHandler));

            if (xulDeployer == null)
                throw new ArgumentNullException(nameof(xulDeployer));

            _configurationHandler = configurationHandler;
            _xulDeployer = xulDeployer;
            _poolProvider = poolProvider;
        }

        public IWorkerPool<T> Workers
        {
            get { return _workers; }
        }
        
        public bool Initialized
        {
            get { return _initialized; }
        }

        public void Initialize()
        {
            _xulDeployer.Deploy(_configurationHandler.XulLocation);
            _workers = _poolProvider.Create(_configurationHandler.MinimumWorkerCount, _configurationHandler.MaximumWorkerCount);

            _initialized = true;  
        }
    }
}