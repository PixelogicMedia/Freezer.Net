namespace Gecko.WebIDL
{
    using System;
    
    
    internal class AutocompleteErrorEvent : WebIDLBase
    {
        
        public AutocompleteErrorEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public AutoCompleteErrorReason Reason
        {
            get
            {
                return this.GetProperty<AutoCompleteErrorReason>("reason");
            }
        }
    }
}
