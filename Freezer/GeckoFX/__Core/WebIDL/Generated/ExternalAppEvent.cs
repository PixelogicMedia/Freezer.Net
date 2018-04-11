namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ExternalAppEvent : WebIDLBase
    {
        
        public ExternalAppEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Data
        {
            get
            {
                return this.GetProperty<string>("data");
            }
        }
    }
}
