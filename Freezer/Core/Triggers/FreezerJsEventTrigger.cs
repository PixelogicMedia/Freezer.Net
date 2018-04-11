using System;
using System.Threading;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a trigger class bound to javascript event FreezerFire.
    /// </summary>
    [Serializable]
    public class FreezerJsEventTrigger : Trigger
    {
        private static readonly Guid ClassIdentifier = Guid.Parse("81ab3914-0bc8-5486-bfc9-ba63491a5d44");

        public static readonly string EventName = "FreezerFire";

        [NonSerialized]
        private TriggerInstaller _currentInstaller;

        [NonSerialized]
        private bool _alreadyFired; 

        [NonSerialized]
        private SpinLock _firelocker = new SpinLock();

        /// <summary>
        /// Builds an instance with no extra delay
        /// </summary>
        public FreezerJsEventTrigger() 
            : base(ClassIdentifier, "FreezerFire.Dispatched", TimeSpan.Zero)
        {
        }

        /// <summary>
        /// Builds an instance with an extra delay expressed in System.TimeSpan
        /// </summary>
        /// <param name="extraDelay">Delay in System.TimeSpan</param>
        public FreezerJsEventTrigger(TimeSpan extraDelay)
            : base(ClassIdentifier, "FreezerFire.Dispatched", extraDelay)
        {

        }

        /// <summary>
        /// Builds an instance with an extra delay expressed in milliseconds
        /// </summary>
        /// <param name="extraDelayMilliseconds">Delay in milliseconds</param>
        public FreezerJsEventTrigger(int extraDelayMilliseconds)
            : this (TimeSpan.FromMilliseconds(extraDelayMilliseconds))
        {

        }

        internal override void Installing(TriggerInstaller installer)
        {
            _currentInstaller = installer; 
            installer.OnFreezerFireDispatch += OnFreezerFireDispatch;
        }

        private void OnFreezerFireDispatch(object sender, EventArgs eventArgs)
        {
            bool lockHasBeenTaken = false;

            try
            {
                _firelocker.Enter(ref lockHasBeenTaken);

                if (_alreadyFired)
                    return;

                _alreadyFired = true;  
            }
            finally
            {
                if (lockHasBeenTaken)
                    _firelocker.Exit();
            }


            SetInterval(OnDelayReached, TimeSpan.FromMilliseconds(ExtraDelay.TotalMilliseconds));
        }

        private void OnDelayReached()
        {
            _currentInstaller.Synchronizer.Invoke(new Action(() => { _currentInstaller.Fire(this); }), new object[0]);
        }
    }

}
