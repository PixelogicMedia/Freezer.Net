namespace Gecko.WebIDL
{
    using System;
    
    
    internal class StyleSheetChangeEvent : WebIDLBase
    {
        
        public StyleSheetChangeEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Stylesheet
        {
            get
            {
                return this.GetProperty<nsISupports>("stylesheet");
            }
        }
        
        public bool DocumentSheet
        {
            get
            {
                return this.GetProperty<bool>("documentSheet");
            }
        }
    }
}
