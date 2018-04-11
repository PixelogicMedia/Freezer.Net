namespace Gecko.WebIDL
{
    using System;
    
    
    internal class Permissions : WebIDLBase
    {
        
        public Permissions(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public Promise < nsISupports > Query(object permission)
        {
            return this.CallMethod<Promise < nsISupports >>("query", permission);
        }
    }
}
