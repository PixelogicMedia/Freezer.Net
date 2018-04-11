using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace Freezer.Pools
{
    /// <summary>
    /// This class provides default settings used for WCF communication between 
    /// worker pools and remote gecko host
    /// </summary>
    internal static class ServiceSettings
    {
        public static EndpointAddress GetDefaultEndpoint(string hostName, int port)
        {
            return new EndpointAddress($"net.tcp://{hostName}:{port}/freezerworker");
        }

        public static Binding GetDefaultBinding()
        {
            return new NetTcpBinding(SecurityMode.None)
            {
                ReaderQuotas = new XmlDictionaryReaderQuotas()
                {
                    MaxArrayLength = int.MaxValue,
                    MaxBytesPerRead = int.MaxValue,
                    MaxDepth = int.MaxValue,
                    MaxNameTableCharCount = int.MaxValue,
                    MaxStringContentLength = int.MaxValue,
                },
                ReceiveTimeout = TimeSpan.FromMinutes(10D),
                SendTimeout = TimeSpan.FromMinutes(10D),
                MaxBufferSize = int.MaxValue,
                MaxBufferPoolSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
            };
        }
    }
}
