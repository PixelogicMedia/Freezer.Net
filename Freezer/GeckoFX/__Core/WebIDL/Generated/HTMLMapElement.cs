namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HTMLMapElement : WebIDLBase
    {
        
        public HTMLMapElement(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Name
        {
            get
            {
                return this.GetProperty<string>("name");
            }
            set
            {
                this.SetProperty("name", value);
            }
        }
        
        public nsISupports Areas
        {
            get
            {
                return this.GetProperty<nsISupports>("areas");
            }
        }
    }
}
