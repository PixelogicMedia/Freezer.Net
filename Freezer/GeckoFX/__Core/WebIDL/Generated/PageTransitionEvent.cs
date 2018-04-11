namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PageTransitionEvent : WebIDLBase
    {
        
        public PageTransitionEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool Persisted
        {
            get
            {
                return this.GetProperty<bool>("persisted");
            }
        }
    }
}
