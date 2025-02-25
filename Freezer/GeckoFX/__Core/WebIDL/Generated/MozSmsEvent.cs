namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozSmsEvent : WebIDLBase
    {
        
        public MozSmsEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
