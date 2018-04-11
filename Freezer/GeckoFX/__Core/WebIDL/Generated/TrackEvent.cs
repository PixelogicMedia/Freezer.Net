namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TrackEvent : WebIDLBase
    {
        
        public TrackEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public WebIDLUnion<nsISupports,nsISupports,nsISupports> Track
        {
            get
            {
                return this.GetProperty<WebIDLUnion<nsISupports,nsISupports,nsISupports>>("track");
            }
        }
    }
}
