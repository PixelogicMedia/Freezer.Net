using System;
using System.Runtime.Serialization;
using Freezer.Engines;
using Freezer.Utils;

namespace Freezer.Pools
{
    [Serializable]
    [DataContract]
    internal class RemoteTaskResult
    {
        [DataMember]
        private byte [] ExceptionData { get; set; }

        [DataMember]
        public bool Error { get; set; }

        [IgnoreDataMember]
        public CaptureEngineException Exception {
            get
            {
                if (ExceptionData == null)
                    return null;

                return SerializationHelper.FromByteArray<CaptureEngineException>(ExceptionData); 
            }
            set { ExceptionData = value.ToByteArray(); }
        }

        [DataMember]
        public byte [] PayLoad { get; set; }
    }
}