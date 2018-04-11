using System.Net;
using System.Net.Sockets;

namespace Freezer.Pools
{
    /// <summary>
    /// This class aims to provide available port bound on Loopback adress. 
    /// Current use TcpListener. 
    /// This implementation is too slow and need to be improved
    /// </summary>
    internal class TcpListenerPortProvider : ILocalPortProvider
    {
        public int GetAvailablePort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);

            try
            {
                l.Start();
                return ((IPEndPoint) l.LocalEndpoint).Port;
            }
            finally
            {
                l.Stop();
            }
        }
    }
}