using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Freezer.Core;
using Freezer.Pools;
using Freezer.UnitTests.TestCases.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freezer.UnitTests.TestCases.Workers
{
    [TestClass]
    public class WorkerEngineTests
    {
        private static IWorkerPool<IWorker> _testedPool; 

        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            IWorkerFactory<IWorker> workerFactory = new LocalWorkerFactory();
            _testedPool = FreezerGlobal.Workers;
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            //_testedPool.Dispose();
        }

        [TestMethod]
        public void WorkerPool_Validate_Maximum_Size()
        {
            IList<IWorker> workers = new List<IWorker>();

            try
            {
                // Arrange
                int workerCount = 0;
                IWorker currentWorker = null; 

                // Act
                while ((currentWorker = _testedPool.Peek()) != null)
                {
                    workerCount++;
                    workers.Add(currentWorker);
                }

                // Assert
                Assert.AreEqual(10, workerCount);
            }
            finally
            {
                foreach (var worker in workers)
                {
                    _testedPool.Return(worker, false);
                }
            }
        }
        
        [TestMethod]
        public void WorkerEngine_Multiple_Sequential_WebPages()
        {
            for (int i = 0; i < 5; i++)
            {
                using (var workerEngine = new WorkerEngine(new Size(1366, 768), new WindowLoadTrigger(), new VisibleScreen(), _testedPool))
                {
                    var image = workerEngine.CaptureUrl("https://google.com");

                    TestUtils.SaveBitmap(image, nameof(WorkerEngineTests), nameof(WorkerEngine_Multiple_Sequential_WebPages) + "Sequential" + i);
                }
            }
        }

        [TestMethod]
        public void WorkerEngine_Multiple_Parallel_WebPages()
        {
            Parallel.For(0, 5, i =>
            {
                using (var workerEngine = new WorkerEngine(new Size(1366, 768), new WindowLoadTrigger(), new VisibleScreen(), _testedPool))
                {
                    var image = workerEngine.CaptureUrl("https://google.com");
                    TestUtils.SaveBitmap(image, nameof(WorkerEngineTests), nameof(WorkerEngine_Multiple_Parallel_WebPages) + "Parrallel" + i);
                }
            }); 
        }
    }
}
