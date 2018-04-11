namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MediaStreamEvent : WebIDLBase
    {
        
        public MediaStreamEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Stream
        {
            get
            {
                return this.GetProperty<nsISupports>("stream");
            }
        }
    }
}
