namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CallsList : WebIDLBase
    {
        
        public CallsList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint Length
        {
            get
            {
                return this.GetProperty<uint>("length");
            }
        }
    }
}
