namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PaintRequestList : WebIDLBase
    {
        
        public PaintRequestList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
