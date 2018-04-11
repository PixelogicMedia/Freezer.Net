using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Freezer.Mvc;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a screenshot task
    /// </summary>
    public sealed partial class ScreenshotJob
    {
        private readonly IScreenshotContext _screenshotContext;
        private readonly ScreenshotJobTaskBinder _binder; 
        private readonly string _finalUri;

        internal ScreenshotJob(string finalUri)
            : this (finalUri, new ScreenshotJobTaskBinder(new WorkerPoolEngineProvider()))
        {
            
        }

        internal ScreenshotJob(string finalUri, ScreenshotJobTaskBinder binder)
        { 
            _finalUri = finalUri;
            _binder = binder;

            var currentConfiguration = FreezerGlobal.CurrentConfiguration;

            AcceptLanguages = currentConfiguration.AcceptLanguages;
            UserAgent = currentConfiguration.DefaultUserAgent;
            BrowserSize = new Size(currentConfiguration.DefaultWidth, currentConfiguration.DefaultHeight);
            Timeout = TimeSpan.FromSeconds(currentConfiguration.CaptureTimeoutSeconds);
        }

        internal ScreenshotJob(string finalUri, IScreenshotContext screenshotContext)
            : this (finalUri)
        {
            _screenshotContext = screenshotContext;
        }

        internal ScreenshotJob(string finalUri, ScreenshotJobTaskBinder binder, IScreenshotContext screenshotContext)
            : this(finalUri, binder)
        {
            _screenshotContext = screenshotContext;
        }

        /// <summary>
        /// Gets "Accept-languages" header of the browser. By default "en" will be used
        /// </summary>
        public string AcceptLanguages { get; private set; }

        /// <summary>
        /// Gets User agent used by the browser
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// Gets Browser size
        /// </summary>
        public Size BrowserSize { get; private set; }

        /// <summary>
        /// Gets when the screenshot is fired. By default, the screenshot will fired on window.load()
        /// </summary>
        public Trigger Trigger { get; private set; } = new WindowLoadTrigger();

        /// <summary>
        /// Gets the capture zone. By default, entire document will be used
        /// </summary>
        public CaptureZone CaptureZone { get; private set; } = new VisibleScreen();

        /// <summary>
        /// Gets the timeout until the trigger is fired
        /// </summary>
        public TimeSpan Timeout { get; private set; }

        /// <summary>
        /// Get the Cookies used by the current screenshotjob 
        /// </summary>
        public IReadOnlyCollection<Cookie>  Cookies { get; internal set; } = new ReadOnlyCollection<Cookie>(Enumerable.Empty<Cookie>().ToList());
        
        /// <summary>
        /// Gets the final uri used by this job
        /// </summary>
        public string FinalUri
        {
            get { return _finalUri; }
        }

        internal IScreenshotContext Context
        {
            get { return _screenshotContext; }
        }
    }
}
