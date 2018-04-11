namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozCellBroadcastEvent : WebIDLBase
    {
        
        public MozCellBroadcastEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
