namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGAnimatedNumberList : WebIDLBase
    {
        
        public SVGAnimatedNumberList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports BaseVal
        {
            get
            {
                return this.GetProperty<nsISupports>("baseVal");
            }
        }
        
        public nsISupports AnimVal
        {
            get
            {
                return this.GetProperty<nsISupports>("animVal");
            }
        }
    }
}
