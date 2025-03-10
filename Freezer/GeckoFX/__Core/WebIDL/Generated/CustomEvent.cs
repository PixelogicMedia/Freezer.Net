namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CustomEvent : WebIDLBase
    {
        
        public CustomEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Detail
        {
            get
            {
                return this.GetProperty<object>("detail");
            }
        }
        
        public void InitCustomEvent(string type, bool canBubble, bool cancelable, object detail)
        {
            this.CallVoidMethod("initCustomEvent", type, canBubble, cancelable, detail);
        }
    }
}
