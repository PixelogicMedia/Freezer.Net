namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozStkCommandEvent : WebIDLBase
    {
        
        public MozStkCommandEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Command
        {
            get
            {
                return this.GetProperty<object>("command");
            }
        }
    }
}
