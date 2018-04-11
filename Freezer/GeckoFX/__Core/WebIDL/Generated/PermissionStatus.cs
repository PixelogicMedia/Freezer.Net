namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PermissionStatus : WebIDLBase
    {
        
        public PermissionStatus(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public PermissionState State
        {
            get
            {
                return this.GetProperty<PermissionState>("state");
            }
        }
    }
}
