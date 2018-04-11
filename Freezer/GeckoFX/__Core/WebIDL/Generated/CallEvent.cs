namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CallEvent : WebIDLBase
    {
        
        public CallEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Call
        {
            get
            {
                return this.GetProperty<nsISupports>("call");
            }
        }
    }
}
