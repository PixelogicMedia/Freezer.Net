namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TVEITBroadcastedEvent : WebIDLBase
    {
        
        public TVEITBroadcastedEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports[] Programs
        {
            get
            {
                return this.GetProperty<nsISupports[]>("programs");
            }
        }
    }
}
