namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PropertyNodeList : WebIDLBase
    {
        
        public PropertyNodeList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public Object[] GetValues()
        {
            return this.CallMethod<Object[]>("getValues");
        }
    }
}
