namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TCPServerSocket : WebIDLBase
    {
        
        public TCPServerSocket(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public ushort LocalPort
        {
            get
            {
                return this.GetProperty<ushort>("localPort");
            }
        }
        
        public void Close()
        {
            this.CallVoidMethod("close");
        }
    }
}
