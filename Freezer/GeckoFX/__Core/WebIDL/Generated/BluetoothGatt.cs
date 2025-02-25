namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BluetoothGatt : WebIDLBase
    {
        
        public BluetoothGatt(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports[] Services
        {
            get
            {
                return this.GetProperty<nsISupports[]>("services");
            }
        }
        
        public BluetoothConnectionState ConnectionState
        {
            get
            {
                return this.GetProperty<BluetoothConnectionState>("connectionState");
            }
        }
        
        public Promise Connect()
        {
            return this.CallMethod<Promise>("connect");
        }
        
        public Promise Disconnect()
        {
            return this.CallMethod<Promise>("disconnect");
        }
        
        public Promise DiscoverServices()
        {
            return this.CallMethod<Promise>("discoverServices");
        }
        
        public Promise <short> ReadRemoteRssi()
        {
            return this.CallMethod<Promise <short>>("readRemoteRssi");
        }
    }
}
