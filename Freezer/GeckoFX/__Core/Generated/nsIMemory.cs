// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsIMemory.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary>
    ///
    /// nsIMemory: interface to allocate and deallocate memory. Also provides
    /// for notifications in low-memory situations.
    ///
    /// The frozen exported symbols moz_xmalloc, moz_xrealloc, and free
    /// provide a more efficient way to access XPCOM memory allocation. Using
    /// those symbols is preferred to using the methods on this interface.
    ///
    /// A client that wishes to be notified of low memory situations (for
    /// example, because the client maintains a large memory cache that
    /// could be released when memory is tight) should register with the
    /// observer service (see nsIObserverService) using the topic
    /// "memory-pressure".  There are specific types of notications
    /// that can occur.  These types will be passed as the |aData|
    /// parameter of the of the "memory-pressure" notification:
    ///
    /// "low-memory"
    /// This will be passed as the extra data when the pressure
    /// observer is being asked to flush for low-memory conditions.
    ///
    /// "low-memory-ongoing"
    /// This will be passed when we continue to be in a low-memory
    /// condition and we want to flush caches and do other cheap
    /// forms of memory minimization, but heavy handed approaches like
    /// a GC are unlikely to succeed.
    ///
    /// "-no-forward"
    /// This is appended to the above two parameters when the resulting
    /// notification should not be forwarded to the child processes.
    ///
    /// "heap-minimize"
    /// This will be passed as the extra data when the pressure
    /// observer is being asked to flush because of a heap minimize
    /// call.
    ///
    /// "alloc-failure"
    /// This will be passed as the extra data when the pressure
    /// observer has been asked to flush because a malloc() or
    /// realloc() has failed.
    ///
    /// "lowering-priority"
    /// This will be passed as the extra data when the priority of a child
    /// process is lowered. The pressure observers could take the chance to
    /// clear caches that could be easily regenerated. This type of
    /// notification only appears in child processes.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("1e004834-6d8f-425a-bc9c-a2812ed43bb7")]
	internal interface nsIMemory
	{
		
		/// <summary>
        /// Attempts to shrink the heap.
        /// @param immediate - if true, heap minimization will occur
        /// immediately if the call was made on the main thread. If
        /// false, the flush will be scheduled to happen when the app is
        /// idle.
        /// @throws NS_ERROR_FAILURE if 'immediate' is set an the call
        /// was not on the application's main thread.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void HeapMinimize([MarshalAs(UnmanagedType.U1)] bool immediate);
		
		/// <summary>
        /// This predicate can be used to determine if we're in a low-memory
        /// situation (what constitutes low-memory is platform dependent). This
        /// can be used to trigger the memory pressure observers.
        ///
        /// DEPRECATED - Always returns false.  See bug 592308.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsLowMemory();
		
		/// <summary>
        /// This predicate can be used to determine if the platform is a "low-memory"
        /// platform. Callers may use this to dynamically tune their behaviour
        /// to favour reduced memory usage at the expense of performance. The value
        /// returned by this function will not change over the lifetime of the process.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsLowMemoryPlatform();
	}
}
