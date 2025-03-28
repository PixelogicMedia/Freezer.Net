namespace Gecko.WebIDL
{
    using System;
    
    
    internal class AnimationEffectReadOnly : WebIDLBase
    {
        
        public AnimationEffectReadOnly(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object GetComputedTiming()
        {
            return this.CallMethod<object>("getComputedTiming");
        }
    }
}
