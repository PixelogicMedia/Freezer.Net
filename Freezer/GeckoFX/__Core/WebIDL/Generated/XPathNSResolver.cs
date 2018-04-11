namespace Gecko.WebIDL
{
    using System;
    
    
    internal class XPathNSResolver : WebIDLBase
    {
        
        public XPathNSResolver(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string LookupNamespaceURI(string prefix)
        {
            return this.CallMethod<string>("lookupNamespaceURI", prefix);
        }
    }
}
