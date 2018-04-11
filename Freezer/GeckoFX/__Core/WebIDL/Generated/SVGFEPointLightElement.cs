namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGFEPointLightElement : WebIDLBase
    {
        
        public SVGFEPointLightElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports X
        {
            get
            {
                return this.GetProperty<nsISupports>("x");
            }
        }
        
        public nsISupports Y
        {
            get
            {
                return this.GetProperty<nsISupports>("y");
            }
        }
        
        public nsISupports Z
        {
            get
            {
                return this.GetProperty<nsISupports>("z");
            }
        }
    }
}
