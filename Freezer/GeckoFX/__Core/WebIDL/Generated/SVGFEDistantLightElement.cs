namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGFEDistantLightElement : WebIDLBase
    {
        
        public SVGFEDistantLightElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Azimuth
        {
            get
            {
                return this.GetProperty<nsISupports>("azimuth");
            }
        }
        
        public nsISupports Elevation
        {
            get
            {
                return this.GetProperty<nsISupports>("elevation");
            }
        }
    }
}
