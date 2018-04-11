namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PushEvent : WebIDLBase
    {
        
        public PushEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Data
        {
            get
            {
                return this.GetProperty<nsISupports>("data");
            }
        }
    }
}
