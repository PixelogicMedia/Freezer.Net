using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Gecko.DOM
{
    internal class GeckoHeadElement : GeckoHtmlElement
    {
        private nsIDOMHTMLHeadElement DOMHTMLElement;

        internal GeckoHeadElement(nsIDOMHTMLHeadElement element) : base(element)
        {
            this.DOMHTMLElement = element;
        }

        public GeckoHeadElement(object element) : base(element as nsIDOMHTMLElement)
        {
            this.DOMHTMLElement = element as nsIDOMHTMLHeadElement;
        }
    }
}