using System;
using System.Threading;
using System.Windows.Forms;

namespace Freezer.Utils.Threading
{

    /// <summary>
    /// The purpose of this class is to offer combination between Application.Run and Monitor.Wait(timeout)
    /// </summary>
    internal class MonitoredWait
    {
        private readonly object _threadLocker;
        private readonly TimeSpan _timeOut;
        private readonly Thread _guardThread;

        private readonly ApplicationContext _applicationContext;
        private readonly Control _invoker;

        private bool _hasMonitorExited;

        public MonitoredWait(ApplicationContext applicationContext, Control invoker, object threadLocker, TimeSpan timeOut)
        {
            if (applicationContext == null)
                throw new ArgumentNullException(nameof(applicationContext));

            _applicationContext = applicationContext;
            _invoker = invoker;
            _threadLocker = threadLocker ?? new object();
            _timeOut = timeOut;

            _guardThread = new Thread(StartGuard)
            {
                IsBackground = true
            };
        }

        private void StartGuard()
        {
            lock (_threadLocker)
            {
                Monitor.Wait(_threadLocker, 
                    _timeOut <= TimeSpan.Zero ? TimeSpan.FromMilliseconds(int.MaxValue) : _timeOut);

                _hasMonitorExited = true;
                _invoker.Invoke(new Action(delegate
                {
                    _invoker.Dispose();
                    _applicationContext.ExitThread();
                }));
            }
        }

        public void Block()
        {
            _guardThread.Start();

            Application.Run(_applicationContext);

            if (_hasMonitorExited)
            {
                lock (_threadLocker)
                {
                    Monitor.Pulse(_threadLocker);
                }
            }
        }
    }
}