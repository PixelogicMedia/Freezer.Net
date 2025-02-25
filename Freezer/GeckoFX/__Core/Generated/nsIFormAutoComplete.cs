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
// Generated by IDLImporter from file nsIFormAutoComplete.idl
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
	[Guid("bfd9b82b-0ab3-4b6b-9e54-aa961ff4b732")]
	internal interface nsIFormAutoComplete
	{
		
		/// <summary>
        /// Generate results for a form input autocomplete menu asynchronously.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AutoCompleteSearchAsync([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aInputName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aSearchString, [MarshalAs(UnmanagedType.Interface)] nsIDOMHTMLInputElement aField, [MarshalAs(UnmanagedType.Interface)] nsIAutoCompleteResult aPreviousResult, [MarshalAs(UnmanagedType.Interface)] nsIAutoCompleteResult aDatalistResult, [MarshalAs(UnmanagedType.Interface)] nsIFormAutoCompleteObserver aListener);
		
		/// <summary>
        /// If a search is in progress, stop it. Otherwise, do nothing. This is used
        /// to cancel an existing search, for example, in preparation for a new search.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void StopAutoCompleteSearch();
	}
	
	/// <summary>nsIFormAutoCompleteObserver </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("604419ab-55a0-4831-9eca-1b9e67cc4751")]
	internal interface nsIFormAutoCompleteObserver
	{
		
		/// <summary>
        /// Called when a search is complete and the results are ready even if the
        /// result set is empty. If the search is cancelled or a new search is
        /// started, this is not called.
        ///
        /// @param result - The search result object
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnSearchCompletion([MarshalAs(UnmanagedType.Interface)] nsIAutoCompleteResult result);
	}
}
