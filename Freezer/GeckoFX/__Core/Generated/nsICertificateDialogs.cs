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
// Generated by IDLImporter from file nsICertificateDialogs.idl
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
    /// Functions that implement user interface dialogs to manage certificates.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("da871dab-f69e-4173-ab26-99fcd47b0e85")]
	internal interface nsICertificateDialogs
	{
		
		/// <summary>
        /// UI shown when a user is asked to download a new CA cert.
        /// Provides user with ability to choose trust settings for the cert.
        /// Asks the user to grant permission to import the certificate.
        ///
        /// @param ctx A user interface context.
        /// @param cert The certificate that is about to get installed.
        /// @param trust a bit mask of trust flags,
        /// see nsIX509CertDB for possible values.
        ///
        /// @return true if the user allows to import the certificate.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool ConfirmDownloadCACert([MarshalAs(UnmanagedType.Interface)] nsIInterfaceRequestor ctx, [MarshalAs(UnmanagedType.Interface)] nsIX509Cert cert, ref uint trust);
		
		/// <summary>
        /// UI shown when a web site has delivered a CA certificate to
        /// be imported, but the certificate is already contained in the
        /// user's storage.
        ///
        /// @param ctx A user interface context.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void NotifyCACertExists([MarshalAs(UnmanagedType.Interface)] nsIInterfaceRequestor ctx);
		
		/// <summary>
        /// UI shown when a user's personal certificate is going to be
        /// exported to a backup file.
        /// The implementation of this dialog should make sure
        /// to prompt the user to type the password twice in order to
        /// confirm correct input.
        /// The wording in the dialog should also motivate the user
        /// to enter a strong password.
        ///
        /// @param ctx A user interface context.
        /// @param password The password provided by the user.
        ///
        /// @return false if the user requests to cancel.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool SetPKCS12FilePassword([MarshalAs(UnmanagedType.Interface)] nsIInterfaceRequestor ctx, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase password);
		
		/// <summary>
        /// UI shown when a user is about to restore a personal
        /// certificate from a backup file.
        /// The user is requested to enter the password
        /// that was used in the past to protect that backup file.
        ///
        /// @param ctx A user interface context.
        /// @param password The password provided by the user.
        ///
        /// @return false if the user requests to cancel.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetPKCS12FilePassword([MarshalAs(UnmanagedType.Interface)] nsIInterfaceRequestor ctx, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase password);
		
		/// <summary>
        /// UI shown when a certificate needs to be shown to the user.
        /// The implementation should try to display as many attributes
        /// as possible.
        ///
        /// @param ctx A user interface context.
        /// @param cert The certificate to be shown to the user.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ViewCert([MarshalAs(UnmanagedType.Interface)] nsIInterfaceRequestor ctx, [MarshalAs(UnmanagedType.Interface)] nsIX509Cert cert);
	}
}
