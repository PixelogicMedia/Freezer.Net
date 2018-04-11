using Freezer.Pools;

namespace Freezer.UnitTests.TestCases.Core.Triggers
{
    internal class CaptureHostMock : ICaptureHost
    {
        public void Dispose()
        {
        }

        public string Hostname { get; set; }

        public int Port { get; set;  }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}