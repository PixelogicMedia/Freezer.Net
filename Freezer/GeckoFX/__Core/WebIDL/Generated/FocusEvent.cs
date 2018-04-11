namespace Gecko.WebIDL
{
    using System;
    
    
    internal class FocusEvent : WebIDLBase
    {
        
        public FocusEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports RelatedTarget
        {
            get
            {
                return this.GetProperty<nsISupports>("relatedTarget");
            }
        }
    }
}
