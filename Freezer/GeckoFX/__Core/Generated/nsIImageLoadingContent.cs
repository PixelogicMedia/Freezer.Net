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
// Generated by IDLImporter from file nsIImageLoadingContent.idl
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
    /// This interface represents a content node that loads images.  The interface
    /// exists to allow getting information on the images that the content node
    /// loads and to allow registration of observers for the image loads.
    ///
    /// Implementors of this interface should handle all the mechanics of actually
    /// loading an image -- getting the URI, checking with content policies and
    /// the security manager to see whether loading the URI is allowed, performing
    /// the load, firing any DOM events as needed.
    ///
    /// An implementation of this interface may support the concepts of a
    /// "current" image and a "pending" image.  If it does, a request to change
    /// the currently loaded image will start a "pending" request which will
    /// become current only when the image is loaded.  It is the responsibility of
    /// observers to check which request they are getting notifications for.
    ///
    /// Please make sure to update the MozImageLoadingContent WebIDL
    /// interface to mirror this interface when changing it.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("770f7d84-c917-42d7-bf8d-d1b70649e733")]
	internal interface nsIImageLoadingContent : imgINotificationObserver
	{
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Notify(imgIRequest aProxy, int aType, [MarshalAs(UnmanagedType.Interface)] nsIntRect aRect);
		
		/// <summary>
        /// loadingEnabled is used to enable and disable loading in
        /// situations where loading images is unwanted.  Note that enabling
        /// loading will *not* automatically trigger an image load.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetLoadingEnabledAttribute();
		
		/// <summary>
        /// loadingEnabled is used to enable and disable loading in
        /// situations where loading images is unwanted.  Note that enabling
        /// loading will *not* automatically trigger an image load.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetLoadingEnabledAttribute([MarshalAs(UnmanagedType.U1)] bool aLoadingEnabled);
		
		/// <summary>
        /// Returns the image blocking status (@see nsIContentPolicy).  This
        /// will always be an nsIContentPolicy REJECT_* status for cases when
        /// the image was blocked.  This status always refers to the
        /// CURRENT_REQUEST load.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		short GetImageBlockingStatusAttribute();
		
		/// <summary>
        /// Used to register an image decoder observer.  Typically, this will
        /// be a proxy for a frame that wants to paint the image.
        /// Notifications from ongoing image loads will be passed to all
        /// registered observers.  Notifications for all request types,
        /// current and pending, will be passed through.
        ///
        /// @param aObserver the observer to register
        ///
        /// @throws NS_ERROR_OUT_OF_MEMORY
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AddObserver(imgINotificationObserver aObserver);
		
		/// <summary>
        /// Used to unregister an image decoder observer.
        ///
        /// @param aObserver the observer to unregister
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RemoveObserver(imgINotificationObserver aObserver);
		
		/// <summary>
        /// Accessor to get the image requests
        ///
        /// @param aRequestType a value saying which request is wanted
        ///
        /// @return the imgIRequest object (may be null, even when no error
        /// is thrown)
        ///
        /// @throws NS_ERROR_UNEXPECTED if the request type requested is not
        /// known
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		imgIRequest GetRequest(int aRequestType);
		
		/// <summary>
        /// @return true if the current request's size is available.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool CurrentRequestHasSize();
		
		/// <summary>
        /// Used to notify the image loading content node that a frame has been
        /// created.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void FrameCreated(System.IntPtr aFrame);
		
		/// <summary>
        /// Used to notify the image loading content node that a frame has been
        /// destroyed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void FrameDestroyed(System.IntPtr aFrame);
		
		/// <summary>
        /// Used to find out what type of request one is dealing with (eg
        /// which request got passed through to the imgINotificationObserver
        /// interface of an observer)
        ///
        /// @param aRequest the request whose type we want to know
        ///
        /// @return an enum value saying what type this request is
        ///
        /// @throws NS_ERROR_UNEXPECTED if aRequest is not known
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetRequestType(imgIRequest aRequest);
		
		/// <summary>
        /// Gets the URI of the current request, if available.
        /// Otherwise, returns the last URI that this content tried to load, or
        /// null if there haven't been any such attempts.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetCurrentURIAttribute();
		
		/// <summary>
        /// loadImageWithChannel allows data from an existing channel to be
        /// used as the image data for this content node.
        ///
        /// @param aChannel the channel that will deliver the data
        ///
        /// @return a stream listener to pump the image data into
        ///
        /// @see imgILoader::loadImageWithChannel
        ///
        /// @throws NS_ERROR_NULL_POINTER if aChannel is null
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIStreamListener LoadImageWithChannel([MarshalAs(UnmanagedType.Interface)] nsIChannel aChannel);
		
		/// <summary>
        ///= true </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ForceReload([MarshalAs(UnmanagedType.U1)] bool aNotify, int argc);
		
		/// <summary>
        /// Enables/disables image state forcing. When |aForce| is PR_TRUE, we force
        /// nsImageLoadingContent::ImageState() to return |aState|. Call again with |aForce|
        /// as PR_FALSE to revert ImageState() to its original behaviour.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ForceImageState([MarshalAs(UnmanagedType.U1)] bool aForce, ulong aState);
		
		/// <summary>
        /// The intrinsic size and width of this content. May differ from actual image
        /// size due to things like responsive image density.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetNaturalWidthAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetNaturalHeightAttribute();
		
		/// <summary>
        /// A visible count is stored, if it is non-zero then this image is considered
        /// visible. These methods increment, decrement, or return the visible count.
        ///
        /// @param aNonvisibleAction What to do if the image's visibility count is now
        /// zero. If ON_NONVISIBLE_NO_ACTION, nothing will be
        /// done. If ON_NONVISIBLE_REQUEST_DISCARD, the image
        /// will be asked to discard its surfaces if possible.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void IncrementVisibleCount();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DecrementVisibleCount(uint aNonvisibleAction);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetVisibleCount();
	}
	
	/// <summary>nsIImageLoadingContentConsts </summary>
	internal class nsIImageLoadingContentConsts
	{
		
		// <summary>
        // Request types.  Image loading content nodes attempt to do atomic
        // image changes when the image url is changed.  This means that
        // when the url changes the new image load will start, but the old
        // image will remain the "current" request until the new image is
        // fully loaded.  At that point, the old "current" request will be
        // discarded and the "pending" request will become "current".
        // </summary>
		public const long UNKNOWN_REQUEST = -1;
		
		// 
		public const long CURRENT_REQUEST = 0;
		
		// 
		public const long PENDING_REQUEST = 1;
		
		// 
		public const long ON_NONVISIBLE_NO_ACTION = 0;
		
		// 
		public const long ON_NONVISIBLE_REQUEST_DISCARD = 1;
	}
}
