namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGComponentTransferFunctionElement : WebIDLBase
    {
        
        public SVGComponentTransferFunctionElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Type
        {
            get
            {
                return this.GetProperty<nsISupports>("type");
            }
        }
        
        public nsISupports TableValues
        {
            get
            {
                return this.GetProperty<nsISupports>("tableValues");
            }
        }
        
        public nsISupports Slope
        {
            get
            {
                return this.GetProperty<nsISupports>("slope");
            }
        }
        
        public nsISupports Intercept
        {
            get
            {
                return this.GetProperty<nsISupports>("intercept");
            }
        }
        
        public nsISupports Amplitude
        {
            get
            {
                return this.GetProperty<nsISupports>("amplitude");
            }
        }
        
        public nsISupports Exponent
        {
            get
            {
                return this.GetProperty<nsISupports>("exponent");
            }
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
