using System;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace Freezer.Utils.Threading
{
    internal sealed class ExclusiveBlock : IDisposable
    {
        private readonly bool _hasHandle;
        private readonly Mutex _mutex;

        public ExclusiveBlock(string blockIdentifier)
        {
            try
            {
                var securitySettings = CreateDefaultSecuritySettings();

                _mutex = new Mutex(false, blockIdentifier);
                _mutex.SetAccessControl(securitySettings);

                _hasHandle = _mutex.WaitOne(Timeout.Infinite, false);
            }
            catch (AbandonedMutexException)
            {
                _hasHandle = true;
            }
        }

        private static MutexSecurity CreateDefaultSecuritySettings()
        {
            var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                MutexRights.FullControl, AccessControlType.Allow);
            var securitySettings = new MutexSecurity();

            securitySettings.AddAccessRule(allowEveryoneRule);
            return securitySettings;
        }

        public void Dispose()
        {
            if (_mutex != null)
            {
                if (_hasHandle)
                    _mutex.ReleaseMutex();

                _mutex.Dispose();
            }
        }
    }
}
