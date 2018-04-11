namespace Gecko.WebIDL
{
    using System;
    
    
    internal class WindowProxy : WebIDLBase
    {
        
        public WindowProxy(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
    }
}
