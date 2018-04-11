using System;
using System.Drawing.Imaging;
using System.IO;
using System.ServiceModel;
using System.Threading;
using Freezer.Core;
using Freezer.Engines;
using Freezer.Engines.Gecko;
using Freezer.Pools;
using Freezer.Utils.Threading;
using Gecko;

namespace Freezer.Runner
{
    /// <summary>
    /// This is the WCF host on the freezerrunner process. 
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    internal sealed class RunnerEngineHost : IWorker
    {
        private static bool _xulInitied;

        private static void EnsureXulInit()
        {
            if (!_xulInitied)
            {
                var xulPath = FreezerGlobal.Initialized ? FreezerGlobal.XulLocation : RunnerCoreGlobal.XulPath;
                
                Xpcom.Initialize(xulPath);
                _xulInitied = true;

                RunnerCoreGlobal.DefaultUserAgent = (string) GeckoPreferences.User["general.useragent.override"]; 
                RunnerCoreGlobal.DefaultAcceptLanguages = (string) GeckoPreferences.User["intl.accept_languages"]; 
             }
        }
        
        private bool _isRunning;

        public bool Available() => !_isRunning; 

        public RemoteTaskResult PerformTask(RemoteTask task)
        {
            _isRunning = true;

            try
            {
                return ThreadGuard.Instance.Invoke(InnerPerformTask, task);
            }
            catch (CaptureEngineException captureEngineException)
            {
                return new RemoteTaskResult()
                {
                    Error = true,
                    Exception = captureEngineException
                };
            }
            catch (Exception ex)
            {
                // Unknown exception is not forwarded as InnerException cause it can be non-serializable

                return new RemoteTaskResult()
                {
                    Error = true, 
                    Exception = new CaptureEngineException($"Exception while running GeckoCaptureEngine {ex.Message}", null, CaptureEngineState.InternalError)
                };
            }
            finally
            {
                _isRunning = false; 
            }
        }

        public void Exit()
        {
            // Ensure Exit returns immediately to avoid exception on client Dispose()
            ThreadPool.QueueUserWorkItem(o => { ThreadGuard.Instance.Invoke(InnerExit, string.Empty); });
        }

        public void Dispose()
        {
        }

        private string InnerExit(object dummyArg)
        {
            try
            {
                if (_xulInitied)
                    Xpcom.Shutdown();
            }
            finally
            {
                Environment.Exit(0);
               //ThreadGuard.Instance.Quit();
            }

            return null; 
        }

        private RemoteTaskResult InnerPerformTask(RemoteTask task)
        {
            EnsureXulInit();

            // TODO inject GeckoFX Dependencies
            using (var captureEngine = new GeckoCaptureEngine( task.BrowserSize, task.GetTrigger(), task.GetCaptureZone() )
            {
                AcceptLanguages = task.AcceptLanguages,
                UserAgent = task.UserAgent
            })
            {
                if (task.Cookies != null)
                {
                    foreach (var cookie in task.Cookies)
                    {
                        captureEngine.Cookies.Add(cookie);
                    }
                }

                using (var captureResult = captureEngine.CaptureUrl(task.Url, task.Timeout))
                {
                    var taskResult = new RemoteTaskResult();

                    using (var memoryStream = new MemoryStream())
                    {
                        captureResult.Save(memoryStream, ImageFormat.Png);
                        taskResult.PayLoad = memoryStream.ToArray();
                    }

                        
                    return taskResult;
                }
            }
        }

    }
}
