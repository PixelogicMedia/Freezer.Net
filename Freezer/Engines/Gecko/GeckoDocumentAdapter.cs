using System;
using System.Drawing;
using System.Globalization;
using Freezer.Core;
using Gecko;

namespace Freezer.Engines.Gecko
{
    internal class GeckoDocumentAdapter : MarshalByRefObject, IActiveDocument
    {
        private readonly GeckoWebBrowser _webBrowser;

        internal GeckoDocumentAdapter(GeckoWebBrowser webBrowser)
        {
            if (webBrowser == null)
                throw new ArgumentNullException(nameof(webBrowser));

            this._webBrowser = webBrowser; 
        }

        public Size BrowserSize
        {
            get
            {
                return _webBrowser.Size;
            }
        }

        public Rectangle DocumentSize
        {
            get
            {
                if (_webBrowser?.Document?.ActiveElement?.ScrollHeight == null)
                    return Rectangle.Empty;

                int x =
                    (int)
                        Math.Round(Convert.ToDouble(RunJs("document.body.getBoundingClientRect().x"),
                            CultureInfo.InvariantCulture));
                int y =
                    (int)
                        Math.Round(Convert.ToDouble(RunJs("document.body.getBoundingClientRect().y"),
                            CultureInfo.InvariantCulture));
                
                int height = (int)double.Parse(RunJs("document.body.scrollHeight"), CultureInfo.InvariantCulture);
                int width = (int)double.Parse(RunJs("document.body.scrollWidth"), CultureInfo.InvariantCulture);

                return new Rectangle(x, y, width, height);

            }
        }

        public string RunJs(string jsCode)
        {
            using (AutoJSContext context = new AutoJSContext(_webBrowser.Window))
            {
                string evalResult; 
                context.EvaluateScript(jsCode, (nsISupports) _webBrowser.Window.DomWindow, out evalResult);
                return evalResult; 
            }
        }
    }
}