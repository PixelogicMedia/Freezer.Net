namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TVScanningStateChangedEvent : WebIDLBase
    {
        
        public TVScanningStateChangedEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public TVScanningState State
        {
            get
            {
                return this.GetProperty<TVScanningState>("state");
            }
        }
        
        public nsISupports Channel
        {
            get
            {
                return this.GetProperty<nsISupports>("channel");
            }
        }
    }
}
