namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BlobEvent : WebIDLBase
    {
        
        public BlobEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsIDOMBlob Data
        {
            get
            {
                return this.GetProperty<nsIDOMBlob>("data");
            }
        }
    }
}
