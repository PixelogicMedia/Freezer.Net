using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Freezer.Core;
using Freezer.Utils;

namespace Freezer.Pools
{
    [Serializable]
    [DataContract]
    internal class RemoteTask
    {
        private byte[] _captureZoneData; 

        private byte[] _triggerData; 

        [DataMember]
        public Size BrowserSize { get; set; }

        [DataMember]
        public string Url { get; set; }
        
        [DataMember]
        public TimeSpan Timeout { get; set; }

        [DataMember]
        public List<Cookie> Cookies { get; set; }

        [DataMember]
        public string AcceptLanguages { get; set; }

        [DataMember]
        public string UserAgent { get; set; }

        [DataMember]
        public byte[] CaptureZoneData
        {
            get { return _captureZoneData; }
            set { _captureZoneData = value; }
        }

        [DataMember]
        public byte [] TriggerData
        {
            get { return _triggerData; }
            set { _triggerData = value; }
        }

        public void SetCaptureZone(CaptureZone value)
        {
            _captureZoneData = value.ToByteArray();
        }

        public CaptureZone GetCaptureZone()
        {
            if (_captureZoneData == null)
                return null;

            return SerializationHelper.FromByteArray<CaptureZone>(_captureZoneData);
        }

        public void SetTrigger(Trigger value)
        {
            _triggerData = value.ToByteArray();
        }

        public Trigger GetTrigger()
        {
            if (_triggerData == null)
                return null;

            return SerializationHelper.FromByteArray<Trigger>(_triggerData);
        }
    }
}