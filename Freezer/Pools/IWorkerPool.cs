namespace Freezer.Pools
{
    internal interface IWorkerPool<T> where T : class
    {
        /// <summary>
        /// Minimum size of the worker
        /// </summary>
        int WorkerMinimum { get; }

        /// <summary>
        /// Maximum size of the worker
        /// </summary>
        int WorkerMaximum { get; }

        /// <summary>
        /// Peek an available worker. If none is available, return null
        /// </summary>
        /// <returns>The available free worker</returns>
        T Peek();

        /// <summary>
        /// Just like peek but blocking until a Worker is available 
        /// </summary>
        /// <returns></returns>
        T BlockingPeek();

        /// <summary>
        /// Returns a worker to the pool
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="compromise"></param>
        void Return(T worker, bool compromise);


        /// <summary>
        /// Dispose the object
        /// </summary>
        void Dispose();
    }
}