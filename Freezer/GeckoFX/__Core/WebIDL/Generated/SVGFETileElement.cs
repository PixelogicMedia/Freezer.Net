namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGFETileElement : WebIDLBase
    {
        
        public SVGFETileElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports In1
        {
            get
            {
                return this.GetProperty<nsISupports>("in1");
            }
        }
    }
}
