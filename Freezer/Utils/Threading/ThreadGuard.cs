using System;
using System.Reflection;
using System.Threading;

namespace Freezer.Utils.Threading
{
    internal class ThreadGuard
    {
        private static readonly ThreadGuard _instance = new ThreadGuard(); 

        private readonly object _methodLock = new object();
        private readonly object _monitortasklock = new object();
        private readonly object _monitorresultlock = new object();

        private Delegate _runnable;
        private object _arg;
        private object _result;

        private bool _hastStartBlocking;
        private Exception _lastException; 

        private ThreadGuard()
        {
            
        }

        public void Block()
        {
            if (_hastStartBlocking)
                throw new InvalidOperationException($"{nameof(ThreadGuard)} is already blocking");

            _hastStartBlocking = true;

            try
            {
                while (true)
                {
                    lock (_monitortasklock)
                    {
                        // Waiting for a task
                        Monitor.Wait(_monitortasklock);
                    }
                    
                    if (_runnable != null)
                    {
                        try
                        {
                            _result = _runnable.DynamicInvoke(_arg);

                            if (_result is string && (string) _result == "ThreadGuardQuiting")
                                break; 
                        }
                        catch (ThreadInterruptedException)
                        {
                            // We quit thread 
                            break;
                        }
                        catch (TargetInvocationException ex)
                        {
                            _lastException = ex.InnerException;
                        }
                        catch (Exception ex)
                        {
                            _lastException = ex; 
                        }
                    }

                    lock (_monitorresultlock)
                    {
                        // Notifying that task has been done 
                        Monitor.Pulse(_monitorresultlock);
                    }
                }
            }
            catch (ThreadInterruptedException)
            {
                // Natural end of thread
            }
            finally
            {
                _hastStartBlocking = false;
            }
        }

        public void Quit()
        {
            Invoke<object, object>(o =>
            {
                // This will cause the blocking thread to be interrupted
                return "ThreadGuardQuiting"; 
            }, null);
        }

        public TResult Invoke<TArg, TResult>(Func<TArg, TResult> runnable, TArg arg)
        {
            lock (_methodLock)
            {
                if (!_hastStartBlocking)
                {
                    // Run in sync mode 
                    return runnable(arg);
                }

                _lastException = null;  
                _runnable = runnable;
                _arg = arg;

                lock (_monitortasklock)
                {
                    // Notifying a task
                    Monitor.Pulse(_monitortasklock);
                }

                lock (_monitorresultlock)
                {
                    // Waiting for task to be done 
                    Monitor.Wait(_monitorresultlock);
                }

                if (_lastException != null)
                {
                    // Below is not acceptable as we lost stacktrace
                    // throw new Exception("Error while running delegate on main thread", _lastException);

                    throw _lastException; 
                }
                     

                return (TResult) _result;
            }
        }

        public static ThreadGuard Instance
        {
            get { return _instance; }
        }
    }
}
