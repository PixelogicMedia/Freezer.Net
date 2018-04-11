namespace Gecko.WebIDL
{
    using System;
    
    
    internal class AbstractWorker : WebIDLBase
    {
        
        public AbstractWorker(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
    }
}
