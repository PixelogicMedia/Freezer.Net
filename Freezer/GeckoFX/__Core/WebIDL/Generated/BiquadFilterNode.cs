namespace Gecko.WebIDL
{
    using System;
    
    
    internal class BiquadFilterNode : WebIDLBase
    {
        
        public BiquadFilterNode(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public BiquadFilterType Type
        {
            get
            {
                return this.GetProperty<BiquadFilterType>("type");
            }
            set
            {
                this.SetProperty("type", value);
            }
        }
        
        public nsISupports Frequency
        {
            get
            {
                return this.GetProperty<nsISupports>("frequency");
            }
        }
        
        public nsISupports Detune
        {
            get
            {
                return this.GetProperty<nsISupports>("detune");
            }
        }
        
        public nsISupports Q
        {
            get
            {
                return this.GetProperty<nsISupports>("Q");
            }
        }
        
        public nsISupports Gain
        {
            get
            {
                return this.GetProperty<nsISupports>("gain");
            }
        }
        
        public void GetFrequencyResponse(IntPtr frequencyHz, IntPtr magResponse, IntPtr phaseResponse)
        {
            this.CallVoidMethod("getFrequencyResponse", frequencyHz, magResponse, phaseResponse);
        }
    }
}
