namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLDirectoryElement : WebIDLBase
    {
        
        public HTMLDirectoryElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool Compact
        {
            get
            {
                return this.GetProperty<bool>("compact");
            }
            set
            {
                this.SetProperty("compact", value);
            }
        }
    }
}
