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
// Generated by IDLImporter from file nsIFeed.idl
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
    /// An nsIFeed represents a single Atom or RSS feed.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3b8aae33-80e2-4efa-99c8-a6c5b99f76ea")]
	internal interface nsIFeed : nsIFeedContainer
	{
		
		/// <summary>
        /// The attributes found on the element. Most interfaces provide convenience
        /// accessors for their standard fields, so this useful only when looking for
        /// an extension.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsISAXAttributes GetAttributesAttribute();
		
		/// <summary>
        /// The attributes found on the element. Most interfaces provide convenience
        /// accessors for their standard fields, so this useful only when looking for
        /// an extension.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetAttributesAttribute([MarshalAs(UnmanagedType.Interface)] nsISAXAttributes aAttributes);
		
		/// <summary>
        /// The baseURI for the Entry or Feed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIURI GetBaseURIAttribute();
		
		/// <summary>
        /// The baseURI for the Entry or Feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetBaseURIAttribute([MarshalAs(UnmanagedType.Interface)] nsIURI aBaseURI);
		
		/// <summary>
        /// Many feeds contain an ID distinct from their URI, and
        /// entries have standard fields for this in all major formats.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetIdAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aId);
		
		/// <summary>
        /// Many feeds contain an ID distinct from their URI, and
        /// entries have standard fields for this in all major formats.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetIdAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aId);
		
		/// <summary>
        /// The fields found in the document. Common Atom
        /// and RSS fields are normalized. This includes some namespaced
        /// extensions such as dc:subject and content:encoded.
        /// Consumers can avoid normalization by checking the feed type
        /// and accessing specific fields.
        ///
        /// Common namespaces are accessed using prefixes, like get("dc:subject");.
        /// See nsIFeedResult::registerExtensionPrefix.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIWritablePropertyBag2 GetFieldsAttribute();
		
		/// <summary>
        /// The fields found in the document. Common Atom
        /// and RSS fields are normalized. This includes some namespaced
        /// extensions such as dc:subject and content:encoded.
        /// Consumers can avoid normalization by checking the feed type
        /// and accessing specific fields.
        ///
        /// Common namespaces are accessed using prefixes, like get("dc:subject");.
        /// See nsIFeedResult::registerExtensionPrefix.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetFieldsAttribute([MarshalAs(UnmanagedType.Interface)] nsIWritablePropertyBag2 aFields);
		
		/// <summary>
        /// Sometimes there's no title, or the title contains markup, so take
        /// care in decoding the attribute.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIFeedTextConstruct GetTitleAttribute();
		
		/// <summary>
        /// Sometimes there's no title, or the title contains markup, so take
        /// care in decoding the attribute.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetTitleAttribute([MarshalAs(UnmanagedType.Interface)] nsIFeedTextConstruct aTitle);
		
		/// <summary>
        /// Returns the primary link for the feed or entry.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIURI GetLinkAttribute();
		
		/// <summary>
        /// Returns the primary link for the feed or entry.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetLinkAttribute([MarshalAs(UnmanagedType.Interface)] nsIURI aLink);
		
		/// <summary>
        /// Returns all links for a feed or entry.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIArray GetLinksAttribute();
		
		/// <summary>
        /// Returns all links for a feed or entry.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetLinksAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aLinks);
		
		/// <summary>
        /// Returns the categories found in a feed or entry.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIArray GetCategoriesAttribute();
		
		/// <summary>
        /// Returns the categories found in a feed or entry.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetCategoriesAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aCategories);
		
		/// <summary>
        /// The rights or license associated with a feed or entry.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIFeedTextConstruct GetRightsAttribute();
		
		/// <summary>
        /// The rights or license associated with a feed or entry.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetRightsAttribute([MarshalAs(UnmanagedType.Interface)] nsIFeedTextConstruct aRights);
		
		/// <summary>
        /// A list of nsIFeedPersons that authored the feed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIArray GetAuthorsAttribute();
		
		/// <summary>
        /// A list of nsIFeedPersons that authored the feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetAuthorsAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aAuthors);
		
		/// <summary>
        /// A list of nsIFeedPersons that contributed to the feed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsIArray GetContributorsAttribute();
		
		/// <summary>
        /// A list of nsIFeedPersons that contributed to the feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetContributorsAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aContributors);
		
		/// <summary>
        /// The date the feed was updated, in RFC822 form. Parsable by JS
        /// and mail code.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetUpdatedAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aUpdated);
		
		/// <summary>
        /// The date the feed was updated, in RFC822 form. Parsable by JS
        /// and mail code.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetUpdatedAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aUpdated);
		
		/// <summary>
        /// Syncs a container's fields with its convenience attributes.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Normalize();
		
		/// <summary>
        /// Uses description, subtitle, and extensions
        /// to generate a summary.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIFeedTextConstruct GetSubtitleAttribute();
		
		/// <summary>
        /// Uses description, subtitle, and extensions
        /// to generate a summary.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetSubtitleAttribute([MarshalAs(UnmanagedType.Interface)] nsIFeedTextConstruct aSubtitle);
		
		/// <summary>
        /// The type of feed. For example, a podcast would be TYPE_AUDIO.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetTypeAttribute();
		
		/// <summary>
        /// The total number of enclosures found in the feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetEnclosureCountAttribute();
		
		/// <summary>
        /// The total number of enclosures found in the feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetEnclosureCountAttribute(int aEnclosureCount);
		
		/// <summary>
        /// The items or entries in feed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIArray GetItemsAttribute();
		
		/// <summary>
        /// The items or entries in feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetItemsAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aItems);
		
		/// <summary>
        /// No one really knows what cloud is for.
        ///
        /// It supposedly enables some sort of interaction with an XML-RPC or
        /// SOAP service.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIWritablePropertyBag2 GetCloudAttribute();
		
		/// <summary>
        /// No one really knows what cloud is for.
        ///
        /// It supposedly enables some sort of interaction with an XML-RPC or
        /// SOAP service.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetCloudAttribute([MarshalAs(UnmanagedType.Interface)] nsIWritablePropertyBag2 aCloud);
		
		/// <summary>
        /// Information about the software that produced the feed.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIFeedGenerator GetGeneratorAttribute();
		
		/// <summary>
        /// Information about the software that produced the feed.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetGeneratorAttribute([MarshalAs(UnmanagedType.Interface)] nsIFeedGenerator aGenerator);
		
		/// <summary>
        /// An image url and some metadata (as defined by RSS2).
        ///
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIWritablePropertyBag2 GetImageAttribute();
		
		/// <summary>
        /// An image url and some metadata (as defined by RSS2).
        ///
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetImageAttribute([MarshalAs(UnmanagedType.Interface)] nsIWritablePropertyBag2 aImage);
		
		/// <summary>
        /// No one really knows what textInput is for.
        ///
        /// See
        /// <http://www.cadenhead.org/workbench/news/2894/rss-joy-textinput>
        /// for more details.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIWritablePropertyBag2 GetTextInputAttribute();
		
		/// <summary>
        /// No one really knows what textInput is for.
        ///
        /// See
        /// <http://www.cadenhead.org/workbench/news/2894/rss-joy-textinput>
        /// for more details.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetTextInputAttribute([MarshalAs(UnmanagedType.Interface)] nsIWritablePropertyBag2 aTextInput);
		
		/// <summary>
        /// Days to skip fetching. This field was supposed to designate
        /// intervals for feed fetching. It's not generally implemented. For
        /// example, if this array contained "Monday", aggregators should not
        /// fetch the feed on Mondays.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIArray GetSkipDaysAttribute();
		
		/// <summary>
        /// Days to skip fetching. This field was supposed to designate
        /// intervals for feed fetching. It's not generally implemented. For
        /// example, if this array contained "Monday", aggregators should not
        /// fetch the feed on Mondays.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetSkipDaysAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aSkipDays);
		
		/// <summary>
        /// Hours to skip fetching. This field was supposed to designate
        /// intervals for feed fetching. It's not generally implemented. See
        /// <http://blogs.law.harvard.edu/tech/rss> for more information.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIArray GetSkipHoursAttribute();
		
		/// <summary>
        /// Hours to skip fetching. This field was supposed to designate
        /// intervals for feed fetching. It's not generally implemented. See
        /// <http://blogs.law.harvard.edu/tech/rss> for more information.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetSkipHoursAttribute([MarshalAs(UnmanagedType.Interface)] nsIArray aSkipHours);
	}
	
	/// <summary>nsIFeedConsts </summary>
	internal class nsIFeedConsts
	{
		
		// <summary>
        // All content classifies as a "feed" - it is the transport.
        // </summary>
		public const ulong TYPE_FEED = 0;
		
		// 
		public const ulong TYPE_AUDIO = 1;
		
		// 
		public const ulong TYPE_IMAGE = 2;
		
		// 
		public const ulong TYPE_VIDEO = 4;
	}
}
