namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TCPSocketErrorEvent : WebIDLBase
    {
        
        public TCPSocketErrorEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Name
        {
            get
            {
                return this.GetProperty<string>("name");
            }
        }
        
        public string Message
        {
            get
            {
                return this.GetProperty<string>("message");
            }
        }
    }
}
