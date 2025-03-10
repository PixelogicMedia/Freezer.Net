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
// Generated by IDLImporter from file nsIAuthPrompt.idl
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
    ///This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("358089f9-ee4b-4711-82fd-bcd07fc62061")]
	internal interface nsIAuthPrompt
	{
		
		/// <summary>
        /// Puts up a text input dialog with OK and Cancel buttons.
        /// Note: prompt uses separate args for the "in" and "out" values of the
        /// input field, whereas the other functions use a single inout arg.
        /// @param  dialogText    The title for the dialog.
        /// @param  text          The text to display in the dialog.
        /// @param  passwordRealm The "realm" the password belongs to: e.g.
        /// ldap://localhost/dc=test
        /// @param  savePassword  One of the SAVE_PASSWORD_* options above.
        /// @param  defaultText   The default text to display in the text input box.
        /// @param  result        The value entered by the user if OK was
        /// selected.
        /// @return true for OK, false for Cancel
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool Prompt([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string dialogTitle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string passwordRealm, uint savePassword, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string defaultText, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] ref string result);
		
		/// <summary>
        /// Puts up a username/password dialog with OK and Cancel buttons.
        /// Puts up a password dialog with OK and Cancel buttons.
        /// @param  dialogText    The title for the dialog.
        /// @param  text          The text to display in the dialog.
        /// @param  passwordRealm The "realm" the password belongs to: e.g.
        /// ldap://localhost/dc=test
        /// @param  savePassword  One of the SAVE_PASSWORD_* options above.
        /// @param  user          The username entered in the dialog.
        /// @param  pwd           The password entered by the user if OK was
        /// selected.
        /// @return true for OK, false for Cancel
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool PromptUsernameAndPassword([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string dialogTitle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string passwordRealm, uint savePassword, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] ref string user, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] ref string pwd);
		
		/// <summary>
        /// Puts up a password dialog with OK and Cancel buttons.
        /// @param  dialogText    The title for the dialog.
        /// @param  text          The text to display in the dialog.
        /// @param  passwordRealm The "realm" the password belongs to: e.g.
        /// ldap://localhost/dc=test. If a username is
        /// specified (http://user@site.com) it will be used
        /// when matching existing logins or saving new ones.
        /// If no username is specified, only password-only
        /// logins will be matched or saved.
        /// Note: if a username is specified, the username
        /// should be escaped.
        /// @param  savePassword  One of the SAVE_PASSWORD_* options above.
        /// @param  pwd           The password entered by the user if OK was
        /// selected.
        /// @return true for OK, false for Cancel
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool PromptPassword([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string dialogTitle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string passwordRealm, uint savePassword, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] ref string pwd);
	}
	
	/// <summary>nsIAuthPromptConsts </summary>
	internal class nsIAuthPromptConsts
	{
		
		// <summary>
        //This Source Code Form is subject to the terms of the Mozilla Public
        // License, v. 2.0. If a copy of the MPL was not distributed with this
        // file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
		public const long SAVE_PASSWORD_NEVER = 0;
		
		// 
		public const long SAVE_PASSWORD_FOR_SESSION = 1;
		
		// 
		public const long SAVE_PASSWORD_PERMANENTLY = 2;
	}
}
