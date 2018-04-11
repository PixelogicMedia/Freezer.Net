namespace Gecko.WebIDL
{
    using System;
    
    
    internal class DOMTransactionEvent : WebIDLBase
    {
        
        public DOMTransactionEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Transactions
        {
            get
            {
                return this.GetProperty<object>("transactions");
            }
        }
    }
}
