namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SettingsManager : WebIDLBase
    {
        
        public SettingsManager(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports CreateLock()
        {
            return this.CallMethod<nsISupports>("createLock");
        }
    }
}
