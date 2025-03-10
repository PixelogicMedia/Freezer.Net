namespace Gecko.WebIDL
{
    using System;
    
    
    internal class TVManager : WebIDLBase
    {
        
        public TVManager(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public Promise < nsISupports[] > GetTuners()
        {
            return this.CallMethod<Promise < nsISupports[] >>("getTuners");
        }
    }
}
