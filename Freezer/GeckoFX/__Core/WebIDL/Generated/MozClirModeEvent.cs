namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozClirModeEvent : WebIDLBase
    {
        
        public MozClirModeEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint Mode
        {
            get
            {
                return this.GetProperty<uint>("mode");
            }
        }
    }
}
