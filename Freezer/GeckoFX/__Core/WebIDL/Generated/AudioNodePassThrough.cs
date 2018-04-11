namespace Gecko.WebIDL
{
    using System;
    
    
    internal class AudioNodePassThrough : WebIDLBase
    {
        
        public AudioNodePassThrough(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool PassThrough
        {
            get
            {
                return this.GetProperty<bool>("passThrough");
            }
            set
            {
                this.SetProperty("passThrough", value);
            }
        }
    }
}
