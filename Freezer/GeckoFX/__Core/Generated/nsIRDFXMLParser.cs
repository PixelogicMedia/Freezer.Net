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
// Generated by IDLImporter from file nsIRDFXMLParser.idl
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
    ///-*- Mode: C++; tab-width: 4; indent-tabs-mode: nil; c-basic-offset: 4 -*-
    ///
    /// This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("1831dd2e-1dd2-11b2-bdb3-86b7b50b70b5")]
	internal interface nsIRDFXMLParser
	{
		
		/// <summary>
        /// Create a stream listener that can be used to asynchronously
        /// parse RDF/XML.
        /// @param aSink the RDF datasource the will receive the data
        /// @param aBaseURI the base URI used to resolve relative
        /// references in the RDF/XML
        /// @return an nsIStreamListener object to handle the data
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIStreamListener ParseAsync([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aSink, [MarshalAs(UnmanagedType.Interface)] nsIURI aBaseURI);
		
		/// <summary>
        /// Parse a string of RDF/XML
        /// @param aSink the RDF datasource that will receive the data
        /// @param aBaseURI the base URI used to resolve relative
        /// references in the RDF/XML
        /// @param aSource a UTF8 string containing RDF/XML data.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ParseString([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aSink, [MarshalAs(UnmanagedType.Interface)] nsIURI aBaseURI, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSource);
	}
}
