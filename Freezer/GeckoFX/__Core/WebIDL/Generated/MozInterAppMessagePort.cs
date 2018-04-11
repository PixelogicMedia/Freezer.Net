namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozInterAppMessagePort : WebIDLBase
    {
        
        public MozInterAppMessagePort(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void PostMessage(object message)
        {
            this.CallVoidMethod("postMessage", message);
        }
        
        public void Start()
        {
            this.CallVoidMethod("start");
        }
        
        public void Close()
        {
            this.CallVoidMethod("close");
        }
    }
}
