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
// Generated by IDLImporter from file nsINetAddr.idl
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
    /// nsINetAddr
    ///
    /// This interface represents a native NetAddr struct in a readonly
    /// interface.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("652B9EC5-D159-45D7-9127-50BB559486CD")]
	internal interface nsINetAddr
	{
		
		/// <summary>
        /// @return the address family of the network address, which corresponds to
        /// one of the FAMILY_ constants.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		ushort GetFamilyAttribute();
		
		/// <summary>
        /// @return Either the IP address (FAMILY_INET, FAMILY_INET6) or the path
        /// (FAMILY_LOCAL) in string form. IP addresses are in the format produced by
        /// mozilla::net::NetAddrToString.
        ///
        /// Note: Paths for FAMILY_LOCAL may have length limitations which are
        /// implementation dependent and not documented as part of this interface.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetAddressAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aAddress);
		
		/// <summary>
        /// @return the port number for a FAMILY_INET or FAMILY_INET6 address.
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if the address family is not FAMILY_INET or
        /// FAMILY_INET6.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		ushort GetPortAttribute();
		
		/// <summary>
        /// @return the flow label for a FAMILY_INET6 address.
        ///
        /// @see http://www.ietf.org/rfc/rfc3697.txt
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if the address family is not FAMILY_INET6
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetFlowAttribute();
		
		/// <summary>
        /// @return the address scope of a FAMILY_INET6 address.
        ///
        /// @see http://tools.ietf.org/html/rfc4007
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if the address family is not FAMILY_INET6
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetScopeAttribute();
		
		/// <summary>
        /// @return whether a FAMILY_INET6 address is mapped from FAMILY_INET.
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if the address family is not FAMILY_INET6
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetIsV4MappedAttribute();
		
		/// <summary>
        /// @return the underlying NetAddr struct.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetNetAddr();
	}
	
	/// <summary>nsINetAddrConsts </summary>
	internal class nsINetAddrConsts
	{
		
		// <summary>
        // Network address families. These correspond to all the network address
        // families supported by the NetAddr struct.
        // </summary>
		public const ulong FAMILY_INET = 1;
		
		// 
		public const ulong FAMILY_INET6 = 2;
		
		// 
		public const ulong FAMILY_LOCAL = 3;
	}
}
