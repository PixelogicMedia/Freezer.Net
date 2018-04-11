namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BluetoothMapMessageUpdateEvent : WebIDLBase
    {
        
        public BluetoothMapMessageUpdateEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint InstanceId
        {
            get
            {
                return this.GetProperty<uint>("instanceId");
            }
        }
        
        public nsISupports Handle
        {
            get
            {
                return this.GetProperty<nsISupports>("handle");
            }
        }
    }
}
