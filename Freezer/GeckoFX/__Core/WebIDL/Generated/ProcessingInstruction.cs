namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ProcessingInstruction : WebIDLBase
    {
        
        public ProcessingInstruction(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Target
        {
            get
            {
                return this.GetProperty<string>("target");
            }
        }
    }
}
