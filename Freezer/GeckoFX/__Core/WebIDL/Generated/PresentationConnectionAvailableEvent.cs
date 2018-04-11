namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PresentationConnectionAvailableEvent : WebIDLBase
    {
        
        public PresentationConnectionAvailableEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Connection
        {
            get
            {
                return this.GetProperty<nsISupports>("connection");
            }
        }
    }
}
