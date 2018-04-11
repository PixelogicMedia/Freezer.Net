namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLDataElement : WebIDLBase
    {
        
        public HTMLDataElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Value
        {
            get
            {
                return this.GetProperty<string>("value");
            }
            set
            {
                this.SetProperty("value", value);
            }
        }
    }
}
