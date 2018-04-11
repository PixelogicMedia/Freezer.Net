using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Freezer.Core;
using Freezer.Engines;

namespace Freezer.Pools
{
    /// <summary>
    /// This engine relies on external process Gecko host (freezercapture) to perform the capture 
    /// </summary>
    internal sealed class WorkerEngine : CaptureEngine
    {
        static WorkerEngine()
        {
            FreezerGlobal.EnsureInitialize();
        }

        private readonly IWorkerPool<IWorker> _workerPool;
        private readonly bool _cascadeDisposeWorkerPool; 

        public WorkerEngine(Size browserSize, Trigger trigger, CaptureZone captureZone) :
            this (browserSize, trigger, captureZone, FreezerGlobal.Workers)
        {
            _cascadeDisposeWorkerPool = false; 
        }

        public WorkerEngine(Size browserSize, Trigger trigger, CaptureZone captureZone, IWorkerPool<IWorker> workerPool) : base(browserSize, trigger, captureZone)
        {
            _workerPool = workerPool;
        }

        public override Image CaptureUrl(string baseUrl, TimeSpan timeOut)
        {
            IWorker currentWorker = null;
            bool workerCompromise = false; 

            try
            {
                // Wait for an available worker 
                currentWorker = _workerPool.BlockingPeek();

                // Bound all the request parameters to RemoteTask
                var remoteTask = CreateTask(baseUrl, timeOut);

                var taskResult = currentWorker.PerformTask(remoteTask);

                // When taskResult returns null, means that remoteworker is compromised and cannot be reused
                if (taskResult == null)
                {
                    workerCompromise = true;
                    throw new CaptureEngineException("RemoteWorker has shutdown", CaptureEngineState.InternalError);
                }

                if (taskResult.Error)
                    throw taskResult.Exception;

                using (var memoryStream = new MemoryStream(taskResult.PayLoad))
                {
                    return Image.FromStream(memoryStream);
                }
            }
            finally
            {
                if (currentWorker != null)
                    _workerPool.Return(currentWorker, workerCompromise);
            }
        }

        private RemoteTask CreateTask(string baseUrl, TimeSpan timeOut)
        {
            var remoteTask = new RemoteTask()
            {
                Timeout = timeOut,
                Url = baseUrl,
                BrowserSize = BrowserSize,
                Cookies = Cookies.ToList(),
                AcceptLanguages = AcceptLanguages,
                UserAgent = UserAgent
            };

            remoteTask.SetTrigger(Trigger);
            remoteTask.SetCaptureZone(CaptureZone);

            return remoteTask;
        }

        public sealed override void Dispose()
        {
            if (_cascadeDisposeWorkerPool)
                _workerPool.Dispose();

            base.Dispose();
        }
    }
}
