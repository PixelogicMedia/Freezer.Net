using System;
using System.Globalization;
using System.Reflection;
using Freezer.Runner;

namespace Freezer.Pools
{
    internal sealed class DetachedDomainHost : ICaptureHost
    {
        private readonly string _parentIdentifier;
        private AppDomain _currentDomain;
        private readonly string _currentDomainName; 

        public DetachedDomainHost(ILocalPortProvider portProvider, string parentIdentifier)
        {
            _parentIdentifier = parentIdentifier;
            Hostname = "127.0.0.1";
            Port = portProvider.GetAvailablePort();
            _currentDomainName = $"DetachedDomainHost{Guid.NewGuid()}";
        }

        public void Dispose()
        {
            Stop(); 
        }

        public string Hostname { get; }

        public int Port { get; }

        public void Start()
        {
            if (_currentDomain != null)
                throw new InvalidOperationException("Domain already started");

            _currentDomain = AppDomain.CreateDomain(_currentDomainName,
                null, new AppDomainSetup { ApplicationBase = Environment.CurrentDirectory });

            var instance = (RunnerCoreDomainWrapper)
                _currentDomain.CreateInstanceFromAndUnwrap(typeof (RunnerCoreDomainWrapper).Assembly.Location,
                    typeof (RunnerCoreDomainWrapper).FullName, true, BindingFlags.Instance | BindingFlags.Public ,
                    null, new object[] {}, CultureInfo.CurrentCulture, null) ;

            instance.SetupHost(Hostname, Port, null, _parentIdentifier);
        }

        public void Stop()
        {
            if (_currentDomain == null)
                return;

            AppDomain.Unload(_currentDomain);
            _currentDomain = null; 
        }
    }
}