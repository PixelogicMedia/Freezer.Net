namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MediaKeyError : WebIDLBase
    {
        
        public MediaKeyError(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint SystemCode
        {
            get
            {
                return this.GetProperty<uint>("systemCode");
            }
        }
    }
}
