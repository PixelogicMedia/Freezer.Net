using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Freezer.Core;

namespace Freezer.Engines
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class CaptureEngine : MarshalByRefObject, IDisposable
    {
        /// <summary>
        /// This defines the default image format used by CaptureEngine when
        /// </summary>
        private readonly ImageFormat _defaultImageFormat = ImageFormat.Png; 

        /// <summary>
        /// This is the default capture Timeout when not specified
        /// </summary>
        public static readonly TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(60); 

        protected CaptureEngine(Size browserSize, Trigger trigger, CaptureZone captureZone)
        {
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));

            if (captureZone == null)
                throw new ArgumentNullException(nameof(captureZone));

            if (browserSize.IsEmpty || browserSize.Width <= 0 || browserSize.Height <= 0)
                throw new ArgumentException($"{nameof(browserSize)} surface must be > 0", nameof(browserSize));

            BrowserSize = browserSize;
            Trigger = trigger;
            CaptureZone = captureZone; 
        }

        /// <summary>
        /// Size of the browser's document
        /// </summary>
        public Size BrowserSize { get; } 

        /// <summary>
        /// Specify when the screenshot is taken
        /// </summary>
        public Trigger Trigger { get;  }

        /// <summary>
        /// Specify the capture zone of the screenshot
        /// </summary>
        public CaptureZone CaptureZone { get; }

        /// <summary>
        /// Cookies to be transfered to the browser
        /// </summary>
        public ICollection<Cookie> Cookies { get; } = new List<Cookie>();

        /// <summary>
        /// The accepted language header. Eg: fr 
        /// </summary>
        public string AcceptLanguages { get; set; }

        /// <summary>
        /// User agent used by the browser, if null default is use
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Capture URL.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public abstract Image CaptureUrl(string baseUrl, TimeSpan timeOut);

        /// <summary>
        /// Capture URL as byte [] image array
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public virtual byte[] CaptureRawUrl(string baseUrl, TimeSpan timeOut)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var image = CaptureUrl(baseUrl, timeOut))
                {
                    image.Save(memoryStream, _defaultImageFormat);
                    return memoryStream.ToArray();
                }
            }
        }

        /// <summary>
        /// Capture URL.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public virtual Image CaptureUrl(string baseUrl)
        {
            return CaptureUrl(baseUrl, DefaultTimeOut); 
        }
        
        /// <summary>
        ///  Capture URL async
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public virtual async Task<Image> CaptureUrlAsync(string baseUrl)
        {
            return await Task.Run(() => CaptureUrl(baseUrl));
        }
        

        public virtual void Dispose()
        {
        }
    }
}