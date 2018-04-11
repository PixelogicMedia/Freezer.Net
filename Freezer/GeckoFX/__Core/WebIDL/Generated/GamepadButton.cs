namespace Gecko.WebIDL
{
    using System;
    
    
    internal class GamepadButton : WebIDLBase
    {
        
        public GamepadButton(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool Pressed
        {
            get
            {
                return this.GetProperty<bool>("pressed");
            }
        }
        
        public double Value
        {
            get
            {
                return this.GetProperty<double>("value");
            }
        }
    }
}
