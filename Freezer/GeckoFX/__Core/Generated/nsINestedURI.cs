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
// Generated by IDLImporter from file nsINestedURI.idl
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
    /// nsINestedURI is an interface that must be implemented by any nsIURI
    /// implementation which has an "inner" URI that it actually gets data
    /// from.
    ///
    /// For example, if URIs for the scheme "sanitize" have the structure:
    ///
    /// sanitize:http://example.com
    ///
    /// and opening a channel on such a sanitize: URI gets the data from
    /// http://example.com, sanitizes it, and returns it, then the sanitize: URI
    /// should implement nsINestedURI and return the http://example.com URI as its
    /// inner URI.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("6de2c874-796c-46bf-b57f-0d7bd7d6cab0")]
	internal interface nsINestedURI
	{
		
		/// <summary>
        /// The inner URI for this nested URI.  This must not return null if the
        /// getter succeeds; URIs that have no inner must not QI to this interface.
        /// Dynamically changing whether there is an inner URI is not allowed.
        ///
        /// Modifying the returned URI must not in any way modify the nested URI; this
        /// means the returned URI must be either immutable or a clone.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetInnerURIAttribute();
		
		/// <summary>
        /// The innermost URI for this nested URI.  This must not return null if the
        /// getter succeeds.  This is equivalent to repeatedly calling innerURI while
        /// the returned URI QIs to nsINestedURI.
        ///
        /// Modifying the returned URI must not in any way modify the nested URI; this
        /// means the returned URI must be either immutable or a clone.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetInnermostURIAttribute();
	}
}
