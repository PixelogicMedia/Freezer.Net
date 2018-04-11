namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BluetoothDeviceEvent : WebIDLBase
    {
        
        public BluetoothDeviceEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Device
        {
            get
            {
                return this.GetProperty<nsISupports>("device");
            }
        }
        
        public string Address
        {
            get
            {
                return this.GetProperty<string>("address");
            }
        }
    }
}
