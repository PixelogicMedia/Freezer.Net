namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozSettingsTransactionEvent : WebIDLBase
    {
        
        public MozSettingsTransactionEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Error
        {
            get
            {
                return this.GetProperty<string>("error");
            }
        }
    }
}
