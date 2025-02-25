namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLHtmlElement : WebIDLBase
    {
        
        public HTMLHtmlElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Version
        {
            get
            {
                return this.GetProperty<string>("version");
            }
            set
            {
                this.SetProperty("version", value);
            }
        }
    }
}
