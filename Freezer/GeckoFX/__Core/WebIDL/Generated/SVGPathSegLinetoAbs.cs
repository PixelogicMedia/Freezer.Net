namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGPathSegLinetoAbs : WebIDLBase
    {
        
        public SVGPathSegLinetoAbs(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
        
        public float Y
        {
            get
            {
                return this.GetProperty<float>("y");
            }
            set
            {
                this.SetProperty("y", value);
            }
        }
    }
}
