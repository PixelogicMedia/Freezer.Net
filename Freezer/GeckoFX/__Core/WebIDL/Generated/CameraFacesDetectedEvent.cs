namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CameraFacesDetectedEvent : WebIDLBase
    {
        
        public CameraFacesDetectedEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public nsISupports[] Faces
        {
            get
            {
                return this.GetProperty<nsISupports[]>("faces");
            }
        }
    }
}
