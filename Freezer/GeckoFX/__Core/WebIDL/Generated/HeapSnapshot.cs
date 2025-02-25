namespace Gecko.WebIDL
{
    using System;
    
    
    internal class HeapSnapshot : WebIDLBase
    {
        
        public HeapSnapshot(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public System.Nullable<ulong> CreationTime
        {
            get
            {
                return this.GetProperty<System.Nullable<ulong>>("creationTime");
            }
        }
        
        public object TakeCensus(object options)
        {
            return this.CallMethod<object>("takeCensus", options);
        }
        
        public nsISupports ComputeDominatorTree()
        {
            return this.CallMethod<nsISupports>("computeDominatorTree");
        }
    }
}
