namespace Gecko.WebIDL
{
    using System;
    
    
    internal class AudioDestinationNode : WebIDLBase
    {
        
        public AudioDestinationNode(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint MaxChannelCount
        {
            get
            {
                return this.GetProperty<uint>("maxChannelCount");
            }
        }
    }
}
