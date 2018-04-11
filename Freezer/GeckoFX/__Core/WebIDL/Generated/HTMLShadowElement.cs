namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLShadowElement : WebIDLBase
    {
        
        public HTMLShadowElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports OlderShadowRoot
        {
            get
            {
                return this.GetProperty<nsISupports>("olderShadowRoot");
            }
        }
    }
}
