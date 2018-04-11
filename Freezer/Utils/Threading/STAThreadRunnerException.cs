using System;
using System.Runtime.Serialization;
using System.Threading;

namespace Freezer.Utils.Threading
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class STAThreadRunnerException : Exception
    {
        public STAThreadRunnerException(Thread workingThread, string message, Exception innerException) :
            base(message, innerException)
        {
            WorkingThread = workingThread; 
        }

        public STAThreadRunnerException(Thread workingThread, string message) :
            this(workingThread, message, null)
        {
        }

        /// <summary>
        /// The thread which cause the error, U may try to attempt to abort it in case of Timeout
        /// </summary>
        public Thread WorkingThread { get; }

        protected STAThreadRunnerException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {

        }
    }
}