using System.ServiceModel;

namespace Freezer.Pools
{
    internal sealed class RemoteWorker : IWorker
    {
        private readonly ICaptureHost _captureHost;
        private bool _hasExited; 

        public RemoteWorker(ICaptureHost captureHost)
        {
            _captureHost = captureHost;
            _captureHost.Start();
        }

        public RemoteTaskResult PerformTask(RemoteTask task)
        {
            var myBinding = ServiceSettings.GetDefaultBinding();
            var myEndpoint = ServiceSettings.GetDefaultEndpoint(_captureHost.Hostname, _captureHost.Port);

            ChannelFactory<IWorker> myChannelFactory = null;
            IWorker worker = null;

            try
            {
                using (myChannelFactory = new ChannelFactory<IWorker>(myBinding, myEndpoint))
                {
                    worker = myChannelFactory.CreateChannel();
                    return worker.PerformTask(task);
                }
            }
            catch
            {
                if (worker != null)
                {
                    myChannelFactory.Abort();
                }
            }

            return null; 
        }

        public void Exit()
        {
            if (_hasExited)
                return; 

            var myBinding = ServiceSettings.GetDefaultBinding();
            var myEndpoint = ServiceSettings.GetDefaultEndpoint(_captureHost.Hostname, _captureHost.Port);

            ChannelFactory<IWorker> myChannelFactory = null;
            IWorker worker = null;

            try
            {
                using (myChannelFactory = new ChannelFactory<IWorker>(myBinding, myEndpoint))
                {
                    worker = myChannelFactory.CreateChannel();
                    worker.Exit();
                }

                _captureHost.Dispose();
            }
            catch
            {
                if (worker != null)
                {
                    myChannelFactory.Abort();
                }
            }
            finally
            {
                _hasExited = true; 
            }
        }

        public void Dispose()
        {
            Exit();
        }
    }
}