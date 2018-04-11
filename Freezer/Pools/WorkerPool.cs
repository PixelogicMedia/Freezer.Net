using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Freezer.Utils.Threading;

namespace Freezer.Pools
{
    /// <summary>
    /// Provide mechanism of handling multiple workers
    /// </summary>
    internal sealed class WorkerPool<T> : IDisposable, IWorkerPool<T> where T :  class
    {
        class WorkerItem<TWorker>
        {
            public WorkerItem(TWorker value, bool available)
            {
                Value = value;
                Available = available;
            }

            public TWorker Value { get; }

            public bool Available { get; set; }
        }

        private readonly IWorkerFactory<T> _workerFactory;

        private readonly IList<WorkerItem<T>> _currentWorkers = new List<WorkerItem<T>>();
        private readonly object _padLock = new object();
        private readonly object _peekLock = new object();
        private readonly Guid _workerIdentifier = Guid.NewGuid();
        private readonly ExclusiveBlock _exclusiveBlock; 

        private  bool _hasDisposed = false; 

        public WorkerPool(int workerMinimum, int workerMaximum, IWorkerFactory<T> workerFactory)
        {
            if (workerMinimum < 1) 
                throw new ArgumentException(nameof(workerMinimum));

            if (workerMaximum < 1)
                throw new ArgumentException(nameof(workerMaximum));

            if (workerMinimum > workerMaximum)
                throw new ArgumentException(nameof(workerMinimum), $"{nameof(workerMinimum)} should not be greater thant {nameof(workerMaximum)}");

            WorkerMinimum = workerMinimum;
            WorkerMaximum = workerMaximum;
            _workerFactory = workerFactory;

            _exclusiveBlock = new ExclusiveBlock(_workerIdentifier.ToString());

            InitializeWorkers(workerMinimum, workerFactory);
        }

        private void InitializeWorkers(int workerMinimum, IWorkerFactory<T> workerFactory)
        {
            var spinLock = new SpinLock();

            Parallel.For(0, workerMinimum, i =>
            {
                bool lockHasBeenTaken = false;

                try
                {
                    var workerItem = new WorkerItem<T>(workerFactory.CreateInstance(_workerIdentifier.ToString()), true);
                    spinLock.Enter(ref lockHasBeenTaken);
                    _currentWorkers.Add(workerItem);
                }
                finally
                {
                    if (lockHasBeenTaken)
                        spinLock.Exit();
                }
            });
        }

        /// <summary>
        /// Minimum size of the worker
        /// </summary>
        public int WorkerMinimum { get; }

        /// <summary>
        /// Maximum size of the worker
        /// </summary>
        public int WorkerMaximum { get; }

        /// <summary>
        /// Enlarge pool and return object. Return null if poolSize exceeds _workerMaximum
        /// </summary>
        /// <returns></returns>
        private WorkerItem<T> TryCreateAndEnlargePool()
        {
            lock (_padLock)
            {
                if (_currentWorkers.Count < WorkerMaximum)
                {
                    var newInstance = new WorkerItem<T>(_workerFactory.CreateInstance(_workerIdentifier.ToString()), true);
                    _currentWorkers.Add(newInstance);

                    return newInstance;
                }

                return null; 
            }
        }

        /// <summary>
        /// Peek an available worker. If none is available, return null
        /// </summary>
        /// <returns>The available free worker</returns>
        public T Peek()
        {
            if (_hasDisposed)
                throw new ObjectDisposedException(nameof(WorkerPool<T>));

            lock (_padLock)
            {
                var availablePool = _currentWorkers.FirstOrDefault(p => p.Available);

                if (availablePool != null)
                {
                    availablePool.Available = false;
                    return availablePool.Value; 
                }

                var enlargeResult = TryCreateAndEnlargePool();

                if (enlargeResult != null)
                {
                    enlargeResult.Available = false;
                    return enlargeResult.Value;
                }

                // Enlarge failed because max pool size was reached
                return null; 
            }
        }

        /// <summary>
        /// Just like peek but blocking until a Worker is available 
        /// </summary>
        /// <returns></returns>
        public T BlockingPeek()
        {
            if (_hasDisposed)
                throw new ObjectDisposedException(nameof(WorkerPool<T>));

            T worker ;

            while ((worker = Peek()) == null)
            {
                lock (_peekLock)
                {
                    Monitor.Wait(_peekLock);

                    if (_hasDisposed)
                        return null; 
                }
            }

            return worker; 
        }

        /// <summary>
        /// Returns a worker to the pool
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="compromise"></param>
        public void Return(T worker, bool compromise)
        {
            lock (_padLock)
            {
                var workerObject = _currentWorkers.FirstOrDefault(p => p.Value == worker);

                if (workerObject == null)
                    throw new InvalidOperationException($"{nameof(worker)} was not created by this pool");

                if (compromise)
                {
                    // Remote client has shut down 
                    _currentWorkers.Remove(workerObject);
                }
                else
                {
                    workerObject.Available = true;
                }
            }

            // Notify threads waiting for blocking Peek 
            lock (_peekLock)
            {
                Monitor.Pulse(_peekLock);
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (_hasDisposed)
                return;

            if (disposing)
            {
                if (!_hasDisposed)
                {
                    foreach (var worker in _currentWorkers)
                    {
                        if (worker.Value is IDisposable)
                        {
                            ((IDisposable)worker.Value).Dispose();
                        }
                    }

                    _currentWorkers.Clear();
                    _exclusiveBlock.Dispose();
                }
            }
            
            _hasDisposed = true;
        }

        ~WorkerPool()
        {
            Dispose(false);
        }
    }
}
