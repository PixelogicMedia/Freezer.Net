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
// Generated by IDLImporter from file nsILoadContextInfo.idl
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
    /// Helper interface to carry informatin about the load context
    /// encapsulating origin attributes and IsAnonymous, IsPrivite properties.
    /// It shall be used where nsILoadContext cannot be used or is not
    /// available.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("555e2f8a-a1f6-41dd-88ca-ed4ed6b98a22")]
	internal interface nsILoadContextInfo
	{
		
		/// <summary>
        /// Whether the context is in a Private Browsing mode
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetIsPrivateAttribute();
		
		/// <summary>
        /// Whether the load is initiated as anonymous
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetIsAnonymousAttribute();
		
		/// <summary>
        /// NeckoOriginAttributes hiding all the security context attributes
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal GetOriginAttributesAttribute(System.IntPtr jsContext);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr BinaryOriginAttributesPtr();
	}
	
	/// <summary>nsILoadContextInfoConsts </summary>
	internal class nsILoadContextInfoConsts
	{
		
		// <summary>
        // Helper interface to carry informatin about the load context
        // encapsulating origin attributes and IsAnonymous, IsPrivite properties.
        // It shall be used where nsILoadContext cannot be used or is not
        // available.
        // </summary>
		public const ulong NO_APP_ID = 0;
		
		// 
		public const ulong UNKNOWN_APP_ID = 4294967295;
	}
	
	/// <summary>
    /// Since NeckoOriginAttributes struct limits the implementation of
    /// nsILoadContextInfo (that needs to be thread safe) to C++,
    /// we need a scriptable factory to create instances of that
    /// interface from JS.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("c1c7023d-4318-4f99-8307-b5ccf0558793")]
	internal interface nsILoadContextInfoFactory
	{
		
		/// <summary>
        /// Since NeckoOriginAttributes struct limits the implementation of
        /// nsILoadContextInfo (that needs to be thread safe) to C++,
        /// we need a scriptable factory to create instances of that
        /// interface from JS.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILoadContextInfo GetDefaultAttribute();
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILoadContextInfo GetPrivateAttribute();
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILoadContextInfo GetAnonymousAttribute();
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILoadContextInfo Custom([MarshalAs(UnmanagedType.U1)] bool aPrivate, [MarshalAs(UnmanagedType.U1)] bool aAnonymous, ref Gecko.JsVal aOriginAttributes, System.IntPtr jsContext);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILoadContextInfo FromLoadContext([MarshalAs(UnmanagedType.Interface)] nsILoadContext aLoadContext, [MarshalAs(UnmanagedType.U1)] bool aAnonymous);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsILoadContextInfo FromWindow([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.U1)] bool aAnonymous);
	}
}
