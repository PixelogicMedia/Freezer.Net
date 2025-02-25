namespace Gecko.WebIDL
{
    using System;
    
    
    internal class NavigatorDataStore : WebIDLBase
    {
        
        public NavigatorDataStore(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public Promise < nsISupports[] > GetDataStores(string name)
        {
            return this.CallMethod<Promise < nsISupports[] >>("getDataStores", name);
        }
        
        public Promise < nsISupports[] > GetDataStores(string name, string owner)
        {
            return this.CallMethod<Promise < nsISupports[] >>("getDataStores", name, owner);
        }
    }
}
