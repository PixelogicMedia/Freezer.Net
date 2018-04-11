namespace Gecko.WebIDL
{
    using System;
    
    
    internal class GlobalCrypto : WebIDLBase
    {
        
        public GlobalCrypto(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Crypto
        {
            get
            {
                return this.GetProperty<nsISupports>("crypto");
            }
        }
    }
}
