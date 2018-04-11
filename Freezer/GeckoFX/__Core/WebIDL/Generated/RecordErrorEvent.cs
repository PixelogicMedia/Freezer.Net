namespace Gecko.WebIDL
{
    using System;
    
    
    internal class RecordErrorEvent : WebIDLBase
    {
        
        public RecordErrorEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Name
        {
            get
            {
                return this.GetProperty<string>("name");
            }
        }
    }
}
