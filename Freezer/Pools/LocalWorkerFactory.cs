namespace Freezer.Pools
{
    /// <summary>
    /// Factory for building for building local workers
    /// </summary>
    internal sealed class LocalWorkerFactory : IWorkerFactory<IWorker>
    {
        public IWorker CreateInstance(string parentIdentifier)
        {
            return new RemoteWorker(new LocalProcessHost(new TcpListenerPortProvider(), parentIdentifier));
        }
    }
}