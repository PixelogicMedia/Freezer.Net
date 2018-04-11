namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozMmsEvent : WebIDLBase
    {
        
        public MozMmsEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Message
        {
            get
            {
                return this.GetProperty<nsISupports>("message");
            }
        }
    }
}
