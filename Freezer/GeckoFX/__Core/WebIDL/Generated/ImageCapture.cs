namespace Gecko.WebIDL
{
    using System;
    
    
    internal class ImageCapture : WebIDLBase
    {
        
        public ImageCapture(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports VideoStreamTrack
        {
            get
            {
                return this.GetProperty<nsISupports>("videoStreamTrack");
            }
        }
        
        public void TakePhoto()
        {
            this.CallVoidMethod("takePhoto");
        }
    }
}
