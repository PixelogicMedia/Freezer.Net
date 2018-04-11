namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PresentationAvailability : WebIDLBase
    {
        
        public PresentationAvailability(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool Value
        {
            get
            {
                return this.GetProperty<bool>("value");
            }
        }
    }
}
