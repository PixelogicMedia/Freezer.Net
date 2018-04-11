namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CanvasGradient : WebIDLBase
    {
        
        public CanvasGradient(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void AddColorStop(float offset, string color)
        {
            this.CallVoidMethod("addColorStop", offset, color);
        }
    }
}
