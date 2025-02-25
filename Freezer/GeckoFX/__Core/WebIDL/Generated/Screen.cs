namespace Gecko.WebIDL
{
    using System;
    
    
    internal class Screen : WebIDLBase
    {
        
        public Screen(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public int AvailWidth
        {
            get
            {
                return this.GetProperty<int>("availWidth");
            }
        }
        
        public int AvailHeight
        {
            get
            {
                return this.GetProperty<int>("availHeight");
            }
        }
        
        public int Width
        {
            get
            {
                return this.GetProperty<int>("width");
            }
        }
        
        public int Height
        {
            get
            {
                return this.GetProperty<int>("height");
            }
        }
        
        public int ColorDepth
        {
            get
            {
                return this.GetProperty<int>("colorDepth");
            }
        }
        
        public int PixelDepth
        {
            get
            {
                return this.GetProperty<int>("pixelDepth");
            }
        }
        
        public int Top
        {
            get
            {
                return this.GetProperty<int>("top");
            }
        }
        
        public int Left
        {
            get
            {
                return this.GetProperty<int>("left");
            }
        }
        
        public int AvailTop
        {
            get
            {
                return this.GetProperty<int>("availTop");
            }
        }
        
        public int AvailLeft
        {
            get
            {
                return this.GetProperty<int>("availLeft");
            }
        }
        
        public string MozOrientation
        {
            get
            {
                return this.GetProperty<string>("mozOrientation");
            }
        }
        
        public bool MozLockOrientation(string orientation)
        {
            return this.CallMethod<bool>("mozLockOrientation", orientation);
        }
        
        public bool MozLockOrientation(string[] orientation)
        {
            return this.CallMethod<bool>("mozLockOrientation", orientation);
        }
        
        public void MozUnlockOrientation()
        {
            this.CallVoidMethod("mozUnlockOrientation");
        }
        
        public nsISupports Orientation
        {
            get
            {
                return this.GetProperty<nsISupports>("orientation");
            }
        }
    }
}
