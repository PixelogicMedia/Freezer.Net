using System;
using System.Threading;

namespace Freezer.Utils.Threading
{
    /// <summary>
    /// An utility for running delegate on seperate thread with STA
    /// </summary>
    internal static class STAThreadRunner
    {
        public static TResult RunOnThread<TArg, TResult>(Func<TArg, TResult> runnable, TArg arg, TimeSpan timeOut)
        {
            TResult result = default(TResult);
            Exception exception = null; 

            Thread thread = new Thread(delegate(object o)
            {
                try
                {
                    TArg innerArg = ((dynamic) o).Arg;
                    Func<TArg, TResult> innerRunnable = ((dynamic) o).Func;
                    result = innerRunnable(innerArg);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            thread.SetApartmentState(ApartmentState.STA);

            thread.Start(new
            {
                Arg = arg,
                Func = runnable
            });
            
            bool joinResult = thread.Join(timeOut > TimeSpan.Zero ? timeOut : TimeSpan.FromMilliseconds(Int32.MaxValue));

            if (!joinResult) 
                throw new STAThreadRunnerException(thread, "Function timed out");

            if (exception != null)
                throw new STAThreadRunnerException(thread, "Exception while running runnable on thread", exception);

            return result;
        }

        public static TResult RunOnThread<TArg, TResult>(Func<TArg, TResult> runnable, TArg arg)
        {
            return RunOnThread(runnable, arg, TimeSpan.Zero); 
        }
    }
}
