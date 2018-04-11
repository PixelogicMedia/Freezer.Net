namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozAbortablePromise : WebIDLBase
    {
        
        public MozAbortablePromise(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void Abort()
        {
            this.CallVoidMethod("abort");
        }
    }
}
