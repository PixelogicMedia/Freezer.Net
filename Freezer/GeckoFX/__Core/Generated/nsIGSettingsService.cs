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
// Generated by IDLImporter from file nsIGSettingsService.idl
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
	[Guid("16d5b0ed-e756-4f1b-a8ce-9132e869acd8")]
	internal interface nsIGSettingsCollection
	{
		
		/// <summary>
        ///This Source Code Form is subject to the terms of the Mozilla Public
        /// License, v. 2.0. If a copy of the MPL was not distributed with this
        /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetString([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase value);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetBoolean([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key, [MarshalAs(UnmanagedType.U1)] bool value);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetInt([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key, int value);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetString([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase retval);
		
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetBoolean([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetInt([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key);
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIArray GetStringList([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase key);
	}
	
	/// <summary>nsIGSettingsService </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("849c088b-57d1-4f24-b7b2-3dc4acb04c0a")]
	internal interface nsIGSettingsService
	{
		
		/// <summary>Member GetCollectionForSchema </summary>
		/// <param name='schema'> </param>
		/// <returns>A nsIGSettingsCollection</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIGSettingsCollection GetCollectionForSchema([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase schema);
	}
}
