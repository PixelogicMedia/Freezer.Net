using System;
using System.Windows.Forms;

namespace Freezer.Utils.Threading
{
    internal static class ApplicationExtensions
    {
        public static void Run(ApplicationContext applicationContext, Control invoker, object threadLocker, TimeSpan timeOut)
        {
            var monitoredWait = new MonitoredWait(applicationContext, invoker, threadLocker, timeOut);
            monitoredWait.Block();
        }
        
        public static void Run(object threadLocker, Control invoker, TimeSpan timeOut)
        {
            using (var applicationContext = new ApplicationContext())
            {
                Run(applicationContext, invoker, threadLocker, timeOut); 
            }
        }

        public static void Run(Control invoker, object threadLocker)
        {
            using (var applicationContext = new ApplicationContext())
            {
                Run(applicationContext, invoker, threadLocker, TimeSpan.FromMilliseconds(int.MaxValue));
            }
        }
        
        public static void Run(Control invoker, TimeSpan timeOut)
        {
            using (var applicationContext = new ApplicationContext())
            {
                Run(applicationContext, invoker, null, timeOut);
            }
        }
    }
}
