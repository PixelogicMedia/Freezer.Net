namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ChildNode : WebIDLBase
    {
        
        public ChildNode(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void Remove()
        {
            this.CallVoidMethod("remove");
        }
    }
}
