namespace Gecko.WebIDL
{
    using System;
    
    
    internal class SpeechRecognitionResultList : WebIDLBase
    {
        
        public SpeechRecognitionResultList(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public uint Length
        {
            get
            {
                return this.GetProperty<uint>("length");
            }
        }
    }
}
