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
// Generated by IDLImporter from file nsIINIParser.idl
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
	[Guid("7eb955f6-3e78-4d39-b72f-c1bf12a94bce")]
	internal interface nsIINIParser
	{
		
		/// <summary>
        /// Enumerates the [section]s available in the INI file.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIUTF8StringEnumerator GetSections();
		
		/// <summary>
        /// Enumerates the keys available within a section.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIUTF8StringEnumerator GetKeys([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSection);
		
		/// <summary>
        /// Get the value of a string for a particular section and key.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetString([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSection, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aKey, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase retval);
	}
	
	/// <summary>nsIINIParserWriter </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b67bb24b-31a3-4a6a-a5d9-0485c9af5a04")]
	internal interface nsIINIParserWriter
	{
		
		/// <summary>
        /// Set the value of a string for a particular section and key.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetString([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSection, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aKey, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aValue);
		
		/// <summary>
        /// Write to the INI file.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void WriteFile([MarshalAs(UnmanagedType.Interface)] nsIFile aINIFile, uint aFlags);
	}
	
	/// <summary>nsIINIParserWriterConsts </summary>
	internal class nsIINIParserWriterConsts
	{
		
		// <summary>
        // Windows and the NSIS installer code sometimes expect INI files to be in
        // UTF-16 encoding. On Windows only, this flag to writeFile can be used to
        // change the encoding from its default UTF-8.
        // </summary>
		public const ulong WRITE_UTF16 = 0x1;
	}
	
	/// <summary>nsIINIParserFactory </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("ccae7ea5-1218-4b51-aecb-c2d8ecd46af9")]
	internal interface nsIINIParserFactory
	{
		
		/// <summary>
        /// Create an iniparser instance from a local file.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIINIParser CreateINIParser([MarshalAs(UnmanagedType.Interface)] nsIFile aINIFile);
	}
}
