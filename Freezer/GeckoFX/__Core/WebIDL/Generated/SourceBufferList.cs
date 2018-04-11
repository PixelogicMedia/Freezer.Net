namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SourceBufferList : WebIDLBase
    {
        
        public SourceBufferList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
