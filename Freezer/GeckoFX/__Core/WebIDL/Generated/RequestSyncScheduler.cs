namespace Gecko.WebIDL
{
    using System;
    
    
    internal class RequestSyncScheduler : WebIDLBase
    {
        
        public RequestSyncScheduler(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public Promise Register(USVString task)
        {
            return this.CallMethod<Promise>("register", task);
        }
        
        public Promise Register(USVString task, object @params)
        {
            return this.CallMethod<Promise>("register", task, @params);
        }
        
        public Promise Unregister(USVString task)
        {
            return this.CallMethod<Promise>("unregister", task);
        }
        
        public Promise < System.Object[] > Registrations()
        {
            return this.CallMethod<Promise < System.Object[] >>("registrations");
        }
        
        public Promise <object> Registration(USVString task)
        {
            return this.CallMethod<Promise <object>>("registration", task);
        }
    }
}
