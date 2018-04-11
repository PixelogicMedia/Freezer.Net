using System;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a trigger corresponding to Window.Load event. 
    /// </summary>
    [Serializable]
    public sealed class WindowLoadTrigger : Trigger
    {
        private static readonly Guid ClassIdentifier = Guid.Parse("75abf934-0bb8-496e-bfc9-ba5b491aade1");

        [NonSerialized]
        private TriggerInstaller _currentInstaller;

        /// <summary>
        /// Builds an instance with no extra delay
        /// </summary>
        public WindowLoadTrigger() : base(ClassIdentifier, "Window.Load")
        {

        }

        /// <summary>
        /// Builds an instance with an extra delay expressed in System.TimeSpan
        /// </summary>
        /// <param name="extraDelay">Delay in System.TimeSpan</param>
        public WindowLoadTrigger(TimeSpan extraDelay) 
            : base(ClassIdentifier, "Window.Load", extraDelay)
        {

        }

        /// <summary>
        /// Builds an instance with an extra delay expressed in milliseconds
        /// </summary>
        /// <param name="extraDelayMilliseconds">Delay in milliseconds</param>
        public WindowLoadTrigger(int extraDelayMilliseconds)
            : this (TimeSpan.FromMilliseconds(extraDelayMilliseconds))
        {
            
        }

        /// <summary>
        /// Installing the event 
        /// </summary>
        /// <param name="installer"></param>
        internal override void Installing(TriggerInstaller installer)
        {
            _currentInstaller = installer;
            installer.OnLoad += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetInterval(OnDelayReached, ExtraDelay);
        }


        private void OnDelayReached()
        {
            try
            {
                _currentInstaller.Synchronizer.Invoke(new Action(() => { _currentInstaller.Fire(this); }), new object[0]);
            }
            catch
            {
            }
        }
    }
}