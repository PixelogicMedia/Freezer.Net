namespace Gecko.WebIDL
{
    using System;
    
    
    internal class FontFaceSetIterator : WebIDLBase
    {
        
        public FontFaceSetIterator(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public object Next()
        {
            return this.CallMethod<object>("next");
        }
    }
}
