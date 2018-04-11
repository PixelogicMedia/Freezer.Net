namespace Gecko.Net
{
    internal class IncrementalDownload
        : Request
    {
        private nsIIncrementalDownload _incrementalDownload;

        public IncrementalDownload(nsIIncrementalDownload incrementalDownload)
            : base(incrementalDownload)
        {
            _incrementalDownload = incrementalDownload;
        }
    }
}