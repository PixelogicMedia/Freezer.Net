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
// Generated by IDLImporter from file nsIFeedGenerator.idl
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
    /// An nsIFeedGenerator represents the software used to create a feed.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("0fecd56b-bd92-481b-a486-b8d489cdd385")]
	internal interface nsIFeedGenerator : nsIFeedElementBase
	{
		
		/// <summary>
        /// The attributes found on the element. Most interfaces provide convenience
        /// accessors for their standard fields, so this useful only when looking for
        /// an extension.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISAXAttributes GetAttributesAttribute();
		
		/// <summary>
        /// The attributes found on the element. Most interfaces provide convenience
        /// accessors for their standard fields, so this useful only when looking for
        /// an extension.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetAttributesAttribute([MarshalAs(UnmanagedType.Interface)] nsISAXAttributes aAttributes);
		
		/// <summary>
        /// The baseURI for the Entry or Feed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIURI GetBaseURIAttribute();
		
		/// <summary>
        /// The baseURI for the Entry or Feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetBaseURIAttribute([MarshalAs(UnmanagedType.Interface)] nsIURI aBaseURI);
		
		/// <summary>
        /// The name of the software.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetAgentAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aAgent);
		
		/// <summary>
        /// The name of the software.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetAgentAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aAgent);
		
		/// <summary>
        /// The version of the software.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetVersionAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aVersion);
		
		/// <summary>
        /// The version of the software.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetVersionAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aVersion);
		
		/// <summary>
        /// A URI associated with the software.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetUriAttribute();
		
		/// <summary>
        /// A URI associated with the software.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetUriAttribute([MarshalAs(UnmanagedType.Interface)] nsIURI aUri);
	}
}
