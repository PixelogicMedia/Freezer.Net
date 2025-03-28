namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLLabelElement : WebIDLBase
    {
        
        public HTMLLabelElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Form
        {
            get
            {
                return this.GetProperty<nsISupports>("form");
            }
        }
        
        public string HtmlFor
        {
            get
            {
                return this.GetProperty<string>("htmlFor");
            }
            set
            {
                this.SetProperty("htmlFor", value);
            }
        }
        
        public nsISupports Control
        {
            get
            {
                return this.GetProperty<nsISupports>("control");
            }
        }
    }
}
