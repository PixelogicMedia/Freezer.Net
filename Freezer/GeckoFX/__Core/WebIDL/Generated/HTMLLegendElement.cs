namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLLegendElement : WebIDLBase
    {
        
        public HTMLLegendElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
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
