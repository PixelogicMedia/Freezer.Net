using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Freezer.Engines
{
    /// <summary>
    /// Represents the state of a CaptureEngineException
    /// </summary>
    [Serializable]
    public enum CaptureEngineState
    {
        /// <summary>
        /// Internal error
        /// </summary>
        InternalError = 1,
        
        /// <summary>
        /// The capturing browser can't access to the specified URL
        /// </summary>
        NavigationError = 2,
        
        /// <summary>
        /// Error is due to the capture zone
        /// </summary>
        InvalidCaptureZone = 8,

        /// <summary>
        /// Timeout specified in SchedulerJob has been reached
        /// </summary>
        Timeout = 32,
    }

    /// <summary>
    /// Represents exception that can be raised by ScreenshotJob
    /// </summary>
    [Serializable]
    public class CaptureEngineException : Exception
    {
        /// <summary>
        /// Used only for serialization
        /// </summary>
        private CaptureEngineException()
        {
            
        }

        /// <summary>
        /// Creates a CaptureEngineException instance
        /// </summary>
        /// <param name="message"></param>
        /// <param name="state"></param>
        public CaptureEngineException(string message, CaptureEngineState state) : 
            this (message, null, state)
        {
        }

        /// <summary>
        /// Creates a CaptureEngineException instance
        /// </summary>
        /// <param name="innerException"></param>
        /// <param name="state"></param>
        public CaptureEngineException(Exception innerException, CaptureEngineState state) : 
            this (string.Empty, innerException, state)
        {
            
        }

        /// <summary>
        /// Creates a CaptureEngineException instance
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="state"></param>
        public CaptureEngineException(string message, Exception innerException, CaptureEngineState state) :
            base (message, innerException)
        {
            State = state;
        }

        /// <summary>
        /// Creates a CaptureEngineException instance
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected CaptureEngineException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
            State = (CaptureEngineState) info.GetInt32("State");
        }

        /// <summary>
        /// Gets or sets the state of this instance
        /// </summary>
        public CaptureEngineState State { get; set; }

        /// <summary>
        /// Get object data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("State", (int) State);

            // MUST call through to the base class to let it save its own state
            base.GetObjectData(info, context);
        }
    }
}
