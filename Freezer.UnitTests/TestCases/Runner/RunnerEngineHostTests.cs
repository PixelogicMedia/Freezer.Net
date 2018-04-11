using System;
using System.Drawing;
using System.IO;
using Freezer.Core;
using Freezer.Pools;
using Freezer.Runner;
using Freezer.Utils.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freezer.UnitTests.TestCases.Runner
{
    /// <summary>
    /// Tests below need internet connection
    /// </summary>
    [TestClass]
    public class RunnerEngineHostTests
    {
        [TestMethod]
        [STAThread]
        public void RunnerEngine_Host_Check_Engine_Host_Simple_Task()
        {
            using (IWorker runnerHost = new RunnerEngineHost())
            {
                var remoteTask = new RemoteTask()
                {
                    BrowserSize = new Size(1366, 768),
                    Url = "https://msdn.microsoft.com/fr-fr",
                    Timeout = TimeSpan.FromSeconds(30)
                };

                remoteTask.SetTrigger(new WindowLoadTrigger(TimeSpan.FromSeconds(0)));
                remoteTask.SetCaptureZone(new VisibleScreen());

                var taskResult = runnerHost.PerformTask(remoteTask);
                Assert.IsNotNull(taskResult.PayLoad); 
            }
        }

        [TestMethod]
        public void RemoteWorker_Validate_With_SimpleHttps()
        {
            var identifier = Guid.NewGuid().ToString();

            using (new ExclusiveBlock(identifier))
            {
                using (var localProcess = new LocalProcessHost(new TcpListenerPortProvider(), identifier))
                {
                    using (IWorker runnerHost = new RemoteWorker(localProcess))
                    {
                        var remoteTask = new RemoteTask()
                        {
                            BrowserSize = new Size(1366, 768),
                            Url = "https://msdn.microsoft.com/fr-fr",
                            Timeout = TimeSpan.FromSeconds(30)
                        };

                        remoteTask.SetTrigger(new WindowLoadTrigger(TimeSpan.FromSeconds(0)));
                        remoteTask.SetCaptureZone(new VisibleScreen());

                        var taskResult = runnerHost.PerformTask(remoteTask);

                        Assert.IsNotNull(taskResult.PayLoad);
                     }
                }
            }
            
        }

        [TestMethod]
        public void RemoteWorker_Validate_With_MultipleTask()
        {
            var identifier = Guid.NewGuid().ToString();

            using (new ExclusiveBlock(identifier))
            {
                using (var localProcess = new LocalProcessHost(new TcpListenerPortProvider(), identifier))
                {
                    using (IWorker runnerHost = new RemoteWorker(localProcess))
                    {
                        string[] domains = {"https://google.fr/", "https://google.ca/", "https://google.com/"};

                        for (int index = 0; index < domains.Length; index++)
                        {
                            var domain = domains[index];

                            var remoteTask = new RemoteTask()
                            {
                                BrowserSize = new Size(1366, 768),
                                Url = domain,
                                Timeout = TimeSpan.FromSeconds(30)
                            };

                            remoteTask.SetTrigger(new WindowLoadTrigger(TimeSpan.FromSeconds(0)));
                            remoteTask.SetCaptureZone(new VisibleScreen());

                            var taskResult = runnerHost.PerformTask(remoteTask);

                            Assert.IsNotNull(taskResult.PayLoad);
                        }
                    }
                }
            }
        }
    }
}
