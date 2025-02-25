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
// Generated by IDLImporter from file nsISessionStore.idl
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
    /// nsISessionStore keeps track of the current browsing state - i.e.
    /// tab history, cookies, scroll state, form data, and window features
    /// - and allows to restore everything into one browser window.
    ///
    /// The nsISessionStore API operates mostly on browser windows and the tabbrowser
    /// tabs contained in them:
    ///
    /// * "Browser windows" are those DOM windows having loaded
    /// chrome://browser/content/browser.xul . From overlays you can just pass the
    /// global |window| object to the API, though (or |top| from a sidebar).
    /// From elsewhere you can get browser windows through the nsIWindowMediator
    /// by looking for "navigator:browser" windows.
    ///
    /// * "Tabbrowser tabs" are all the child nodes of a browser window's
    /// |gBrowser.tabContainer| such as e.g. |gBrowser.selectedTab|.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("4580f5eb-693d-423d-b0ce-2cb20a962e4d")]
	internal interface nsISessionStore
	{
		
		/// <summary>
        /// Is it possible to restore the previous session. Will always be false when
        /// in Private Browsing mode.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetCanRestoreLastSessionAttribute();
		
		/// <summary>
        /// Is it possible to restore the previous session. Will always be false when
        /// in Private Browsing mode.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetCanRestoreLastSessionAttribute([MarshalAs(UnmanagedType.U1)] bool aCanRestoreLastSession);
		
		/// <summary>
        /// Restore the previous session if possible. This will not overwrite the
        /// current session. Instead the previous session will be merged into the
        /// current session. Current windows will be reused if they were windows that
        /// pinned tabs were previously restored into. New windows will be opened as
        /// needed.
        ///
        /// Note: This will throw if there is no previous state to restore. Check with
        /// canRestoreLastSession first to avoid thrown errors.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RestoreLastSession();
		
		/// <summary>
        /// Get the current browsing state.
        /// @returns a JSON string representing the session state.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetBrowserState([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// Set the browsing state.
        /// This will immediately restore the state of the whole application to the state
        /// passed in, *replacing* the current session.
        ///
        /// @param aState is a JSON string representing the session state.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetBrowserState([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aState);
		
		/// <summary>
        /// @param aWindow is the browser window whose state is to be returned.
        ///
        /// @returns a JSON string representing a session state with only one window.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetWindowState([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aWindow    is the browser window whose state is to be set.
        /// @param aState     is a JSON string representing a session state.
        /// @param aOverwrite boolean overwrite existing tabs
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetWindowState([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aState, [MarshalAs(UnmanagedType.U1)] bool aOverwrite);
		
		/// <summary>
        /// @param aTab is the tabbrowser tab whose state is to be returned.
        ///
        /// @returns a JSON string representing the state of the tab
        /// (note: doesn't contain cookies - if you need them, use getWindowState instead).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetTabState([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aTab, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aTab   is the tabbrowser tab whose state is to be set.
        /// @param aState is a JSON string representing a session state.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetTabState([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aTab, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aState);
		
		/// <summary>
        /// Duplicates a given tab as thoroughly as possible.
        ///
        /// @param aWindow is the browser window into which the tab will be duplicated.
        /// @param aTab    is the tabbrowser tab to duplicate (can be from a different window).
        /// @param aDelta  is the offset to the history entry to load in the duplicated tab.
        /// @returns a reference to the newly created tab.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMNode DuplicateTab([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.Interface)] nsIDOMNode aTab, int aDelta);
		
		/// <summary>
        /// Get the number of restore-able tabs for a browser window
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetClosedTabCount([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow);
		
		/// <summary>
        /// Get closed tab data
        ///
        /// @param aWindow is the browser window for which to get closed tab data
        /// @returns a JSON string representing the list of closed tabs.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetClosedTabData([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aWindow is the browser window to reopen a closed tab in.
        /// @param aIndex  is the index of the tab to be restored (FIFO ordered).
        /// @returns a reference to the reopened tab.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMNode UndoCloseTab([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, uint aIndex);
		
		/// <summary>
        /// @param aWindow is the browser window associated with the closed tab.
        /// @param aIndex  is the index of the closed tab to be removed (FIFO ordered).
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMNode ForgetClosedTab([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, uint aIndex);
		
		/// <summary>
        /// Get the number of restore-able windows
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetClosedWindowCount();
		
		/// <summary>
        /// Get closed windows data
        ///
        /// @returns a JSON string representing the list of closed windows.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetClosedWindowData([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aIndex is the index of the windows to be restored (FIFO ordered).
        /// @returns the nsIDOMWindow object of the reopened window
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMWindow UndoCloseWindow(uint aIndex);
		
		/// <summary>
        /// @param aIndex  is the index of the closed window to be removed (FIFO ordered).
        ///
        /// @throws NS_ERROR_INVALID_ARG
        /// when aIndex does not map to a closed window
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMNode ForgetClosedWindow(uint aIndex);
		
		/// <summary>
        /// @param aWindow is the window to get the value for.
        /// @param aKey    is the value's name.
        ///
        /// @returns A string value or an empty string if none is set.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetWindowValue([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aWindow      is the browser window to set the value for.
        /// @param aKey         is the value's name.
        /// @param aStringValue is the value itself (use JSON.stringify/parse before setting JS objects).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetWindowValue([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey, ref Gecko.JsVal aStringValue);
		
		/// <summary>
        /// @param aWindow is the browser window to get the value for.
        /// @param aKey    is the value's name.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DeleteWindowValue([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow aWindow, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey);
		
		/// <summary>
        /// @param aTab is the tabbrowser tab to get the value for.
        /// @param aKey is the value's name.
        ///
        /// @returns A string value or an empty string if none is set.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetTabValue([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aTab, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aTab         is the tabbrowser tab to set the value for.
        /// @param aKey         is the value's name.
        /// @param aStringValue is the value itself (use JSON.stringify/parse before setting JS objects).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetTabValue([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aTab, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey, ref Gecko.JsVal aStringValue);
		
		/// <summary>
        /// @param aTab is the tabbrowser tab to get the value for.
        /// @param aKey is the value's name.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DeleteTabValue([MarshalAs(UnmanagedType.Interface)] nsIDOMNode aTab, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey);
		
		/// <summary>
        /// @param aKey is the value's name.
        ///
        /// @returns A string value or an empty string if none is set.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetGlobalValue([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// @param aKey         is the value's name.
        /// @param aStringValue is the value itself (use JSON.stringify/parse before setting JS objects).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetGlobalValue([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey, ref Gecko.JsVal aStringValue);
		
		/// <summary>
        /// @param aTab is the browser tab to get the value for.
        /// @param aKey is the value's name.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void DeleteGlobalValue([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aKey);
		
		/// <summary>
        /// @param aName is the name of the attribute to save/restore for all tabbrowser tabs.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void PersistTabAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aName);
	}
}
