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
// Generated by IDLImporter from file nsIContentSecurityPolicy.idl
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
    /// nsIContentSecurityPolicy
    /// Describes an XPCOM component used to model and enforce CSPs.  Instances of
    /// this class may have multiple policies within them, but there should only be
    /// one of these per document/principal.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b3c4c0ae-bd5e-4cad-87e0-8d210dbb3f9f")]
	internal interface nsIContentSecurityPolicy : nsISerializable
	{
		
		/// <summary>
        /// Initialize the object implementing nsISerializable, which must have
        /// been freshly constructed via CreateInstance.  All data members that
        /// can't be set to default values must have been serialized by write,
        /// and should be read from aInputStream in the same order by this method.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Read([MarshalAs(UnmanagedType.Interface)] nsIObjectInputStream aInputStream);
		
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
		new void Write([MarshalAs(UnmanagedType.Interface)] nsIObjectOutputStream aOutputStream);
		
		/// <summary>
        /// Accessor method for a read-only string version of the policy at a given
        /// index.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetPolicy(uint index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
		
		/// <summary>
        /// Returns the number of policies attached to this CSP instance.  Useful with
        /// getPolicy().
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetPolicyCountAttribute();
		
		/// <summary>
        /// Returns whether this policy uses the directive upgrade-insecure-requests.
        /// Please note that upgrade-insecure-reqeusts also applies if the parent or
        /// including document (context) makes use of the directive.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetUpgradeInsecureRequestsAttribute();
		
		/// <summary>
        /// Obtains the referrer policy (as integer) for this browsing context as
        /// specified in CSP.  If there are multiple policies and...
        /// - only one sets a referrer policy: that policy is returned
        /// - more than one sets different referrer policies: no-referrer is returned
        /// - more than one set equivalent policies: that policy is returned
        /// For the enumeration of policies see ReferrerPolicy.h and nsIHttpChannel.
        ///
        /// @param aPolicy
        /// The referrer policy to use for the protected resource.
        /// @return
        /// true if a referrer policy is specified, false if it's unspecified.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetReferrerPolicy(ref uint policy);
		
		/// <summary>
        /// Parse and install a CSP policy.
        /// @param aPolicy
        /// String representation of the policy
        /// (e.g., header value, meta content)
        /// @param reportOnly
        /// Should this policy affect content, script and style processing or
        /// just send reports if it is violated?
        /// @param deliveredViaMetaTag
        /// Indicates whether the policy was delivered via the meta tag.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AppendPolicy([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase policyString, [MarshalAs(UnmanagedType.U1)] bool reportOnly, [MarshalAs(UnmanagedType.U1)] bool deliveredViaMetaTag);
		
		/// <summary>
        /// Whether this policy allows inline script or style.
        /// @param aContentPolicyType Either TYPE_SCRIPT or TYPE_STYLESHEET
        /// @param aNonce The nonce string to check against the policy
        /// @param aContent  The content of the inline resource to hash
        /// (and compare to the hashes listed in the policy)
        /// @param aLineNumber The line number of the inline resource
        /// (used for reporting)
        /// @return
        /// Whether or not the effects of the inline style should be allowed
        /// (block the rules if false).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetAllowsInline(System.IntPtr aContentPolicyType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aNonce, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aContent, uint aLineNumber);
		
		/// <summary>
        /// whether this policy allows eval and eval-like functions
        /// such as setTimeout("code string", time).
        /// @param shouldReportViolations
        /// Whether or not the use of eval should be reported.
        /// This function returns "true" when violating report-only policies, but
        /// when any policy (report-only or otherwise) is violated,
        /// shouldReportViolations is true as well.
        /// @return
        /// Whether or not the effects of the eval call should be allowed
        /// (block the call if false).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetAllowsEval([MarshalAs(UnmanagedType.U1)] ref bool shouldReportViolations);
		
		/// <summary>
        /// For each violated policy (of type violationType), log policy violation on
        /// the Error Console and send a report to report-uris present in the violated
        /// policies.
        ///
        /// @param violationType
        /// one of the VIOLATION_TYPE_* constants, e.g. inline-script or eval
        /// @param sourceFile
        /// name of the source file containing the violation (if available)
        /// @param contentSample
        /// sample of the violating content (to aid debugging)
        /// @param lineNum
        /// source line number of the violation (if available)
        /// @param aNonce
        /// (optional) If this is a nonce violation, include the nonce so we can
        /// recheck to determine which policies were violated and send the
        /// appropriate reports.
        /// @param aContent
        /// (optional) If this is a hash violation, include contents of the inline
        /// resource in the question so we can recheck the hash in order to
        /// determine which policies were violated and send the appropriate
        /// reports.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void LogViolationDetails(ushort violationType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase sourceFile, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase scriptSample, int lineNum, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase nonce, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase content);
		
		/// <summary>
        /// Called after the CSP object is created to fill in appropriate request
        /// context. Either use
        /// * aDocument (preferred), or if no document is available, then provide
        /// * aPrincipal
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetRequestContext([MarshalAs(UnmanagedType.Interface)] nsIDOMDocument aDocument, [MarshalAs(UnmanagedType.Interface)] nsIPrincipal aPrincipal);
		
		/// <summary>
        /// Verifies ancestry as permitted by the policy.
        ///
        /// NOTE: Calls to this may trigger violation reports when queried, so this
        /// value should not be cached.
        ///
        /// @param docShell
        /// containing the protected resource
        /// @return
        /// true if the frame's ancestors are all allowed by policy (except for
        /// report-only policies, which will send reports and then return true
        /// here when violated).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool PermitsAncestry([MarshalAs(UnmanagedType.Interface)] nsIDocShell docShell);
		
		/// <summary>
        /// Checks if a specific directive permits loading of a URI.
        ///
        /// NOTE: Calls to this may trigger violation reports when queried, so the
        /// return value should not be cached.
        ///
        /// @param aURI
        /// The URI about to be loaded or used.
        /// @param aDir
        /// The CSPDirective to query (see above constants *_DIRECTIVE).
        /// @param aSpecific
        /// If "true" and the directive is specified to fall back to "default-src"
        /// when it's not explicitly provided, directivePermits will NOT try
        /// default-src when the specific directive is not used.  Setting this to
        /// "false" allows CSP to fall back to default-src.  This function
        /// behaves the same for both values of canUseDefault when querying
        /// directives that don't fall-back.
        /// @return
        /// Whether or not the provided URI is allowed by CSP under the given
        /// directive. (block the pending operation if false).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool Permits([MarshalAs(UnmanagedType.Interface)] nsIURI aURI, System.IntPtr aDir, [MarshalAs(UnmanagedType.U1)] bool aSpecific);
		
		/// <summary>
        /// Delegate method called by the service when sub-elements of the protected
        /// document are being loaded.  Given a bit of information about the request,
        /// decides whether or not the policy is satisfied.
        ///
        /// Calls to this may trigger violation reports when queried, so
        /// this value should not be cached.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		short ShouldLoad(System.IntPtr aContentType, [MarshalAs(UnmanagedType.Interface)] nsIURI aContentLocation, [MarshalAs(UnmanagedType.Interface)] nsIURI aRequestOrigin, [MarshalAs(UnmanagedType.Interface)] nsISupports aContext, [MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aMimeTypeGuess, [MarshalAs(UnmanagedType.Interface)] nsISupports aExtra);
		
		/// <summary>
        /// Returns the CSP in JSON notation.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ToJSON([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase retval);
	}
	
	/// <summary>nsIContentSecurityPolicyConsts </summary>
	internal class nsIContentSecurityPolicyConsts
	{
		
		// <summary>
        // Directives supported by Content Security Policy.  These are enums for
        // the CSPDirective type.
        // The NO_DIRECTIVE entry is  used for checking default permissions and
        // returning failure when asking CSP which directive to check.
        //
        // NOTE: When implementing a new directive, you will need to add it here but also
        // add it to the CSPStrDirectives array in nsCSPUtils.h.
        // </summary>
		public const ushort NO_DIRECTIVE = 0;
		
		// 
		public const ushort DEFAULT_SRC_DIRECTIVE = 1;
		
		// 
		public const ushort SCRIPT_SRC_DIRECTIVE = 2;
		
		// 
		public const ushort OBJECT_SRC_DIRECTIVE = 3;
		
		// 
		public const ushort STYLE_SRC_DIRECTIVE = 4;
		
		// 
		public const ushort IMG_SRC_DIRECTIVE = 5;
		
		// 
		public const ushort MEDIA_SRC_DIRECTIVE = 6;
		
		// 
		public const ushort FRAME_SRC_DIRECTIVE = 7;
		
		// 
		public const ushort FONT_SRC_DIRECTIVE = 8;
		
		// 
		public const ushort CONNECT_SRC_DIRECTIVE = 9;
		
		// 
		public const ushort REPORT_URI_DIRECTIVE = 10;
		
		// 
		public const ushort FRAME_ANCESTORS_DIRECTIVE = 11;
		
		// 
		public const ushort REFLECTED_XSS_DIRECTIVE = 12;
		
		// 
		public const ushort BASE_URI_DIRECTIVE = 13;
		
		// 
		public const ushort FORM_ACTION_DIRECTIVE = 14;
		
		// 
		public const ushort REFERRER_DIRECTIVE = 15;
		
		// 
		public const ushort WEB_MANIFEST_SRC_DIRECTIVE = 16;
		
		// 
		public const ushort UPGRADE_IF_INSECURE_DIRECTIVE = 17;
		
		// 
		public const ushort CHILD_SRC_DIRECTIVE = 18;
		
		// 
		public const ushort VIOLATION_TYPE_INLINE_SCRIPT = 1;
		
		// 
		public const ushort VIOLATION_TYPE_EVAL = 2;
		
		// 
		public const ushort VIOLATION_TYPE_INLINE_STYLE = 3;
		
		// 
		public const ushort VIOLATION_TYPE_NONCE_SCRIPT = 4;
		
		// 
		public const ushort VIOLATION_TYPE_NONCE_STYLE = 5;
		
		// 
		public const ushort VIOLATION_TYPE_HASH_SCRIPT = 6;
		
		// 
		public const ushort VIOLATION_TYPE_HASH_STYLE = 7;
	}
}
