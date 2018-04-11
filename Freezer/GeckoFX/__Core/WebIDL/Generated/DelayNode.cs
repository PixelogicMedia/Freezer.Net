namespace Gecko.WebIDL
{
    using System;
    
    
    internal class DelayNode : WebIDLBase
    {
        
        public DelayNode(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports DelayTime
        {
            get
            {
                return this.GetProperty<nsISupports>("delayTime");
            }
        }
    }
}
