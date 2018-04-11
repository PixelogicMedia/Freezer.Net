namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGFEImageElement : WebIDLBase
    {
        
        public SVGFEImageElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports PreserveAspectRatio
        {
            get
            {
                return this.GetProperty<nsISupports>("preserveAspectRatio");
            }
        }
    }
}
