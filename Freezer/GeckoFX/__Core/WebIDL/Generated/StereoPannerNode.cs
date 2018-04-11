namespace Gecko.WebIDL
{
    using System;
    
    
    internal class StereoPannerNode : WebIDLBase
    {
        
        public StereoPannerNode(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Pan
        {
            get
            {
                return this.GetProperty<nsISupports>("pan");
            }
        }
    }
}
