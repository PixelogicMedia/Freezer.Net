namespace Gecko.WebIDL
{
    using System;
    
    
    internal class GamepadButtonEvent : WebIDLBase
    {
        
        public GamepadButtonEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint Button
        {
            get
            {
                return this.GetProperty<uint>("button");
            }
        }
    }
}
