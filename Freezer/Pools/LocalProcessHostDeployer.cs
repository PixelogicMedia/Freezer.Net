using System;
using System.IO;
using System.Reflection;
using Freezer.Utils.Threading;

namespace Freezer.Pools
{
    internal sealed class LocalProcessHostDeployer : IDisposable
    {
        private static readonly string deploymentLocation;

        static LocalProcessHostDeployer()
        {
            deploymentLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Freezer", "freezercapture");

            if (!Directory.Exists(deploymentLocation))
                Directory.CreateDirectory(deploymentLocation);
        }
            
        const string ConcurrentDeployMutexName = "Freezer.LocalProcessHostDeployer";

        internal LocalProcessHostDeployer() :
            this (deploymentLocation)
        {
            
        }

        internal LocalProcessHostDeployer(string codeBasePath)
        {
            if (codeBasePath == null)
                throw new InvalidOperationException("Could not retrieve Freezer.dll codebase");

            DeployFreezerCapture(codeBasePath);
        }
        
        private void DeployFreezerCapture(string codeBasePath)
        {
            var freezerPath = Assembly.GetAssembly(typeof(WorkerEngine)).Location;

            ExecutablePath = Path.Combine(codeBasePath, "freezercapture.exe");
            var executableConfPath = Path.Combine(codeBasePath, "freezercapture.exe.config");
            var currentAssemblyPath = Path.Combine(codeBasePath, Path.GetFileName(freezerPath));

            var freezerCapture = Resources.freezercapture;

            using (new ExclusiveBlock(ConcurrentDeployMutexName))
            {
                var fileInfo = new FileInfo(currentAssemblyPath);

                var shouldOverWrite = !fileInfo.Exists ||
                                      fileInfo.LastWriteTimeUtc <
                                      new FileInfo(freezerPath).LastWriteTimeUtc; 

                if (shouldOverWrite)
                {
                    File.WriteAllBytes(ExecutablePath, freezerCapture);
                    File.WriteAllBytes(executableConfPath, Resources.freezercapture_exe);
                    File.Copy(freezerPath, currentAssemblyPath, true);
                }
            }
        }

        public string ExecutablePath { get; private set; }

        public void Dispose()
        {
        }
    }
}