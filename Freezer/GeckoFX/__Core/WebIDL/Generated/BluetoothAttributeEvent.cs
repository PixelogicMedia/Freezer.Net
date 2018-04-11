namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BluetoothAttributeEvent : WebIDLBase
    {
        
        public BluetoothAttributeEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string[] Attrs
        {
            get
            {
                return this.GetProperty<string[]>("attrs");
            }
        }
    }
}
