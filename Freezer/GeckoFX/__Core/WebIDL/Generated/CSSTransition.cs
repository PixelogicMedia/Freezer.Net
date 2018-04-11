namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CSSTransition : WebIDLBase
    {
        
        public CSSTransition(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string TransitionProperty
        {
            get
            {
                return this.GetProperty<string>("transitionProperty");
            }
        }
    }
}
