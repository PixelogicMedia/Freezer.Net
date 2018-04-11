using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using Freezer.Core;

namespace Freezer.Engines
{
    /// <summary>
    /// Engines like GeckoFX needs to run one a single thread per appdomain. 
    /// This wrapper allows the use of engine in a separate domain. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class EngineDomainWrapper<T> : CaptureEngine
        where T : CaptureEngine
    {
        private AppDomain _currentDomain; 

        public EngineDomainWrapper(Size browserSize, Trigger trigger, CaptureZone captureZone) 
            : base(browserSize, trigger, captureZone)
        {
            CurrentDomainName = $"enginedomainmanager{Guid.NewGuid()}";
            _currentDomain = AppDomain.CreateDomain(CurrentDomainName, null, new AppDomainSetup { ApplicationBase = Environment.CurrentDirectory });
        }

        public string CurrentDomainName { get; }

        public override Image CaptureUrl(string baseUrl, TimeSpan timeOut)
        {
            using (CaptureEngine instance =
                _currentDomain.CreateInstanceFromAndUnwrap(typeof (T).Assembly.Location,
                    typeof (T).FullName, true, BindingFlags.Instance | BindingFlags.Public,
                    null, new object[] { BrowserSize, Trigger, CaptureZone }, CultureInfo.CurrentCulture,  null)
                    as CaptureEngine)
            {
                if (instance == null)
                {
                    throw new InvalidOperationException($"{nameof(_currentDomain.CreateInstanceAndUnwrap)} failed");
                }

                var originalBuffer = instance.CaptureRawUrl(baseUrl, timeOut);

                using (var memoryStream = new MemoryStream(originalBuffer))
                {
                    return Image.FromStream(memoryStream); 
                }
            }
        }
        
        public override void Dispose()
        {
            if (_currentDomain != null)
            {
                AppDomain.Unload(_currentDomain);
                _currentDomain = null; 
            }

            base.Dispose();
        }
    }
}
