namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CSSValueList : WebIDLBase
    {
        
        public CSSValueList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
