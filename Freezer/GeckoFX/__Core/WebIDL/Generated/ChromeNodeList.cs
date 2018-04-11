namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ChromeNodeList : WebIDLBase
    {
        
        public ChromeNodeList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public void Append(nsIDOMNode aNode)
        {
            this.CallVoidMethod("append", aNode);
        }
        
        public void Remove(nsIDOMNode aNode)
        {
            this.CallVoidMethod("remove", aNode);
        }
    }
}
