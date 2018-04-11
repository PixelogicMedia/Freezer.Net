using Freezer.Engines;
using Freezer.Pools;

namespace Freezer.Core
{
    internal class WorkerPoolEngineProvider : IEngineProvider
    {
        public CaptureEngine CreateEngine(ScreenshotJob task)
        {
            return new WorkerEngine(task.BrowserSize, task.Trigger, task.CaptureZone, FreezerGlobal.Workers);
        }
    }
}