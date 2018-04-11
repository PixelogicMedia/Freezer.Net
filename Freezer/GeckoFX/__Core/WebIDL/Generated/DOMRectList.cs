namespace Gecko.WebIDL
{
    using System;
    
    
    internal class DOMRectList : WebIDLBase
    {
        
        public DOMRectList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
