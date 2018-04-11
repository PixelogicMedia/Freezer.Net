namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SVGDocument : WebIDLBase
    {
        
        public SVGDocument(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Domain
        {
            get
            {
                return this.GetProperty<string>("domain");
            }
        }
        
        public nsISupports RootElement
        {
            get
            {
                return this.GetProperty<nsISupports>("rootElement");
            }
        }
    }
}
