using System;
using System.ServiceModel;

namespace Freezer.Pools
{
    /// <summary>
    /// Represents a working instance of CaptureEngine in a remote process
    /// </summary>
    [ServiceContract]
    internal interface IWorker : IDisposable
    {
        [OperationContract]
        RemoteTaskResult PerformTask(RemoteTask task);

        [OperationContract(IsOneWay = true)]
        void Exit(); 
    }
}
