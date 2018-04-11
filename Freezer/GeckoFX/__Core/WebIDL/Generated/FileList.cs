namespace Gecko.WebIDL
{
    using System;
    
    
    internal class FileList : WebIDLBase
    {
        
        public FileList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
