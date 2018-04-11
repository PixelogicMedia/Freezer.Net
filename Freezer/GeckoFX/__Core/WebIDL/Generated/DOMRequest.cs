namespace Gecko.WebIDL
{
    using System;
    
    
    internal class DOMRequest : WebIDLBase
    {
        
        public DOMRequest(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Then()
        {
            return this.CallMethod<object>("then");
        }
    }
}
