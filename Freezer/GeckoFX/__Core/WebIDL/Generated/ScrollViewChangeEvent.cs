namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ScrollViewChangeEvent : WebIDLBase
    {
        
        public ScrollViewChangeEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public ScrollState State
        {
            get
            {
                return this.GetProperty<ScrollState>("state");
            }
        }
    }
}
