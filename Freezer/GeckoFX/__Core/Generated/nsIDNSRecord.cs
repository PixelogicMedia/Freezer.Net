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
// Generated by IDLImporter from file nsIDNSRecord.idl
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
    /// nsIDNSRecord
    ///
    /// this interface represents the result of a DNS lookup.  since a DNS
    /// query may return more than one resolved IP address, the record acts
    /// like an enumerator, allowing the caller to easily step through the
    /// list of IP addresses.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("f92228ae-c417-4188-a604-0830a95e7eb9")]
	internal interface nsIDNSRecord
	{
		
		/// <summary>
        /// @return the canonical hostname for this record.  this value is empty if
        /// the record was not fetched with the RESOLVE_CANONICAL_NAME flag.
        ///
        /// e.g., www.mozilla.org --> rheet.mozilla.org
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetCanonicalNameAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aCanonicalName);
		
		/// <summary>
        /// this function copies the value of the next IP address into the
        /// given NetAddr struct and increments the internal address iterator.
        ///
        /// @param aPort
        /// A port number to initialize the NetAddr with.
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if there is not another IP address in
        /// the record.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		System.IntPtr GetNextAddr(ushort aPort);
		
		/// <summary>
        /// this function copies the value of all working members of the RR
        /// set into the output array.
        ///
        /// @param aAddressArray
        /// The result set
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetAddresses(ref System.IntPtr aAddressArray);
		
		/// <summary>
        /// this function returns the value of the next IP address as a
        /// scriptable address and increments the internal address iterator.
        ///
        /// @param aPort
        /// A port number to initialize the nsINetAddr with.
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if there is not another IP address in
        /// the record.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsINetAddr GetScriptableNextAddr(ushort aPort);
		
		/// <summary>
        /// this function returns the value of the next IP address as a
        /// string and increments the internal address iterator.
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if there is not another IP address in
        /// the record.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetNextAddrAsString([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase retval);
		
		/// <summary>
        /// this function returns true if there is another address in the record.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool HasMore();
		
		/// <summary>
        /// this function resets the internal address iterator to the first
        /// address in the record.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Rewind();
		
		/// <summary>
        /// This function indicates that the last address obtained via getNextAddr*()
        /// was not usuable and should be skipped in future uses of this
        /// record if other addresses are available.
        ///
        /// @param aPort is the port number associated with the failure, if any.
        /// It may be zero if not applicable.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ReportUnusable(ushort aPort);
	}
}
