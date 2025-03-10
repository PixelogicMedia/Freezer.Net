namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozNFCPeer : WebIDLBase
    {
        
        public MozNFCPeer(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool IsLost
        {
            get
            {
                return this.GetProperty<bool>("isLost");
            }
        }
        
        public Promise SendNDEF(nsISupports[] records)
        {
            return this.CallMethod<Promise>("sendNDEF", records);
        }
        
        public Promise SendFile(nsIDOMBlob blob)
        {
            return this.CallMethod<Promise>("sendFile", blob);
        }
        
        public string Session
        {
            get
            {
                return this.GetProperty<string>("session");
            }
            set
            {
                this.SetProperty("session", value);
            }
        }
        
        public void NotifyLost()
        {
            this.CallVoidMethod("notifyLost");
        }
    }
}
