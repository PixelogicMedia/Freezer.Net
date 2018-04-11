namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TCPSocketEvent : WebIDLBase
    {
        
        public TCPSocketEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Data
        {
            get
            {
                return this.GetProperty<object>("data");
            }
        }
    }
}
