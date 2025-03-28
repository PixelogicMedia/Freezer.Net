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
// Generated by IDLImporter from file nsIHttpEventSink.idl
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
    /// nsIHttpEventSink
    ///
    /// Implement this interface to receive control over various HTTP events.  The
    /// HTTP channel will try to get this interface from its notificationCallbacks
    /// attribute, and if it doesn't find it there it will look for it from its
    /// loadGroup's notificationCallbacks attribute.
    ///
    /// These methods are called before onStartRequest, and should be handled
    /// SYNCHRONOUSLY.
    ///
    /// @deprecated Newly written code should use nsIChannelEventSink instead of this
    /// interface.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("9475a6af-6352-4251-90f9-d65b1cd2ea15")]
	internal interface nsIHttpEventSink
	{
		
		/// <summary>
        /// Called when a redirect occurs due to a HTTP response like 302.  The
        /// redirection may be to a non-http channel.
        ///
        /// @return failure cancels redirect
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnRedirect([MarshalAs(UnmanagedType.Interface)] nsIHttpChannel httpChannel, [MarshalAs(UnmanagedType.Interface)] nsIChannel newChannel);
	}
}
