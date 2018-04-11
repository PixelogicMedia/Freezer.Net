using Freezer.Pools;

namespace Freezer.Core
{
    internal class LocalPoolProvider : IWorkerPoolProvider<IWorker>
    {
        private readonly IWorkerFactory<IWorker> _workerFactory;

        public LocalPoolProvider(IWorkerFactory<IWorker> workerFactory)
        {
            _workerFactory = workerFactory;
        }

        public IWorkerPool<IWorker> Create(int minimumWorker, int maximumWorker)
        {
            return new WorkerPool<IWorker>(minimumWorker, maximumWorker, _workerFactory); 
        }
    }
}