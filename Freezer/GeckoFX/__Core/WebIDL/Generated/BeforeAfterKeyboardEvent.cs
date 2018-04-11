namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BeforeAfterKeyboardEvent : WebIDLBase
    {
        
        public BeforeAfterKeyboardEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public System.Nullable<bool> EmbeddedCancelled
        {
            get
            {
                return this.GetProperty<System.Nullable<bool>>("embeddedCancelled");
            }
        }
    }
}
