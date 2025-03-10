namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CameraRecorderVideoProfile : WebIDLBase
    {
        
        public CameraRecorderVideoProfile(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string Codec
        {
            get
            {
                return this.GetProperty<string>("codec");
            }
        }
        
        public uint BitsPerSecond
        {
            get
            {
                return this.GetProperty<uint>("bitsPerSecond");
            }
        }
        
        public uint FramesPerSecond
        {
            get
            {
                return this.GetProperty<uint>("framesPerSecond");
            }
        }
        
        public object Size
        {
            get
            {
                return this.GetProperty<object>("size");
            }
        }
        
        public uint Width
        {
            get
            {
                return this.GetProperty<uint>("width");
            }
        }
        
        public uint Height
        {
            get
            {
                return this.GetProperty<uint>("height");
            }
        }
    }
}
