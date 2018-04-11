using System;

namespace Gecko
{
    [Flags]
    internal enum CertOverride
    {
        Mismatch = nsICertOverrideServiceConsts.ERROR_MISMATCH,
        Time = nsICertOverrideServiceConsts.ERROR_TIME,
        Untrusted = nsICertOverrideServiceConsts.ERROR_UNTRUSTED,
    }
}