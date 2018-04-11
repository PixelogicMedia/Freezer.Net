namespace Gecko.WebIDL
{
    using System;
    
    
    internal class IDBCursorWithValue : WebIDLBase
    {
        
        public IDBCursorWithValue(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Value
        {
            get
            {
                return this.GetProperty<object>("value");
            }
        }
    }
}
