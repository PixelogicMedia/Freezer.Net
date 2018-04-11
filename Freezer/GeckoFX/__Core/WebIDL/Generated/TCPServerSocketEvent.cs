namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TCPServerSocketEvent : WebIDLBase
    {
        
        public TCPServerSocketEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Socket
        {
            get
            {
                return this.GetProperty<nsISupports>("socket");
            }
        }
    }
}
