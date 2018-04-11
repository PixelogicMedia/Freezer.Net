namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MediaStreamList : WebIDLBase
    {
        
        public MediaStreamList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
