namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGStopElement : WebIDLBase
    {
        
        public SVGStopElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Offset
        {
            get
            {
                return this.GetProperty<nsISupports>("offset");
            }
        }
    }
}
