namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGURIReference : WebIDLBase
    {
        
        public SVGURIReference(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Href
        {
            get
            {
                return this.GetProperty<nsISupports>("href");
            }
        }
    }
}
