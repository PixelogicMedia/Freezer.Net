namespace Gecko.WebIDL
{
    using System;
    
    
    internal class NavigatorOnLine : WebIDLBase
    {
        
        public NavigatorOnLine(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool OnLine
        {
            get
            {
                return this.GetProperty<bool>("onLine");
            }
        }
    }
}
