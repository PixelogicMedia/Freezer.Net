namespace Gecko.WebIDL
{
    using System;
    
    
    internal class MozNDEFRecord : WebIDLBase
    {
        
        public MozNDEFRecord(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public TNF Tnf
        {
            get
            {
                return this.GetProperty<TNF>("tnf");
            }
        }
        
        public IntPtr Type
        {
            get
            {
                return this.GetProperty<IntPtr>("type");
            }
        }
        
        public IntPtr Id
        {
            get
            {
                return this.GetProperty<IntPtr>("id");
            }
        }
        
        public IntPtr Payload
        {
            get
            {
                return this.GetProperty<IntPtr>("payload");
            }
        }
        
        public uint Size
        {
            get
            {
                return this.GetProperty<uint>("size");
            }
        }
        
        public string GetAsURI()
        {
            return this.CallMethod<string>("getAsURI");
        }
    }
}
