namespace Gecko.WebIDL
{
    using System;
    
    
    internal class FontFaceSource : WebIDLBase
    {
        
        public FontFaceSource(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Fonts
        {
            get
            {
                return this.GetProperty<nsISupports>("fonts");
            }
        }
    }
}
