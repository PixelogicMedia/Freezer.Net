namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ArchiveRequest : WebIDLBase
    {
        
        public ArchiveRequest(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Reader
        {
            get
            {
                return this.GetProperty<nsISupports>("reader");
            }
        }
    }
}
