namespace Gecko.WebIDL
{
    using System;
    
    
    internal class RTCRtpReceiver : WebIDLBase
    {
        
        public RTCRtpReceiver(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports Track
        {
            get
            {
                return this.GetProperty<nsISupports>("track");
            }
        }
    }
}
