namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLTimeElement : WebIDLBase
    {
        
        public HTMLTimeElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string DateTime
        {
            get
            {
                return this.GetProperty<string>("dateTime");
            }
            set
            {
                this.SetProperty("dateTime", value);
            }
        }
    }
}
