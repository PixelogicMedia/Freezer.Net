namespace Gecko.WebIDL
{
    using System;
    
    
    internal class RTCPeerConnectionIceEvent : WebIDLBase
    {
        
        public RTCPeerConnectionIceEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Candidate
        {
            get
            {
                return this.GetProperty<nsISupports>("candidate");
            }
        }
    }
}
