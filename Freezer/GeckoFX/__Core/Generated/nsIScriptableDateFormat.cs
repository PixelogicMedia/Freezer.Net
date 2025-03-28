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
// Generated by IDLImporter from file nsIScriptableDateFormat.idl
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
    /// Format date and time in a human readable format.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("0c89efb0-1aae-11d3-9141-006008a6edf6")]
	internal interface nsIScriptableDateFormat
	{
		
		/// <summary>
        /// Format the given date and time in a human readable format.
        ///
        /// The underlying operating system is used to format the date and time.
        ///
        /// Pass an empty string as the locale parameter to use the OS settings with
        /// the preferred date and time formatting given by the user.
        ///
        /// Pass a locale code as described in nsILocale as the locale parameter
        /// (e.g. en-US) to use a specific locale. If the given locale is not
        /// available, a fallback will be used.
        ///
        /// NOTE: The output of this method depends on the operating system and user
        /// settings. Even if you pass a locale code as the first parameter, there
        /// are no guarantees about which locale and exact format the returned value
        /// uses. Even if you know the locale, the format might be customized by the
        /// user. Therefore you should not use the returned values in contexts where
        /// you depend on any specific format or language.
        ///
        /// @param locale
        /// Locale code of locale used to format the date or an empty string
        /// to follow user preference.
        /// @param dateFormatSelector
        /// Indicate which format should preferably be used for the date.
        /// Use one of the dateFormat* constants.
        /// @param timeFormatSelector
        /// Indicate which format should preferably be used for the time.
        /// Use one of the timeFormat* constants.
        /// @param year, month, day, hour, minute and second
        /// The date and time to be formatted, given in the computer's local
        /// time zone.
        /// @return The date and time formatted as human readable text according to
        /// user preferences or the given locale.
        /// </summary>
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string FormatDateTime([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string locale, int dateFormatSelector, int timeFormatSelector, int year, int month, int day, int hour, int minute, int second);
		
		/// <summary>
        /// Format the given date in a human readable format.
        ///
        /// See FormatDateTime for details.
        /// </summary>
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string FormatDate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string locale, int dateFormatSelector, int year, int month, int day);
		
		/// <summary>
        /// Format the given time in a human readable format.
        ///
        /// See FormatDateTime for details.
        /// </summary>
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string FormatTime([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string locale, int timeFormatSelector, int hour, int minute, int second);
	}
	
	/// <summary>nsIScriptableDateFormatConsts </summary>
	internal class nsIScriptableDateFormatConsts
	{
		
		// <summary>
        // Do not include the date in the format string.
        // </summary>
		public const long dateFormatNone = 0;
		
		// <summary>
        // Provide the long date format.
        //
        // NOTE:
        // The original definitions of dateFormatLong and dateFormatShort are from
        // the Windows platform.
        // In US English dateFormatLong output will be like:
        // Wednesday, January 29, 2003 4:02:14 PM
        // In US English dateFormatShort output will be like:
        // 1/29/03 4:02:14 PM
        // On platforms like Linux, it is rather difficult to achieve exact
        // same output, and since we are aiming at human readers, it does not make
        // sense to achieve exact same result. We will do just enough as the
        // platform allow us to do.
        // </summary>
		public const long dateFormatLong = 1;
		
		// <summary>
        // Provide the short date format. See also dateFormatLong.
        // </summary>
		public const long dateFormatShort = 2;
		
		// <summary>
        // Format using only the year and month.
        // </summary>
		public const long dateFormatYearMonth = 3;
		
		// <summary>
        // Provide the Week day (e.g. Mo, Mon, Monday or similar).
        // </summary>
		public const long dateFormatWeekday = 4;
		
		// <summary>
        // Don't include the time in the format string.
        // </summary>
		public const long timeFormatNone = 0;
		
		// <summary>
        // Provide the time format with seconds.
        // </summary>
		public const long timeFormatSeconds = 1;
		
		// <summary>
        // Provide the time format without seconds.
        // </summary>
		public const long timeFormatNoSeconds = 2;
		
		// <summary>
        // Provide the time format with seconds, and force the time format to use
        // 24-hour clock, regardless of the locale conventions.
        // </summary>
		public const long timeFormatSecondsForce24Hour = 3;
		
		// <summary>
        // Provide the time format without seconds, and force the time format to use
        // 24-hour clock, regardless of the locale conventions.
        // </summary>
		public const long timeFormatNoSecondsForce24Hour = 4;
	}
}
