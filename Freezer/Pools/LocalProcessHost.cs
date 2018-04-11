using System;
using System.Diagnostics;
using Freezer.Core;

namespace Freezer.Pools
{
    internal sealed class LocalProcessHost : ICaptureHost
    {
        private readonly LocalProcessHostDeployer _processHostDeployer;
        private readonly string _parentIdentifier; 
        private Process _currentProcess; 

        public LocalProcessHost(ILocalPortProvider portProvider, string parentIdentifier)
        {
            Hostname = "127.0.0.1";
            Port = portProvider.GetAvailablePort();
            _parentIdentifier = parentIdentifier; 

            _processHostDeployer = new LocalProcessHostDeployer();
        }
        
        public string Hostname { get; }

        public int Port { get; }

        public void Start()
        {
            if (_currentProcess != null)
                return;

            var processStartInfo =
                new ProcessStartInfo(_processHostDeployer.ExecutablePath, 
                $"{Hostname} {Port} \"{FreezerGlobal.XulLocation}\" \"{_parentIdentifier}\"")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            _currentProcess = Process.Start(processStartInfo);

            if (_currentProcess == null)
                throw new InvalidOperationException("freezercapture failed to start");

            string line;
            bool processInitied = false; 

            while ((line = _currentProcess.StandardOutput.ReadLine()) != null) 
            {
                if (line.Equals("freezercapture started"))
                {
                    processInitied = true;
                    break; 
                }
            }

            if (!processInitied)
                throw new InvalidOperationException("WaitForInputIdle failed");
        }

        public void Stop()
        {
            if (_currentProcess.WaitForExit(2000))
                return;
            
            _currentProcess.Kill();
        }

        public void Dispose()
        {
            Stop();
            _processHostDeployer.Dispose();
        }
    }
}
