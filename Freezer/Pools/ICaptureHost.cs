using System;

namespace Freezer.Pools
{
    /// <summary>
    /// 
    /// </summary>
    internal interface ICaptureHost : IDisposable
    {
        string Hostname { get;  }

        int Port { get;  }

        void Start();

        void Stop();
    }
}