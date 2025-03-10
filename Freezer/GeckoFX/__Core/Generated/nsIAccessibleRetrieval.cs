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
// Generated by IDLImporter from file nsIAccessibleRetrieval.idl
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
    /// An interface for in-process accessibility clients wishing to get an
    /// nsIAccessible for a given DOM node.  More documentation at:
    /// http://www.mozilla.org/projects/ui/accessibility
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("17f86615-1a3d-4021-b227-3a2ef5cbffd8")]
	internal interface nsIAccessibleRetrieval
	{
		
		/// <summary>
        /// Return application accessible.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessible GetApplicationAccessible();
		
		/// <summary>
        /// Return an nsIAccessible for a DOM node in pres shell 0.
        /// Create a new accessible of the appropriate type if necessary,
        /// or use one from the accessibility cache if it already exists.
        /// @param aNode The DOM node to get an accessible for.
        /// @return The nsIAccessible for the given DOM node.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessible GetAccessibleFor([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aNode);
		
		/// <summary>
        /// Returns accessible role as a string.
        ///
        /// @param aRole - the accessible role constants.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetStringRole(uint aRole, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// Returns list which contains accessible states as a strings.
        ///
        /// @param aStates - accessible states.
        /// @param aExtraStates - accessible extra states.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsISupports GetStringStates(uint aStates, uint aExtraStates);
		
		/// <summary>
        /// Get the type of accessible event as a string.
        ///
        /// @param aEventType - the accessible event type constant
        /// @return - accessible event type presented as human readable string
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetStringEventType(uint aEventType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// Get the type of accessible relation as a string.
        ///
        /// @param aRelationType - the accessible relation type constant
        /// @return - accessible relation type presented as human readable string
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetStringRelationType(uint aRelationType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// Return an accessible for the given DOM node from the cache.
        /// @note  the method is intended for testing purposes
        ///
        /// @param aNode  [in] the DOM node to get an accessible for
        ///
        /// @return       cached accessible for the given DOM node if any
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessible GetAccessibleFromCache([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aNode);
		
		/// <summary>
        /// Create a new pivot for tracking a position and traversing a subtree.
        ///
        /// @param aRoot [in] the accessible root for the pivot
        /// @return a new pivot
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessiblePivot CreateAccessiblePivot([MarshalAs(UnmanagedType.Interface)] nsIAccessible aRoot);
		
		/// <summary>
        /// Enable logging for the given modules, all other modules aren't logged.
        ///
        /// @param aModules [in] list of modules, format is comma separated list
        /// like 'docload,doccreate'.
        /// @note Works on debug build only.
        /// @see Logging.cpp for list of possible values.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetLogging([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aModules);
		
		/// <summary>
        /// Return true if the given module is logged.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsLogged([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aModule);
	}
}
