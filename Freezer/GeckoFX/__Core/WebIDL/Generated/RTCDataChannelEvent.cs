namespace Gecko.WebIDL
{
    using System;
    
    
    internal class RTCDataChannelEvent : WebIDLBase
    {
        
        public RTCDataChannelEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
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
