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
// Generated by IDLImporter from file nsIDOMGeoPositionError.idl
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
    /// undef the GetMessage macro defined in winuser.h from the MS Platform SDK
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("85255CC3-07BA-49FD-BC9B-18D2963DAF7F")]
	internal interface nsIDOMGeoPositionError
	{
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		short GetCodeAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetMessageAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aMessage);
	}
	
	/// <summary>nsIDOMGeoPositionErrorConsts </summary>
	internal class nsIDOMGeoPositionErrorConsts
	{
		
		// <summary>
        // undef the GetMessage macro defined in winuser.h from the MS Platform SDK
        // </summary>
		public const ushort PERMISSION_DENIED = 1;
		
		// 
		public const ushort POSITION_UNAVAILABLE = 2;
		
		// 
		public const ushort TIMEOUT = 3;
	}
}
