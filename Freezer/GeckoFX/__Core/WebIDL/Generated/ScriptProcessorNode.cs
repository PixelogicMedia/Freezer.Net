namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ScriptProcessorNode : WebIDLBase
    {
        
        public ScriptProcessorNode(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public int BufferSize
        {
            get
            {
                return this.GetProperty<int>("bufferSize");
            }
        }
    }
}
