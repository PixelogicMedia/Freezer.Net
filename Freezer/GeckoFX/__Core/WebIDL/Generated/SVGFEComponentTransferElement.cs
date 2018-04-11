namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGFEComponentTransferElement : WebIDLBase
    {
        
        public SVGFEComponentTransferElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
