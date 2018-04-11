using System.Drawing;
using System.IO;
using Freezer.Core;
using Freezer.Pools;
using Freezer.Runner;
using Freezer.UnitTests.HttpMock;
using Freezer.Utils.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freezer.UnitTests.TestCases.Core.Triggers
{
    [TestClass]
    public class GlobalTriggerTests
    {
        private static IWorkerPool<IWorker> _testedPool;
        private static StaticHttpServer _httpServer; 

        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            IWorkerFactory<IWorker> workerFactory = new LocalWorkerFactory();
            _testedPool = FreezerGlobal.Workers;

            _httpServer = new StaticHttpServer(FreezerTestPathSolver.GetDirectory("WebPages"));
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            //_testedPool.Dispose();
            _httpServer.Dispose();
        }

        //[TestMethod] 
        public void TestRenderOnFreezerJsEventWithSingleWebPageHard()
        {
            var rootDirectoryPath = FreezerTestPathSolver.GetDirectory("WebPages");

            var hostname = "127.0.0.1";
            int port = 25345; // This port is hardcoded. Can be changed if busy

            using (new ExclusiveBlock("TestRenderOnFreezerJsEventWithSingleWebPageHard"))
            {
                RunnerCore.SetupHostAsync(hostname, port, null, "TestRenderOnFreezerJsEventWithSingleWebPageHard");

                using (var httpListener = new StaticHttpServer(rootDirectoryPath))
                {
                    var url =  $"{_httpServer.BoundURL}/Global/verylongpage.html";
                    //var url = "http://dragonball.wikia.com/wiki/Frieza";

                    var hostableLocalProcess = new CaptureHostMock()
                    {
                        Hostname = hostname,
                        Port = port
                    };

                    var trigger = new WindowLoadTrigger(); // new FreezerJsEventTrigger();
                    var zone = CaptureZone.FullPage;

                    using (IWorker runnerHost = new RemoteWorker(hostableLocalProcess))
                    {
                        var remoteTask = new RemoteTask()
                        {
                            BrowserSize = new Size(800, 600),
                            Url = url,
                        };

                        remoteTask.SetTrigger(trigger);
                        remoteTask.SetCaptureZone(zone);

                        var taskResult = runnerHost.PerformTask(remoteTask);

                        File.WriteAllBytes($@"BmpResults/out-{nameof(TestRenderOnFreezerJsEventWithSingleWebPageHard)}.png", taskResult.PayLoad);
                    }
                }
            }
        }
        
    }
}
