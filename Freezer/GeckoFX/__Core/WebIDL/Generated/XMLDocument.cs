namespace Gecko.WebIDL
{
    using System;
    
    
    internal class XMLDocument : WebIDLBase
    {
        
        public XMLDocument(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool Load(string url)
        {
            return this.CallMethod<bool>("load", url);
        }
        
        public bool Async
        {
            get
            {
                return this.GetProperty<bool>("async");
            }
            set
            {
                this.SetProperty("async", value);
            }
        }
    }
}
