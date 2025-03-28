namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGPathSegLinetoHorizontalAbs : WebIDLBase
    {
        
        public SVGPathSegLinetoHorizontalAbs(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public float X
        {
            get
            {
                return this.GetProperty<float>("x");
            }
            set
            {
                this.SetProperty("x", value);
            }
        }
    }
}
