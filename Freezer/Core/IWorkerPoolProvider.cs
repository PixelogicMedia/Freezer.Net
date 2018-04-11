using Freezer.Pools;

namespace Freezer.Core
{
    internal interface IWorkerPoolProvider<T>  where T: class
    {
        IWorkerPool<T> Create(int minimumWorker, int maximumWorker); 
    }
}