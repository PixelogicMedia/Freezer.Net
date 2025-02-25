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
// Generated by IDLImporter from file nsIIconURI.idl
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
    /// nsIIconURI
    ///
    /// This interface derives from nsIURI, to provide additional information
    /// about moz-icon URIs.
    ///
    /// What *is* a moz-icon URI you ask?  Well, it has the following syntax:
    ///
    /// moz-icon:[<valid-url> | //<file-with-extension> | //stock/<stock-icon>]?
    /// ['?'[<parameter-value-pairs>]]
    ///
    /// <valid-url> is a valid URL spec.
    ///
    /// <file-with-extension> is any filename with an extension, e.g. "dummy.html".
    /// If the file you want an icon for isn't known to exist, you can use this
    /// instead of a URL and just place a dummy file name with the extension or
    /// content type you want.
    ///
    /// <stock-icon> is the name of a platform-dependant stock icon.
    ///
    /// Legal parameter value pairs are listed below:
    ///
    /// Parameter:   size
    /// Values:      [<integer> | button | toolbar | toolbarsmall | menu |
    /// dialog]
    /// Description: If integer, this is the desired size in square pixels of
    /// the icon
    /// Else, use the OS default for the specified keyword context.
    ///
    /// Parameter:   state
    /// Values:      [normal | disabled]
    /// Description: The state of the icon.
    ///
    /// Parameter:   contentType
    /// Values:      <mime-type>
    /// Description: The mime type we want an icon for. This is ignored by
    /// stock images.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("f8fe5ef2-5f2b-43f3-857d-5b64d192c427")]
	internal interface nsIMozIconURI : nsIURI
	{
		
		/// <summary>
        /// Returns a string representation of the URI. Setting the spec causes
        /// the new spec to be parsed per the rules for the scheme the URI
        /// currently has.  In particular, setting the spec to a URI string with a
        /// different scheme will generally produce incorrect results; no one
        /// outside of a protocol handler implementation should be doing that.  If
        /// the URI stores information from the nsIIOService.newURI call used to
        /// create it other than just the parsed string, then behavior of this
        /// information on setting the spec attribute is undefined.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetSpecAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSpec);
		
		/// <summary>
        /// Returns a string representation of the URI. Setting the spec causes
        /// the new spec to be parsed per the rules for the scheme the URI
        /// currently has.  In particular, setting the spec to a URI string with a
        /// different scheme will generally produce incorrect results; no one
        /// outside of a protocol handler implementation should be doing that.  If
        /// the URI stores information from the nsIIOService.newURI call used to
        /// create it other than just the parsed string, then behavior of this
        /// information on setting the spec attribute is undefined.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetSpecAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSpec);
		
		/// <summary>
        /// The prePath (eg. scheme://user:password@host:port) returns the string
        /// before the path.  This is useful for authentication or managing sessions.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetPrePathAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aPrePath);
		
		/// <summary>
        /// The Scheme is the protocol to which this URI refers.  The scheme is
        /// restricted to the US-ASCII charset per RFC2396.  Setting this is
        /// highly discouraged outside of a protocol handler implementation, since
        /// that will generally lead to incorrect results.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetSchemeAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aScheme);
		
		/// <summary>
        /// The Scheme is the protocol to which this URI refers.  The scheme is
        /// restricted to the US-ASCII charset per RFC2396.  Setting this is
        /// highly discouraged outside of a protocol handler implementation, since
        /// that will generally lead to incorrect results.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetSchemeAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aScheme);
		
		/// <summary>
        /// The username:password (or username only if value doesn't contain a ':')
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetUserPassAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aUserPass);
		
		/// <summary>
        /// The username:password (or username only if value doesn't contain a ':')
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetUserPassAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aUserPass);
		
		/// <summary>
        /// The optional username and password, assuming the preHost consists of
        /// username:password.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetUsernameAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aUsername);
		
		/// <summary>
        /// The optional username and password, assuming the preHost consists of
        /// username:password.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetUsernameAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aUsername);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetPasswordAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aPassword);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetPasswordAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aPassword);
		
		/// <summary>
        /// The host:port (or simply the host, if port == -1).
        ///
        /// Characters are NOT escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetHostPortAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aHostPort);
		
		/// <summary>
        /// The host:port (or simply the host, if port == -1).
        ///
        /// Characters are NOT escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetHostPortAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aHostPort);
		
		/// <summary>
        /// The host is the internet domain name to which this URI refers.  It could
        /// be an IPv4 (or IPv6) address literal.  If supported, it could be a
        /// non-ASCII internationalized domain name.
        ///
        /// Characters are NOT escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetHostAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aHost);
		
		/// <summary>
        /// The host is the internet domain name to which this URI refers.  It could
        /// be an IPv4 (or IPv6) address literal.  If supported, it could be a
        /// non-ASCII internationalized domain name.
        ///
        /// Characters are NOT escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetHostAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aHost);
		
		/// <summary>
        /// A port value of -1 corresponds to the protocol's default port (eg. -1
        /// implies port 80 for http URIs).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new int GetPortAttribute();
		
		/// <summary>
        /// A port value of -1 corresponds to the protocol's default port (eg. -1
        /// implies port 80 for http URIs).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetPortAttribute(int aPort);
		
		/// <summary>
        /// The path, typically including at least a leading '/' (but may also be
        /// empty, depending on the protocol).
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetPathAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aPath);
		
		/// <summary>
        /// The path, typically including at least a leading '/' (but may also be
        /// empty, depending on the protocol).
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetPathAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aPath);
		
		/// <summary>
        /// URI equivalence test (not a strict string comparison).
        ///
        /// eg. http://foo.com:80/ == http://foo.com/
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool Equals([MarshalAs(UnmanagedType.Interface)] nsIURI other);
		
		/// <summary>
        /// An optimization to do scheme checks without requiring the users of nsIURI
        /// to GetScheme, thereby saving extra allocating and freeing. Returns true if
        /// the schemes match (case ignored).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool SchemeIs([MarshalAs(UnmanagedType.LPStr)] string scheme);
		
		/// <summary>
        /// Clones the current URI.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIURI Clone();
		
		/// <summary>
        /// This method resolves a relative string into an absolute URI string,
        /// using this URI as the base.
        ///
        /// NOTE: some implementations may have no concept of a relative URI.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Resolve([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase relativePath, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase retval);
		
		/// <summary>
        /// The URI spec with an ASCII compatible encoding.  Host portion follows
        /// the IDNA draft spec.  Other parts are URL-escaped per the rules of
        /// RFC2396.  The result is strictly ASCII.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetAsciiSpecAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aAsciiSpec);
		
		/// <summary>
        /// The host:port (or simply the host, if port == -1), with an ASCII compatible
        /// encoding.  Host portion follows the IDNA draft spec.  The result is strictly
        /// ASCII.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetAsciiHostPortAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aAsciiHostPort);
		
		/// <summary>
        /// The URI host with an ASCII compatible encoding.  Follows the IDNA
        /// draft spec for converting internationalized domain names (UTF-8) to
        /// ASCII for compatibility with existing internet infrasture.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetAsciiHostAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aAsciiHost);
		
		/// <summary>
        /// The charset of the document from which this URI originated.  An empty
        /// value implies UTF-8.
        ///
        /// If this value is something other than UTF-8 then the URI components
        /// (e.g., spec, prePath, username, etc.) will all be fully URL-escaped.
        /// Otherwise, the URI components may contain unescaped multibyte UTF-8
        /// characters.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetOriginCharsetAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aOriginCharset);
		
		/// <summary>
        /// Returns the reference portion (the part after the "#") of the URI.
        /// If there isn't one, an empty string is returned.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetRefAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aRef);
		
		/// <summary>
        /// Returns the reference portion (the part after the "#") of the URI.
        /// If there isn't one, an empty string is returned.
        ///
        /// Some characters may be escaped.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetRefAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aRef);
		
		/// <summary>
        /// URI equivalence test (not a strict string comparison), ignoring
        /// the value of the .ref member.
        ///
        /// eg. http://foo.com/# == http://foo.com/
        /// http://foo.com/#aaa == http://foo.com/#bbb
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool EqualsExceptRef([MarshalAs(UnmanagedType.Interface)] nsIURI other);
		
		/// <summary>
        /// Clones the current URI, clearing the 'ref' attribute in the clone.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIURI CloneIgnoringRef();
		
		/// <summary>
        /// returns a string for the current URI with the ref element cleared.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetSpecIgnoringRefAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aSpecIgnoringRef);
		
		/// <summary>
        /// Returns if there is a reference portion (the part after the "#") of the URI.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool GetHasRefAttribute();
		
		/// <summary>
        /// iconFile: the file URL contained within this moz-icon url, or null.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURL GetIconURLAttribute();
		
		/// <summary>
        /// iconFile: the file URL contained within this moz-icon url, or null.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetIconURLAttribute([MarshalAs(UnmanagedType.Interface)] nsIURL aIconURL);
		
		/// <summary>
        /// imageSize: The image area in square pixels, defaults to 16 if unspecified.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetImageSizeAttribute();
		
		/// <summary>
        /// imageSize: The image area in square pixels, defaults to 16 if unspecified.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetImageSizeAttribute(uint aImageSize);
		
		/// <summary>
        /// stockIcon: The stock icon name requested from the OS.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetStockIconAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aStockIcon);
		
		/// <summary>
        /// iconSize: The stock icon size requested from the OS.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetIconSizeAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aIconSize);
		
		/// <summary>
        /// iconState: The stock icon state requested from the OS.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetIconStateAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aIconState);
		
		/// <summary>
        /// contentType: A valid mime type, or the empty string.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetContentTypeAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aContentType);
		
		/// <summary>
        /// contentType: A valid mime type, or the empty string.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetContentTypeAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aContentType);
		
		/// <summary>
        /// fileExtension: The file extension of the file which we are looking up.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetFileExtensionAttribute([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aFileExtension);
	}
}
