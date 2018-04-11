namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MessagePortList : WebIDLBase
    {
        
        public MessagePortList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint Length
        {
            get
            {
                return this.GetProperty<uint>("length");
            }
        }
    }
}
