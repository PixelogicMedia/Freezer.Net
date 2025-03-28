namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PaintRequest : WebIDLBase
    {
        
        public PaintRequest(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports ClientRect
        {
            get
            {
                return this.GetProperty<nsISupports>("clientRect");
            }
        }
        
        public string Reason
        {
            get
            {
                return this.GetProperty<string>("reason");
            }
        }
    }
}
