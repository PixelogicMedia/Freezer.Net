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
// Generated by IDLImporter from file nsIInputStreamPump.idl
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
    /// nsIInputStreamPump
    ///
    /// This interface provides a means to configure and use a input stream pump
    /// instance.  The input stream pump will asynchronously read from an input
    /// stream, and push data to an nsIStreamListener instance.  It utilizes the
    /// current thread's nsIEventTarget in order to make reading from the stream
    /// asynchronous. A different thread can be used if the pump also implements
    /// nsIThreadRetargetableRequest.
    ///
    /// If the given stream supports nsIAsyncInputStream, then the stream pump will
    /// call the stream's AsyncWait method to drive the stream listener.  Otherwise,
    /// the stream will be read on a background thread utilizing the stream
    /// transport service.  More details are provided below.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("400F5468-97E7-4d2b-9C65-A82AECC7AE82")]
	internal interface nsIInputStreamPump : nsIRequest
	{
		
		/// <summary>
        /// The name of the request.  Often this is the URI of the request.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetNameAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aName);
		
		/// <summary>
        /// Indicates whether the request is pending. nsIRequest::isPending is
        /// true when there is an outstanding asynchronous event that will make
        /// the request no longer be pending.  Requests do not necessarily start
        /// out pending; in some cases, requests have to be explicitly initiated
        /// (e.g. nsIChannel implementations are only pending once asyncOpen
        /// returns successfully).
        ///
        /// Requests can become pending multiple times during their lifetime.
        ///
        /// @return TRUE if the request has yet to reach completion.
        /// @return FALSE if the request has reached completion (e.g., after
        /// OnStopRequest has fired).
        /// @note Suspended requests are still considered pending.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool IsPending();
		
		/// <summary>
        /// The error status associated with the request.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new int GetStatusAttribute();
		
		/// <summary>
        /// Cancels the current request.  This will close any open input or
        /// output streams and terminate any async requests.  Users should
        /// normally pass NS_BINDING_ABORTED, although other errors may also
        /// be passed.  The error passed in will become the value of the
        /// status attribute.
        ///
        /// Implementations must not send any notifications (e.g. via
        /// nsIRequestObserver) synchronously from this function. Similarly,
        /// removal from the load group (if any) must also happen asynchronously.
        ///
        /// Requests that use nsIStreamListener must not call onDataAvailable
        /// anymore after cancel has been called.
        ///
        /// @param aStatus the reason for canceling this request.
        ///
        /// NOTE: most nsIRequest implementations expect aStatus to be a
        /// failure code; however, some implementations may allow aStatus to
        /// be a success code such as NS_OK.  In general, aStatus should be
        /// a failure code.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Cancel(int aStatus);
		
		/// <summary>
        /// Suspends the current request.  This may have the effect of closing
        /// any underlying transport (in order to free up resources), although
        /// any open streams remain logically opened and will continue delivering
        /// data when the transport is resumed.
        ///
        /// Calling cancel() on a suspended request must not send any
        /// notifications (such as onstopRequest) until the request is resumed.
        ///
        /// NOTE: some implementations are unable to immediately suspend, and
        /// may continue to deliver events already posted to an event queue. In
        /// general, callers should be capable of handling events even after
        /// suspending a request.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Suspend();
		
		/// <summary>
        /// Resumes the current request.  This may have the effect of re-opening
        /// any underlying transport and will resume the delivery of data to
        /// any open streams.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Resume();
		
		/// <summary>
        /// The load group of this request.  While pending, the request is a
        /// member of the load group.  It is the responsibility of the request
        /// to implement this policy.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsILoadGroup GetLoadGroupAttribute();
		
		/// <summary>
        /// The load group of this request.  While pending, the request is a
        /// member of the load group.  It is the responsibility of the request
        /// to implement this policy.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetLoadGroupAttribute([MarshalAs(UnmanagedType.Interface)] nsILoadGroup aLoadGroup);
		
		/// <summary>
        /// The load flags of this request.  Bits 0-15 are reserved.
        ///
        /// When added to a load group, this request's load flags are merged with
        /// the load flags of the load group.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new uint GetLoadFlagsAttribute();
		
		/// <summary>
        /// The load flags of this request.  Bits 0-15 are reserved.
        ///
        /// When added to a load group, this request's load flags are merged with
        /// the load flags of the load group.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetLoadFlagsAttribute(uint aLoadFlags);
		
		/// <summary>
        /// Initialize the input stream pump.
        ///
        /// @param aStream
        /// contains the data to be read.  if the input stream is non-blocking,
        /// then it will be QI'd to nsIAsyncInputStream.  if the QI succeeds
        /// then the stream will be read directly.  otherwise, it will be read
        /// on a background thread using the stream transport service.
        /// @param aStreamPos
        /// specifies the stream offset from which to start reading.  the
        /// offset value is absolute.  pass -1 to specify the current offset.
        /// NOTE: this parameter is ignored if the underlying stream does not
        /// implement nsISeekableStream.
        /// @param aStreamLen
        /// specifies how much data to read from the stream.  pass -1 to read
        /// all data available in the stream.
        /// @param aSegmentSize
        /// if the stream transport service is used, then this parameter
        /// specifies the segment size for the stream transport's buffer.
        /// pass 0 to specify the default value.
        /// @param aSegmentCount
        /// if the stream transport service is used, then this parameter
        /// specifies the segment count for the stream transport's buffer.
        /// pass 0 to specify the default value.
        /// @param aCloseWhenDone
        /// if true, the input stream will be closed after it has been read.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Init([MarshalAs(UnmanagedType.Interface)] nsIInputStream aStream, long aStreamPos, long aStreamLen, uint aSegmentSize, uint aSegmentCount, [MarshalAs(UnmanagedType.U1)] bool aCloseWhenDone);
		
		/// <summary>
        /// asyncRead causes the input stream to be read in chunks and delivered
        /// asynchronously to the listener via OnDataAvailable.
        ///
        /// @param aListener
        /// receives notifications.
        /// @param aListenerContext
        /// passed to listener methods.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AsyncRead([MarshalAs(UnmanagedType.Interface)] nsIStreamListener aListener, [MarshalAs(UnmanagedType.Interface)] nsISupports aListenerContext);
	}
}
