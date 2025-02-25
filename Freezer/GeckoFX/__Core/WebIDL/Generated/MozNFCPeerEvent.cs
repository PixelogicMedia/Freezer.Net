namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozNFCPeerEvent : WebIDLBase
    {
        
        public MozNFCPeerEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Peer
        {
            get
            {
                return this.GetProperty<nsISupports>("peer");
            }
        }
    }
}
