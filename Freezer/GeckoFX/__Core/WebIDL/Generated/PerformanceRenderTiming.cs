namespace Gecko.WebIDL
{
    using System;
    
    
    internal class PerformanceRenderTiming : WebIDLBase
    {
        
        public PerformanceRenderTiming(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint SourceFrameNumber
        {
            get
            {
                return this.GetProperty<uint>("sourceFrameNumber");
            }
        }
    }
}
