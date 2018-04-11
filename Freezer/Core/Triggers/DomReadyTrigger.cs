using System;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a trigger corresponding to DOMContentLoaded event. 
    /// </summary>
    [Serializable]
    public sealed class DomReadyTrigger : Trigger
    {
        private static readonly Guid ClassIdentifier = Guid.Parse("65abf914-0bc8-496e-bfc9-ba53491a5de1");

        [NonSerialized]
        private TriggerInstaller _currentInstaller;

        /// <summary>
        /// Builds an instance with no extra delay
        /// </summary>
        public DomReadyTrigger() : base(ClassIdentifier, "Dom.Ready")
        {

        }

        /// <summary>
        /// Builds an instance with an extra delay expressed in System.TimeSpan
        /// </summary>
        /// <param name="extraDelay">Delay in System.TimeSpan</param>
        public DomReadyTrigger(TimeSpan extraDelay) 
            : base(ClassIdentifier, "Dom.Ready", extraDelay)
        {

        }

        /// <summary>
        /// Builds an instance with an extra delay expressed in milliseconds
        /// </summary>
        /// <param name="extraDelayMilliseconds">Delay in milliseconds</param>
        public DomReadyTrigger(int extraDelayMilliseconds)
            : this (TimeSpan.FromMilliseconds(extraDelayMilliseconds))
        {
            
        }
        
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