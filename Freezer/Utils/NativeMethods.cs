using System;
using System.Runtime.InteropServices;

namespace Freezer.Utils
{
    internal class NativeMethods
    {
        [DllImport("ntdll.dll")]
        internal static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ParentProcessUtilities processInformation, int processInformationLength, out int returnLength);
    }
}