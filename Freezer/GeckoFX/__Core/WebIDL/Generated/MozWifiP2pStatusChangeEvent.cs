namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozWifiP2pStatusChangeEvent : WebIDLBase
    {
        
        public MozWifiP2pStatusChangeEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string PeerAddress
        {
            get
            {
                return this.GetProperty<string>("peerAddress");
            }
        }
    }
}
