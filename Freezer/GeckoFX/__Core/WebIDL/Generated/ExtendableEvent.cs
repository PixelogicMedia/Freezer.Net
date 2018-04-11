namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ExtendableEvent : WebIDLBase
    {
        
        public ExtendableEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void WaitUntil(Promise <object> p)
        {
            this.CallVoidMethod("waitUntil", p);
        }
    }
}
