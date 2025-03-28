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
// Generated by IDLImporter from file nsIWebProgress.idl
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
    /// The nsIWebProgress interface is used to add or remove nsIWebProgressListener
    /// instances to observe the loading of asynchronous requests (usually in the
    /// context of a DOM window).
    ///
    /// nsIWebProgress instances may be arranged in a parent-child configuration,
    /// corresponding to the parent-child configuration of their respective DOM
    /// windows.  However, in some cases a nsIWebProgress instance may not have an
    /// associated DOM window.  The parent-child relationship of nsIWebProgress
    /// instances is not made explicit by this interface, but the relationship may
    /// exist in some implementations.
    ///
    /// A nsIWebProgressListener instance receives notifications for the
    /// nsIWebProgress instance to which it added itself, and it may also receive
    /// notifications from any nsIWebProgress instances that are children of that
    /// nsIWebProgress instance.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("bd0efb3b-1c81-4fb0-b16d-576a2be48a95")]
	internal interface nsIWebProgress
	{
		
		/// <summary>
        /// Registers a listener to receive web progress events.
        ///
        /// @param aListener
        /// The listener interface to be called when a progress event occurs.
        /// This object must also implement nsISupportsWeakReference.
        /// @param aNotifyMask
        /// The types of notifications to receive.
        ///
        /// @throw NS_ERROR_INVALID_ARG
        /// Indicates that aListener was either null or that it does not
        /// support weak references.
        /// @throw NS_ERROR_FAILURE
        /// Indicates that aListener was already registered.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AddProgressListener([MarshalAs(UnmanagedType.Interface)] nsIWebProgressListener aListener, uint aNotifyMask);
		
		/// <summary>
        /// Removes a previously registered listener of progress events.
        ///
        /// @param aListener
        /// The listener interface previously registered with a call to
        /// addProgressListener.
        ///
        /// @throw NS_ERROR_FAILURE
        /// Indicates that aListener was not registered.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RemoveProgressListener([MarshalAs(UnmanagedType.Interface)] nsIWebProgressListener aListener);
		
		/// <summary>
        /// The DOM window associated with this nsIWebProgress instance.
        ///
        /// @throw NS_ERROR_FAILURE
        /// Indicates that there is no associated DOM window.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMWindow GetDOMWindowAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		ulong GetDOMWindowIDAttribute();
		
		/// <summary>
        /// Indicates whether DOMWindow.top == DOMWindow.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetIsTopLevelAttribute();
		
		/// <summary>
        /// Indicates whether or not a document is currently being loaded
        /// in the context of this nsIWebProgress instance.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetIsLoadingDocumentAttribute();
		
		/// <summary>
        /// Contains a load type as specified by the load* constants in
        /// nsIDocShellLoadInfo.idl.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetLoadTypeAttribute();
	}
	
	/// <summary>nsIWebProgressConsts </summary>
	internal class nsIWebProgressConsts
	{
		
		// <summary>
        // These flags indicate the state transistions to observe, corresponding to
        // nsIWebProgressListener::onStateChange.
        //
        // NOTIFY_STATE_REQUEST
        // Only receive the onStateChange event if the aStateFlags parameter
        // includes nsIWebProgressListener::STATE_IS_REQUEST.
        //
        // NOTIFY_STATE_DOCUMENT
        // Only receive the onStateChange event if the aStateFlags parameter
        // includes nsIWebProgressListener::STATE_IS_DOCUMENT.
        //
        // NOTIFY_STATE_NETWORK
        // Only receive the onStateChange event if the aStateFlags parameter
        // includes nsIWebProgressListener::STATE_IS_NETWORK.
        //
        // NOTIFY_STATE_WINDOW
        // Only receive the onStateChange event if the aStateFlags parameter
        // includes nsIWebProgressListener::STATE_IS_WINDOW.
        //
        // NOTIFY_STATE_ALL
        // Receive all onStateChange events.
        // </summary>
		public const ulong NOTIFY_STATE_REQUEST = 0x00000001;
		
		// 
		public const ulong NOTIFY_STATE_DOCUMENT = 0x00000002;
		
		// 
		public const ulong NOTIFY_STATE_NETWORK = 0x00000004;
		
		// 
		public const ulong NOTIFY_STATE_WINDOW = 0x00000008;
		
		// 
		public const ulong NOTIFY_STATE_ALL = 0x0000000f;
		
		// <summary>
        // These flags indicate the other events to observe, corresponding to the
        // other four methods defined on nsIWebProgressListener.
        //
        // NOTIFY_PROGRESS
        // Receive onProgressChange events.
        //
        // NOTIFY_STATUS
        // Receive onStatusChange events.
        //
        // NOTIFY_SECURITY
        // Receive onSecurityChange events.
        //
        // NOTIFY_LOCATION
        // Receive onLocationChange events.
        //
        // NOTIFY_REFRESH
        // Receive onRefreshAttempted events.
        // This is defined on nsIWebProgressListener2.
        // </summary>
		public const ulong NOTIFY_PROGRESS = 0x00000010;
		
		// 
		public const ulong NOTIFY_STATUS = 0x00000020;
		
		// 
		public const ulong NOTIFY_SECURITY = 0x00000040;
		
		// 
		public const ulong NOTIFY_LOCATION = 0x00000080;
		
		// 
		public const ulong NOTIFY_REFRESH = 0x00000100;
		
		// <summary>
        // This flag enables all notifications.
        // </summary>
		public const ulong NOTIFY_ALL = 0x000001ff;
	}
}
