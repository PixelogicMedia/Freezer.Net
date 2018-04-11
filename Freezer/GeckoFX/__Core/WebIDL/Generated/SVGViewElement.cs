namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGViewElement : WebIDLBase
    {
        
        public SVGViewElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports ViewTarget
        {
            get
            {
                return this.GetProperty<nsISupports>("viewTarget");
            }
        }
    }
}
