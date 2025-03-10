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
// Generated by IDLImporter from file nsIXULTemplateRuleFilter.idl
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
    /// A rule filter may be used to add additional filtering of results to a rule.
    /// The filter is used to further reject results from matching the template's
    /// rules, beyond what the template syntax can do itself, thus allowing for
    /// more complex result filtering. The rule filter is applied after the rule
    /// syntax within the template.
    ///
    /// Only one filter may apply to each rule within the template and may be
    /// assigned using the template builder's addRuleFilter method.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("819cd1ed-8010-42e1-a8b9-778b726a1ff3")]
	internal interface nsIXULTemplateRuleFilter
	{
		
		/// <summary>
        /// Evaluate a result and return true if the result is accepted by this
        /// filter, or false if it is rejected. Accepted results will have output
        /// generated for them for the rule. Rejected results will not, but they
        /// may still match another rule.
        ///
        /// @param aRef the result to examine
        /// @param aRule the rule node
        ///
        /// @return true if the rule matches
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool Match([MarshalAs(UnmanagedType.Interface)] nsIXULTemplateResult aRef, [MarshalAs(UnmanagedType.Interface)] nsIDOMNode aRule);
	}
}
