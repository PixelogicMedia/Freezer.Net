using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freezer.Core;

namespace Freezer.Mvc
{
    /// <summary>
    /// MVC extensions for ScreenshotJob
    /// </summary>
    public static class ScreenshotJobMvcExtensions
    {
        /// <summary>
        /// Convert the screenshot job to an file download ActionResult
        /// </summary>
        /// <param name="job">Screenshot job</param>
        /// <param name="downloadFileName">filename</param>
        /// <returns></returns>
        public static ActionResult FreezeActionResult(this ScreenshotJob job, string downloadFileName)
        {
            return new ScreenshotMvcResult(job, downloadFileName);
        }

        /// <summary>
        /// Forward/Remove cookies used by the current HTTPContext to the capturing web browser
        /// </summary>
        /// <param name="job">Screenshot job</param>
        /// <param name="state">if true current context will me forwarded</param>
        /// <returns></returns>
        public static ScreenshotJob SetTransfertRequestCookies(this ScreenshotJob job, bool state)
        {
            if (!state)
            {
                if (job.Cookies.Any())
                    job.Cookies = new ReadOnlyCollection<Cookie>(Enumerable.Empty<Cookie>().ToList());
            }
            else
            {
                if (job?.Context?.Cookies == null)
                    throw new InvalidOperationException("No HttpContext was found for current thread");

                var list = new List<Cookie>();

                for (int i = 0; i < job.Context.Cookies.Count; i++)
                {
                    HttpCookie cookie = job.Context.Cookies[i];
                    list.Add(CookieHelper.CreateFrom(cookie, HttpContext.Current.Request.Url.Host));
                }

                job.Cookies = new ReadOnlyCollection<Cookie>(list);
            }

            return job;
        }

        /// <summary>
        /// Forward "Accept-Languages" header used by the current HTTPContext to Freezer capturing browser
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static ScreenshotJob UseRequestLanguages(this ScreenshotJob job)
        {
            if (job.Context == null)
                throw new InvalidOperationException("No HttpContext was found for current thread");

            job.SetAcceptLanguages(job.Context.AcceptLanguages);
            return job;
        }
    }
}