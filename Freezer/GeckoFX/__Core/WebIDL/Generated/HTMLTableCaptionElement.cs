namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLTableCaptionElement : WebIDLBase
    {
        
        public HTMLTableCaptionElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Align
        {
            get
            {
                return this.GetProperty<string>("align");
            }
            set
            {
                this.SetProperty("align", value);
            }
        }
    }
}
