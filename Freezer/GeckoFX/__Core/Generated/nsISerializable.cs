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
// Generated by IDLImporter from file nsISerializable.idl
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
	[Guid("91cca981-c26d-44a8-bebe-d9ed4891503a")]
	internal interface nsISerializable
	{
		
		/// <summary>
        /// Initialize the object implementing nsISerializable, which must have
        /// been freshly constructed via CreateInstance.  All data members that
        /// can't be set to default values must have been serialized by write,
        /// and should be read from aInputStream in the same order by this method.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Read([MarshalAs(UnmanagedType.Interface)] nsIObjectInputStream aInputStream);
		
		/// <summary>
        /// Serialize the object implementing nsISerializable to aOutputStream, by
        /// writing each data member that must be recovered later to reconstitute
        /// a working replica of this object, in a canonical member and byte order,
        /// to aOutputStream.
        ///
        /// NB: a class that implements nsISerializable *must* also implement
        /// nsIClassInfo, in particular nsIClassInfo::GetClassID.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Write([MarshalAs(UnmanagedType.Interface)] nsIObjectOutputStream aOutputStream);
	}
}
