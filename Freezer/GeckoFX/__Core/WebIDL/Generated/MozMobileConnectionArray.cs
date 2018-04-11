namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozMobileConnectionArray : WebIDLBase
    {
        
        public MozMobileConnectionArray(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
