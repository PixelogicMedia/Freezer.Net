using Freezer.Engines;

namespace Freezer.Core
{
    /// <summary>
    /// This interface aims to represent a worker engine provider for 
    /// a relevant screenshotjob
    /// </summary>
    internal interface IEngineProvider
    {
        CaptureEngine CreateEngine(ScreenshotJob task);
    }
}