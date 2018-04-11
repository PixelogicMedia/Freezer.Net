using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using Freezer.Pools;
using Freezer.Utils.Threading;

namespace Freezer.Runner
{
    internal class RunnerCore
    {
        /// <summary>
        /// Initialize a freezerCapture instance in boundingHostName:boudingPort with the specified xulPath and the parentIdentifer
        /// </summary>
        /// <param name="boundingHostName"></param>
        /// <param name="boundingPort"></param>
        /// <param name="xulPath"></param>
        /// <param name="parentLockIdentifier"></param>
        public static void SetupHost(string boundingHostName, int boundingPort, string xulPath, string parentLockIdentifier)
        {
            RunnerCoreGlobal.XulPath = xulPath; 

            var baseAddress = new Uri($"net.tcp://{boundingHostName}:{boundingPort}/freezerworker");

            WaitForParentToExitAsync(parentLockIdentifier); 

            using (var host = new ServiceHost(typeof (RunnerEngineHost), baseAddress))
            {
                var smb = new ServiceMetadataBehavior
                {
                    MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
                };

                host.AddServiceEndpoint(typeof(IWorker), ServiceSettings.GetDefaultBinding(), string.Empty);

                host.Description.Behaviors.Add(smb);
                host.Open();

                Console.WriteLine();
                Console.WriteLine(@"freezercapture started");

                ThreadGuard.Instance.Block();
                host.Close();
            }
        }

        public static void SetupHostAsync(string boundingHostName, int boundingPort, string xulPath, string parentLockIdentifier)
        {
            Thread thread = new Thread(o =>
            {
                try
                {
                    SetupHost(boundingHostName, boundingPort, xulPath, parentLockIdentifier);
                }
                catch
                {
                    
                }
            })
            {
                IsBackground = true,
            };

            thread.SetApartmentState(ApartmentState.STA);

            thread.Start();
        }

        /// <summary>
        /// This process allows freezercapture instance to exit when the corresponding parent dispose. 
        /// </summary>
        /// <param name="parentIdentifier"></param>
        private static void WaitForParentToExit(string parentIdentifier)
        {
            try
            {
                // Current instance will wait for a mutex to be released
                // Acquiring this mutex means that the owner pool have disposed 
                using (new ExclusiveBlock(parentIdentifier))
                {

                }

                // Mutex Acquired and realeased. So let's quit
                ThreadGuard.Instance.Quit();
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Same as WaitForParentToExit with a fork thread. 
        /// </summary>
        /// <param name="parentIdentifier"></param>
        private static void WaitForParentToExitAsync(string parentIdentifier)
        {
            Thread thread = new Thread(o => WaitForParentToExit((string) o))
            {
                IsBackground = true,
            };

            thread.Start(parentIdentifier);
        }
    }


    [Serializable]
    public class RunnerCoreDomainWrapper
    {
        public void SetupHost(string boundingHostName, int boundingPort, string xulPath, string parentIdentifier)
        {
            RunnerCore.SetupHostAsync(boundingHostName, boundingPort, xulPath, parentIdentifier);
        }
    }
}