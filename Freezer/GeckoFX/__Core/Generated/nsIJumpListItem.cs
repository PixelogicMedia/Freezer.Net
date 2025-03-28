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
// Generated by IDLImporter from file nsIJumpListItem.idl
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
    /// Implements Win7 Taskbar jump list item interfaces.
    ///
    /// Note to consumers: it's reasonable to expect we'll need support for other types
    /// of jump list items (an audio file, an email message, etc.). To add types,
    /// create the specific interface here, add an implementation class to WinJumpListItem,
    /// and add support to addListBuild & removed items processing.
    ///
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("ACB8FB3C-E1B0-4044-8A50-E52C3E7C1057")]
	internal interface nsIJumpListItem
	{
		
		/// <summary>
        /// Retrieves the jump list item type.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		short GetTypeAttribute();
		
		/// <summary>
        /// Compare this item to another.
        ///
        /// Compares the type and other properties specific to this item's
        /// type.
        ///
        /// separator: type
        /// link: type, uri, title
        /// shortcut: type, handler app
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool Equals([MarshalAs(UnmanagedType.Interface)] nsIJumpListItem item);
	}
	
	/// <summary>nsIJumpListItemConsts </summary>
	internal class nsIJumpListItemConsts
	{
		
		// <summary>
        // Implements Win7 Taskbar jump list item interfaces.
        //
        // Note to consumers: it's reasonable to expect we'll need support for other types
        // of jump list items (an audio file, an email message, etc.). To add types,
        // create the specific interface here, add an implementation class to WinJumpListItem,
        // and add support to addListBuild & removed items processing.
        //
        // </summary>
		public const short JUMPLIST_ITEM_EMPTY = 0;
		
		// <summary>
        // Empty list item
        // </summary>
		public const short JUMPLIST_ITEM_SEPARATOR = 1;
		
		// <summary>
        // Separator
        // </summary>
		public const short JUMPLIST_ITEM_LINK = 2;
		
		// <summary>
        // Web link item
        // </summary>
		public const short JUMPLIST_ITEM_SHORTCUT = 3;
	}
	
	/// <summary>
    /// A menu separator.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("69A2D5C5-14DC-47da-925D-869E0BD64D27")]
	internal interface nsIJumpListSeparator : nsIJumpListItem
	{
		
		/// <summary>
        /// Retrieves the jump list item type.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new short GetTypeAttribute();
		
		/// <summary>
        /// Compare this item to another.
        ///
        /// Compares the type and other properties specific to this item's
        /// type.
        ///
        /// separator: type
        /// link: type, uri, title
        /// shortcut: type, handler app
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool Equals([MarshalAs(UnmanagedType.Interface)] nsIJumpListItem item);
	}
	
	/// <summary>
    /// A URI link jump list item.
    ///
    /// Note the application must be the registered protocol
    /// handler for the protocol of the link.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("76EA47B1-C797-49b3-9F18-5E740A688524")]
	internal interface nsIJumpListLink : nsIJumpListItem
	{
		
		/// <summary>
        /// Retrieves the jump list item type.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new short GetTypeAttribute();
		
		/// <summary>
        /// Compare this item to another.
        ///
        /// Compares the type and other properties specific to this item's
        /// type.
        ///
        /// separator: type
        /// link: type, uri, title
        /// shortcut: type, handler app
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool Equals([MarshalAs(UnmanagedType.Interface)] nsIJumpListItem item);
		
		/// <summary>
        /// Set or get the uri for this link item.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetUriAttribute();
		
		/// <summary>
        /// Set or get the uri for this link item.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetUriAttribute([MarshalAs(UnmanagedType.Interface)] nsIURI aUri);
		
		/// <summary>
        /// Set or get the title for a link item.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetUriTitleAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aUriTitle);
		
		/// <summary>
        /// Set or get the title for a link item.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetUriTitleAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aUriTitle);
		
		/// <summary>
        /// Get a 'privacy safe' unique string hash of the uri's
        /// spec. Useful in tracking removed items using visible
        /// data stores such as prefs. Generates an MD5 hash of
        /// the URI spec using nsICryptoHash.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetUriHashAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aUriHash);
		
		/// <summary>
        /// Compare this item's hash to another uri.
        ///
        /// Generates a spec hash of the incoming uri and compares
        /// it to this item's uri spec hash.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool CompareHash([MarshalAs(UnmanagedType.Interface)] nsIURI uri);
	}
	
	/// <summary>
    /// A generic application shortcut with command line support.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("CBE3A37C-BCE1-4fec-80A5-5FFBC7F33EEA")]
	internal interface nsIJumpListShortcut : nsIJumpListItem
	{
		
		/// <summary>
        /// Retrieves the jump list item type.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new short GetTypeAttribute();
		
		/// <summary>
        /// Compare this item to another.
        ///
        /// Compares the type and other properties specific to this item's
        /// type.
        ///
        /// separator: type
        /// link: type, uri, title
        /// shortcut: type, handler app
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool Equals([MarshalAs(UnmanagedType.Interface)] nsIJumpListItem item);
		
		/// <summary>
        /// Set or get the handler app for this shortcut item.
        ///
        /// The handler app may also be used along with iconIndex to generate an icon
        /// for the jump list item.
        ///
        /// @throw NS_ERROR_FILE_NOT_FOUND if the handler app can
        /// not be found on  the system.
        ///
        /// @see faviconPageUri
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILocalHandlerApp GetAppAttribute();
		
		/// <summary>
        /// Set or get the handler app for this shortcut item.
        ///
        /// The handler app may also be used along with iconIndex to generate an icon
        /// for the jump list item.
        ///
        /// @throw NS_ERROR_FILE_NOT_FOUND if the handler app can
        /// not be found on  the system.
        ///
        /// @see faviconPageUri
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetAppAttribute([MarshalAs(UnmanagedType.Interface)] nsILocalHandlerApp aApp);
		
		/// <summary>
        /// Set or get the icon displayed with the jump list item.
        ///
        /// Indicates the resource index of the icon contained within the handler
        /// executable which may be used as the jump list icon.
        ///
        /// @see faviconPageUri
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetIconIndexAttribute();
		
		/// <summary>
        /// Set or get the icon displayed with the jump list item.
        ///
        /// Indicates the resource index of the icon contained within the handler
        /// executable which may be used as the jump list icon.
        ///
        /// @see faviconPageUri
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetIconIndexAttribute(int aIconIndex);
		
		/// <summary>
        /// Set or get the URI of a page whose favicon may be used as the icon.
        ///
        /// When a jump list build occurs, the favicon to be used for the item is
        /// obtained using the following steps:
        /// - First, attempt to use the asynchronously retrieved and scaled favicon
        /// associated with the faviconPageUri.
        /// - If faviconPageUri is null, or if retrieving the favicon fails, fall
        /// back to using the handler executable and iconIndex.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetFaviconPageUriAttribute();
		
		/// <summary>
        /// Set or get the URI of a page whose favicon may be used as the icon.
        ///
        /// When a jump list build occurs, the favicon to be used for the item is
        /// obtained using the following steps:
        /// - First, attempt to use the asynchronously retrieved and scaled favicon
        /// associated with the faviconPageUri.
        /// - If faviconPageUri is null, or if retrieving the favicon fails, fall
        /// back to using the handler executable and iconIndex.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetFaviconPageUriAttribute([MarshalAs(UnmanagedType.Interface)] nsIURI aFaviconPageUri);
	}
}
