namespace Gecko.WebIDL
{
    using System;
    
    
    internal class IccCardLockError : WebIDLBase
    {
        
        public IccCardLockError(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public short RetryCount
        {
            get
            {
                return this.GetProperty<short>("retryCount");
            }
        }
    }
}
