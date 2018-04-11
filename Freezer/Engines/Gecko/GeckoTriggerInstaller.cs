using System;
using Freezer.Core;
using Gecko;
using Gecko.Events;

namespace Freezer.Engines.Gecko
{
    internal class GeckoTriggerInstaller : TriggerInstaller
    {
        private readonly GeckoWebBrowser _webBrowser;
        private bool _messageEventHasBeenSetup; 

        public override EventHandler<EventArgs> OnLoad { get; set; }

        public override EventHandler<EventArgs> OnDomReady { get; set; }

        public override EventHandler<EventArgs> OnNavigationError { get; set; }

        public override EventHandler<EventArgs> OnFreezerFireDispatch { get; set; }

        public GeckoTriggerInstaller(GeckoWebBrowser webBrowser) : 
            base (webBrowser)
        {
            this._webBrowser = webBrowser; 

            webBrowser.Load += WebBrowserOnLoad;
            webBrowser.DocumentCompleted += WebBrowserOnDocumentCompleted;
            webBrowser.NavigationError += WebBrowserOnNavigationError;
            webBrowser.Navigating += WebBrowserOnNavigating;
           
        }

        private void WebBrowserOnNavigating(object sender, GeckoNavigatingEventArgs geckoNavigatingEventArgs)
        {
            if (!_messageEventHasBeenSetup)
            {
                _webBrowser.AddMessageEventListener("FreezerFire", WebBrowserOnFreezerFireDispach);
                _messageEventHasBeenSetup = true;
            }
        }

        private void WebBrowserOnFreezerFireDispach(string arg)
        {
            if (OnFreezerFireDispatch != null)
                OnFreezerFireDispatch(_webBrowser, new EventArgs());
        }

        private void WebBrowserOnNavigationError(object sender, GeckoNavigationErrorEventArgs geckoNavigationErrorEventArgs)
        {
            if (OnNavigationError != null)
                OnNavigationError(sender, geckoNavigationErrorEventArgs);
        }

        private void WebBrowserOnDocumentCompleted(object sender, GeckoDocumentCompletedEventArgs geckoDocumentCompletedEventArgs)
        {
            if (OnDomReady != null)
                OnDomReady(sender, geckoDocumentCompletedEventArgs);
        }

        private void WebBrowserOnLoad(object sender, DomEventArgs domEventArgs)
        {
            if (OnLoad != null)
                OnLoad(sender, null); 
        }

        public override void Dispose()
        {
            _webBrowser.Load -= WebBrowserOnLoad;
            _webBrowser.DocumentCompleted -= WebBrowserOnDocumentCompleted;
            _webBrowser.NavigationError -= WebBrowserOnNavigationError;
            _webBrowser.Navigating -= WebBrowserOnNavigating;
        }
    }
}