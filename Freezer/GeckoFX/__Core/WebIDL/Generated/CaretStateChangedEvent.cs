namespace Gecko.WebIDL
{
    using System;
    
    
    internal class CaretStateChangedEvent : WebIDLBase
    {
        
        public CaretStateChangedEvent(nsIDOMWindow globalWindow, nsISupports thisObject) : 
                base(globalWindow, thisObject)
        {
        }
        
        public bool Collapsed
        {
            get
            {
                return this.GetProperty<bool>("collapsed");
            }
        }
        
        public nsISupports BoundingClientRect
        {
            get
            {
                return this.GetProperty<nsISupports>("boundingClientRect");
            }
        }
        
        public CaretChangedReason Reason
        {
            get
            {
                return this.GetProperty<CaretChangedReason>("reason");
            }
        }
        
        public bool CaretVisible
        {
            get
            {
                return this.GetProperty<bool>("caretVisible");
            }
        }
        
        public bool CaretVisuallyVisible
        {
            get
            {
                return this.GetProperty<bool>("caretVisuallyVisible");
            }
        }
        
        public bool SelectionVisible
        {
            get
            {
                return this.GetProperty<bool>("selectionVisible");
            }
        }
        
        public bool SelectionEditable
        {
            get
            {
                return this.GetProperty<bool>("selectionEditable");
            }
        }
        
        public string SelectedTextContent
        {
            get
            {
                return this.GetProperty<string>("selectedTextContent");
            }
        }
    }
}
