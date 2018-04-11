namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLDataListElement : WebIDLBase
    {
        
        public HTMLDataListElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Options
        {
            get
            {
                return this.GetProperty<nsISupports>("options");
            }
        }
    }
}
