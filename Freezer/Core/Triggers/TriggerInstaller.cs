using System;
using System.ComponentModel;

namespace Freezer.Core
{
    internal abstract class TriggerInstaller : MarshalByRefObject, IDisposable
    {
        public ISynchronizeInvoke Synchronizer { get; }

        protected TriggerInstaller(ISynchronizeInvoke synchronizer)
        {
            this.Synchronizer = synchronizer; 
        }

        public abstract EventHandler<EventArgs> OnLoad { get; set; }

        public abstract EventHandler<EventArgs> OnDomReady { get; set; }

        public abstract EventHandler<EventArgs> OnNavigationError { get; set; }

        public abstract EventHandler<EventArgs> OnFreezerFireDispatch { get; set; }

        public EventHandler<EventArgs> FireEvent { get; set; }

        public void Fire(Trigger sender)
        {
            FireEvent(sender, new EventArgs());
        }

        public virtual void Dispose()
        {
            OnLoad = null;
            OnDomReady = null;
            OnNavigationError = null;
            OnFreezerFireDispatch = null;
            FireEvent = null; 
        }
    }
}