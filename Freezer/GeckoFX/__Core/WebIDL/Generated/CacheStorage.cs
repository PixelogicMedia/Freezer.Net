namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CacheStorage : WebIDLBase
    {
        
        public CacheStorage(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public Promise < nsISupports > Match(WebIDLUnion<nsISupports,USVString> request)
        {
            return this.CallMethod<Promise < nsISupports >>("match", request);
        }
        
        public Promise < nsISupports > Match(WebIDLUnion<nsISupports,USVString> request, object options)
        {
            return this.CallMethod<Promise < nsISupports >>("match", request, options);
        }
        
        public Promise <bool> Has(string cacheName)
        {
            return this.CallMethod<Promise <bool>>("has", cacheName);
        }
        
        public Promise < nsISupports > Open(string cacheName)
        {
            return this.CallMethod<Promise < nsISupports >>("open", cacheName);
        }
        
        public Promise <bool> Delete(string cacheName)
        {
            return this.CallMethod<Promise <bool>>("delete", cacheName);
        }
        
        public Promise < System.String[] > Keys()
        {
            return this.CallMethod<Promise < System.String[] >>("keys");
        }
    }
}
