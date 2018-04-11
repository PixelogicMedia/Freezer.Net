using System;
using System.Threading;
using System.Threading.Tasks;

namespace Freezer.Core
{
    /// <summary>
    /// Represents the event which trigger the screenshot
    /// </summary>
    [Serializable]
    public abstract class Trigger
    {
        protected internal Trigger(Guid identifier, string name, TimeSpan extraDelay)
        {
            if (extraDelay < TimeSpan.Zero)
                throw new ArgumentException("Delay should not be less than zero",
                    nameof(extraDelay));

            Identifier = identifier; 
            Name = name;
            ExtraDelay = extraDelay;
        }

        protected internal Trigger(Guid identifier, string name) : 
            this (identifier, name, TimeSpan.Zero)
        {
        }

        /// <summary>
        /// Unique Identifier of the Freezer
        /// </summary>
        private  Guid Identifier { get; }

        /// <summary>
        /// Nom de l'engin
        /// </summary>
        public string Name { get; }

        public TimeSpan ExtraDelay { get; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected bool Equals(Trigger other)
        {
            return Identifier.Equals(other.Identifier) && string.Equals(Name, other.Name) && ExtraDelay.Equals(other.ExtraDelay);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Identifier.GetHashCode();
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ ExtraDelay.GetHashCode();
                return hashCode;
            }
        }

        protected void SetInterval(Action action, TimeSpan timeOut)
        {
            // Message event thread cannot be used to ReadBitmap for FreezerJsEventTrigger
            if (timeOut <= TimeSpan.Zero && (!(this is FreezerJsEventTrigger)))
                action();
            else
            {
                ThreadPool.UnsafeQueueUserWorkItem(
                (o) =>
                {
                    if (timeOut > TimeSpan.Zero)
                        Thread.Sleep(timeOut);
                    action();
                }, null
                );
            }
        }

        internal void Install(TriggerInstaller installer)
        {
            Installing(installer);
        }

        internal  abstract void Installing(TriggerInstaller installer);
    }



}