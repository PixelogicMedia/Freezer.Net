namespace Gecko.WebIDL
{
    using System;
    
    
    internal class IDBCursor : WebIDLBase
    {
        
        public IDBCursor(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public WebIDLUnion<nsISupports,nsISupports> Source
        {
            get
            {
                return this.GetProperty<WebIDLUnion<nsISupports,nsISupports>>("source");
            }
        }
        
        public IDBCursorDirection Direction
        {
            get
            {
                return this.GetProperty<IDBCursorDirection>("direction");
            }
        }
        
        public object Key
        {
            get
            {
                return this.GetProperty<object>("key");
            }
        }
        
        public object PrimaryKey
        {
            get
            {
                return this.GetProperty<object>("primaryKey");
            }
        }
        
        public nsISupports Update(object value)
        {
            return this.CallMethod<nsISupports>("update", value);
        }
        
        public void Advance(uint count)
        {
            this.CallVoidMethod("advance", count);
        }
        
        public void Continue()
        {
            this.CallVoidMethod("continue");
        }
        
        public void Continue(object key)
        {
            this.CallVoidMethod("continue", key);
        }
        
        public nsISupports Delete()
        {
            return this.CallMethod<nsISupports>("delete");
        }
    }
}
