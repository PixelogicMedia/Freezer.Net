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
// Generated by IDLImporter from file nsISecretDecoderRing.idl
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
    /// Buffer type - for storing 8-bit octet values.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("0EC80360-075C-11d4-9FD4-00C04F1B83D8")]
	internal interface nsISecretDecoderRing
	{
		
		/// <summary>
        /// Encrypt a buffer - callable only from C++.
        ///
        /// @return The length of the data in the output buffer.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int Encrypt(System.IntPtr data, int dataLen, ref System.IntPtr result);
		
		/// <summary>
        /// Decrypt a buffer - callable only from C++.
        ///
        /// @return The length of the data in the output buffer.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int Decrypt(System.IntPtr data, int dataLen, ref System.IntPtr result);
		
		/// <summary>
        /// Encrypt nul-terminated string to BASE64 output.
        /// </summary>
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.StringMarshaler")]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string EncryptString([MarshalAs(UnmanagedType.LPStr)] string text);
		
		/// <summary>
        /// Decrypt BASE64 input to nul-terminated string output.  There is
        /// no check for embedded nul values in the decrypted output.
        /// </summary>
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.StringMarshaler")]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string DecryptString([MarshalAs(UnmanagedType.LPStr)] string crypt);
		
		/// <summary>
        /// Prompt the user to change the password on the SDR key.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ChangePassword();
		
		/// <summary>
        /// Logout of the security device that protects the SDR key.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Logout();
		
		/// <summary>
        /// Logout of the security device that protects the SDR key and tear
        /// down authenticated objects.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void LogoutAndTeardown();
	}
	
	/// <summary>
    /// Configuration interface for the Secret Decoder Ring
    /// - this interface allows setting the window that will be
    /// used as parent for dialog windows (such as password prompts)
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("01D8C0F0-0CCC-11d4-9FDD-000064657374")]
	internal interface nsISecretDecoderRingConfig
	{
		
		/// <summary>
        /// Configuration interface for the Secret Decoder Ring
        /// - this interface allows setting the window that will be
        /// used as parent for dialog windows (such as password prompts)
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetWindow([MarshalAs(UnmanagedType.Interface)] nsISupports w);
	}
}
