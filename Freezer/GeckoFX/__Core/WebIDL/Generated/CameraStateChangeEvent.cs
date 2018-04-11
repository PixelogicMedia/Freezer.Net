namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CameraStateChangeEvent : WebIDLBase
    {
        
        public CameraStateChangeEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string NewState
        {
            get
            {
                return this.GetProperty<string>("newState");
            }
        }
    }
}
