using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace Freezer.Core
{
    /// <summary>
    /// This partial class define the fluent methods to customize ScreenshotJob
    /// </summary>
    partial class ScreenshotJob
    {
        /// <summary>
        /// Add a cookie to the capturing web browser
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public ScreenshotJob AddCookie(Cookie cookie)
        {
            var currentList = Cookies.ToList();
            currentList.Add(cookie);
            Cookies = new ReadOnlyCollection<Cookie>(currentList);
            return this;
        }

        /// <summary>
        /// Clear all cookies in the browser
        /// </summary>
        /// <returns></returns>
        public ScreenshotJob ClearCookies()
        {
            if (Cookies.Any())
                Cookies = new ReadOnlyCollection<Cookie>(Enumerable.Empty<Cookie>().ToList());

            return this;
        }

        /// <summary>
        /// Defines the browser size using System.Drawing.Size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public ScreenshotJob SetBrowserSize(Size size)
        {
            if (size.Width <= 0 || size.Height <= 0)
                throw new ArgumentException("Browser width and height should be > 0", nameof(size));

            BrowserSize = size;
            return this;
        }

        /// <summary>
        /// Defines the browser size 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ScreenshotJob SetBrowserSize(int width, int height)
        {
            return SetBrowserSize(new Size(width, height));
        }

        /// <summary>
        /// Defines when the capture should be taken
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public ScreenshotJob SetTrigger(Trigger trigger)
        {
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));

            Trigger = trigger;
            return this;
        }

        /// <summary>
        /// Defines which part of the page will be captured
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public ScreenshotJob SetCaptureZone(CaptureZone zone)
        {
            if (zone == null)
                throw new ArgumentNullException(nameof(zone));

            CaptureZone = zone;
            return this;
        }

        /// <summary>
        /// Defines timeout until the trigger is fired.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public ScreenshotJob SetTimeout(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
                throw new ArgumentException("timeout value is invalid", nameof(timeout));

            Timeout = timeout;
            return this;
        }

        /// <summary>
        /// Defines timeout until the trigger is fired in milliseconds
        /// </summary>
        /// <param name="timeouMilliseconds"></param>
        /// <returns></returns>
        public ScreenshotJob SetTimeout(int timeouMilliseconds)
        {
            return SetTimeout(TimeSpan.FromMilliseconds(timeouMilliseconds));
        }

        /// <summary>
        /// Defines "Accept-Languages" header of the web browser
        /// </summary>
        /// <param name="acceptLanguages"></param>
        /// <returns></returns>
        public ScreenshotJob SetAcceptLanguages(string acceptLanguages)
        {
            if (acceptLanguages == null)
                throw new ArgumentNullException(nameof(acceptLanguages));

            AcceptLanguages = acceptLanguages;
            return this;
        }

        /// <summary>
        /// Sets the user agent used by the browser
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public ScreenshotJob SetUserAgent(string userAgent)
        {
            if (userAgent == null)
                throw new ArgumentNullException(nameof(userAgent));

            UserAgent = userAgent;
            return this;
        }

        /// <summary>
        /// Creates a screenshot for the current job
        /// </summary>
        /// <returns></returns>
        public Screenshot Freeze()
        {
            return new Screenshot(_binder.ProduceImage(this));
        }
    }
}
