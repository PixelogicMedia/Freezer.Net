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
// Generated by IDLImporter from file nsPICommandUpdater.idl
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
    ///The nsPICommandUpdater interface is used by modules that implement
    ///	commands, to tell the command manager that commands need updating.
    ///	This is a private interface; embedders should not use it.
    ///	
    ///	Command-implementing modules should get one of these by a QI
    ///	from an nsICommandManager. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("B135F602-0BFE-11D5-A73C-F0E420E8293C")]
	internal interface nsPICommandUpdater
	{
		
		/// <summary>
        /// Init the command updater, passing an nsIDOMWindow which
        /// is the window that the command updater lives on.
        ///
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Init([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow);
		
		/// <summary>
        /// Notify the command manager that the status of a command
        /// changed. It may have changed from enabled to disabled,
        /// or vice versa, or become toggled etc.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CommandStatusChanged([MarshalAs(UnmanagedType.LPStr)] string aCommandName);
	}
}
