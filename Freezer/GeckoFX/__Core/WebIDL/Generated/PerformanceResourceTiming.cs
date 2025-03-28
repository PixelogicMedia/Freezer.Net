namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PerformanceResourceTiming : WebIDLBase
    {
        
        public PerformanceResourceTiming(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public string InitiatorType
        {
            get
            {
                return this.GetProperty<string>("initiatorType");
            }
        }
        
        public string NextHopProtocol
        {
            get
            {
                return this.GetProperty<string>("nextHopProtocol");
            }
        }
        
        public Double RedirectStart
        {
            get
            {
                return this.GetProperty<Double>("redirectStart");
            }
        }
        
        public Double RedirectEnd
        {
            get
            {
                return this.GetProperty<Double>("redirectEnd");
            }
        }
        
        public Double FetchStart
        {
            get
            {
                return this.GetProperty<Double>("fetchStart");
            }
        }
        
        public Double DomainLookupStart
        {
            get
            {
                return this.GetProperty<Double>("domainLookupStart");
            }
        }
        
        public Double DomainLookupEnd
        {
            get
            {
                return this.GetProperty<Double>("domainLookupEnd");
            }
        }
        
        public Double ConnectStart
        {
            get
            {
                return this.GetProperty<Double>("connectStart");
            }
        }
        
        public Double ConnectEnd
        {
            get
            {
                return this.GetProperty<Double>("connectEnd");
            }
        }
        
        public Double SecureConnectionStart
        {
            get
            {
                return this.GetProperty<Double>("secureConnectionStart");
            }
        }
        
        public Double RequestStart
        {
            get
            {
                return this.GetProperty<Double>("requestStart");
            }
        }
        
        public Double ResponseStart
        {
            get
            {
                return this.GetProperty<Double>("responseStart");
            }
        }
        
        public Double ResponseEnd
        {
            get
            {
                return this.GetProperty<Double>("responseEnd");
            }
        }
        
        public ulong TransferSize
        {
            get
            {
                return this.GetProperty<ulong>("transferSize");
            }
        }
        
        public ulong EncodedBodySize
        {
            get
            {
                return this.GetProperty<ulong>("encodedBodySize");
            }
        }
        
        public ulong DecodedBodySize
        {
            get
            {
                return this.GetProperty<ulong>("decodedBodySize");
            }
        }
    }
}
