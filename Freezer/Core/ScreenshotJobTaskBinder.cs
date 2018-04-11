namespace Freezer.Core
{
    internal class ScreenshotJobTaskBinder
    {
        private readonly IEngineProvider _engineProvider;

        public ScreenshotJobTaskBinder(IEngineProvider engineProvider)
        {
            _engineProvider = engineProvider;
        }

        public byte [] ProduceImage(ScreenshotJob task)
        {
            using (var workerEngine = _engineProvider.CreateEngine(task))
            {
                foreach (var cookie in task.Cookies)
                {
                    workerEngine.Cookies.Add(cookie);
                }

                workerEngine.AcceptLanguages = task.AcceptLanguages;
                workerEngine.UserAgent = task.UserAgent;

                return workerEngine.CaptureRawUrl(task.FinalUri, task.Timeout);
            }
        }
    }
}