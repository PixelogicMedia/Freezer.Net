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
// Generated by IDLImporter from file mozIStorageVacuumParticipant.idl
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
    /// This interface contains the information that the Storage service needs to
    /// vacuum a database.  This interface is created as a service through the
    /// category manager with the category "vacuum-participant".
    /// Please see https://developer.mozilla.org/en/mozIStorageVacuumParticipant for
    /// more information.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("8f367508-1d9a-4d3f-be0c-ac11b6dd7dbf")]
	internal interface mozIStorageVacuumParticipant
	{
		
		/// <summary>
        /// The expected page size in bytes for the database.  The vacuum manager will
        /// try to correct the page size during idle based on this value.
        ///
        /// @note If the database is using the WAL journal mode, the page size won't
        /// be changed to the requested value.  See bug 634374.
        /// @note Valid page size values are powers of 2 between 512 and 65536.
        /// The suggested value is mozIStorageConnection::defaultPageSize.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetExpectedDatabasePageSizeAttribute();
		
		/// <summary>
        /// Connection to the database file to be vacuumed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		mozIStorageConnection GetDatabaseConnectionAttribute();
		
		/// <summary>
        /// Notifies when a vacuum operation begins.  Listeners should avoid using the
        /// database till onEndVacuum is received.
        ///
        /// @return true to proceed with the vacuum, false if the participant wants to
        /// opt-out for now, it will be retried later.  Useful when participant
        /// is running some other heavy operation that can't be interrupted.
        ///
        /// @note When a vacuum operation starts or ends it will also dispatch a global
        /// "heavy-io-task" notification through the observer service with the
        /// data argument being either "vacuum-begin" or "vacuum-end".
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool OnBeginVacuum();
		
		/// <summary>
        /// Notifies when a vacuum operation ends.
        ///
        /// @param aSucceeded
        /// reports if the vacuum succeeded or failed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnEndVacuum([MarshalAs(UnmanagedType.U1)] bool aSucceeded);
	}
}
