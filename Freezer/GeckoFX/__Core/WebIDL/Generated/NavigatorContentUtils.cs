namespace Gecko.WebIDL
{
    using System;
    
    
    internal class NavigatorContentUtils : WebIDLBase
    {
        
        public NavigatorContentUtils(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void RegisterProtocolHandler(string scheme, string url, string title)
        {
            this.CallVoidMethod("registerProtocolHandler", scheme, url, title);
        }
        
        public void RegisterContentHandler(string mimeType, string url, string title)
        {
            this.CallVoidMethod("registerContentHandler", mimeType, url, title);
        }
    }
}
