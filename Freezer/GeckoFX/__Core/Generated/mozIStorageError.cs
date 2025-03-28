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
// Generated by IDLImporter from file mozIStorageError.idl
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
    ///-*- Mode: C++; tab-width: 2; indent-tabs-mode: nil; c-basic-offset: 2 -*-
    /// vim: sw=2 ts=2 sts=2 expandtab
    /// This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("1f350f96-7023-434a-8864-40a1c493aac1")]
	internal interface mozIStorageError
	{
		
		/// <summary>
        /// Indicates what type of error occurred.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetResultAttribute();
		
		/// <summary>
        /// An error string the gives more details, if available.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetMessageAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aMessage);
	}
	
	/// <summary>mozIStorageErrorConsts </summary>
	internal class mozIStorageErrorConsts
	{
		
		// <summary>
        // General SQL error or missing database.
        // </summary>
		public const long ERROR = 1;
		
		// <summary>
        // Internal logic error.
        // </summary>
		public const long INTERNAL = 2;
		
		// <summary>
        // Access permission denied.
        // </summary>
		public const long PERM = 3;
		
		// <summary>
        // A callback routine requested an abort.
        // </summary>
		public const long ABORT = 4;
		
		// <summary>
        // The database file is locked.
        // </summary>
		public const long BUSY = 5;
		
		// <summary>
        // A table in the database is locked.
        // </summary>
		public const long LOCKED = 6;
		
		// <summary>
        // An allocation failed.
        // </summary>
		public const long NOMEM = 7;
		
		// <summary>
        // Attempt to write to a readonly database.
        // </summary>
		public const long READONLY = 8;
		
		// <summary>
        // Operation was terminated by an interrupt.
        // </summary>
		public const long INTERRUPT = 9;
		
		// <summary>
        // Some kind of disk I/O error occurred.
        // </summary>
		public const long IOERR = 10;
		
		// <summary>
        // The database disk image is malformed.
        // </summary>
		public const long CORRUPT = 11;
		
		// <summary>
        // An insertion failed because the database is full.
        // </summary>
		public const long FULL = 13;
		
		// <summary>
        // Unable to open the database file.
        // </summary>
		public const long CANTOPEN = 14;
		
		// <summary>
        // The database is empty.
        // </summary>
		public const long EMPTY = 16;
		
		// <summary>
        // The database scheme changed.
        // </summary>
		public const long SCHEMA = 17;
		
		// <summary>
        // A string or blob exceeds the size limit.
        // </summary>
		public const long TOOBIG = 18;
		
		// <summary>
        // Abort due to a constraint violation.
        // </summary>
		public const long CONSTRAINT = 19;
		
		// <summary>
        // Data type mismatch.
        // </summary>
		public const long MISMATCH = 20;
		
		// <summary>
        // Library used incorrectly.
        // </summary>
		public const long MISUSE = 21;
		
		// <summary>
        // Uses OS features not supported on the host system.
        // </summary>
		public const long NOLFS = 22;
		
		// <summary>
        // Authorization denied.
        // </summary>
		public const long AUTH = 23;
		
		// <summary>
        // Auxiliary database format error.
        // </summary>
		public const long FORMAT = 24;
		
		// <summary>
        // Attempt to bind a parameter using an out-of-range index or nonexistent
        // named parameter name.
        // </summary>
		public const long RANGE = 25;
		
		// <summary>
        // File opened that is not a database file.
        // </summary>
		public const long NOTADB = 26;
	}
}
