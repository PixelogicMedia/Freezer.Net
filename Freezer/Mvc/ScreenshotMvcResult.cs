using System.Web;
using System.Web.Mvc;
using Freezer.Core;

namespace Freezer.Mvc
{
    public class ScreenshotMvcResult : FileResult
    {
        private readonly byte[] _lazyData;

        internal ScreenshotMvcResult(ScreenshotJob task) 
            : this(task, null)
        {
        }

        internal ScreenshotMvcResult(ScreenshotJob task, string downloadFileName) 
            : base("image/png")
        {
            _lazyData = task.Freeze();

            if (downloadFileName != null)
                FileDownloadName = downloadFileName;
        }

        internal ScreenshotMvcResult(byte [] result)
            : this(result, null)
        {
        }

        internal ScreenshotMvcResult(byte [] result, string downloadFileName)
            : base("image/png")
        {
            _lazyData = result;

            if (downloadFileName != null)
                FileDownloadName = downloadFileName;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            response.OutputStream.Write(_lazyData, 0, _lazyData.Length);
        }
    }
}
