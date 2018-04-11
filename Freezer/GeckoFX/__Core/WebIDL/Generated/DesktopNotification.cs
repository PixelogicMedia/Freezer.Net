namespace Gecko.WebIDL
{
    using System;
    
    
    internal class DesktopNotification : WebIDLBase
    {
        
        public DesktopNotification(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void Show()
        {
            this.CallVoidMethod("show");
        }
    }
}
