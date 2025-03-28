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
// Generated by IDLImporter from file nsIAccessibleTextRange.idl
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
    /// A range representing a piece of text in the document.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("525b3401-8a67-4822-b35d-661065767cd8")]
	internal interface nsIAccessibleTextRange
	{
		
		/// <summary>
        /// A range representing a piece of text in the document.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessibleText GetStartContainerAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetStartOffsetAttribute();
		
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessibleText GetEndContainerAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetEndOffsetAttribute();
		
		/// <summary>
        /// Return an accessible containing the whole range
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessible GetContainerAttribute();
		
		/// <summary>
        /// Return embedded children within the range.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIArray GetEmbeddedChildrenAttribute();
		
		/// <summary>
        /// Return true if this range has the same end points of the given range.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool Compare([MarshalAs(UnmanagedType.Interface)] nsIAccessibleTextRange aOtherRange);
		
		/// <summary>
        /// Compare this and given ranges end points.
        ///
        /// @return -1/0/1 if this range end point is before/equal/after the given
        /// range end point.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int CompareEndPoints(uint aEndPoint, [MarshalAs(UnmanagedType.Interface)] nsIAccessibleTextRange aOtherRange, uint aOtherRangeEndPoint);
		
		/// <summary>
        /// Return text within the range.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetTextAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aText);
		
		/// <summary>
        /// Return list of rects of the range.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIArray GetBoundsAttribute();
		
		/// <summary>
        /// Move the boundary(ies) by the given number of the unit.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Move(uint aUnit, int aCount);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void MoveStart(uint aUnit, int aCount);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void MoveEnd(uint aUnit, int aCount);
		
		/// <summary>
        /// Normalize the range to the closest unit of the given type.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Normalize(uint aUnit);
		
		/// <summary>
        /// Return range enclosing the found text.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessibleTextRange FindText([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase aText, [MarshalAs(UnmanagedType.U1)] bool aIsBackward, [MarshalAs(UnmanagedType.U1)] bool aIsIgnoreCase);
		
		/// <summary>
        /// Return range enslosing the text having requested attribute.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAccessibleTextRange FindAttr(uint aAttr, [MarshalAs(UnmanagedType.Interface)] nsIVariant aValue, [MarshalAs(UnmanagedType.U1)] bool aIsBackward);
		
		/// <summary>
        /// Add/remove the text range from selection.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AddToSelection();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RemoveFromSelection();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Select();
		
		/// <summary>
        /// Scroll the range into view.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollIntoView(uint aHow);
	}
	
	/// <summary>nsIAccessibleTextRangeConsts </summary>
	internal class nsIAccessibleTextRangeConsts
	{
		
		// <summary>
        // The two endpoints of the range (starting and ending).
        // </summary>
		public const ulong EndPoint_Start = 1;
		
		// 
		public const ulong EndPoint_End = 2;
		
		// 
		public const ulong FormatUnit = 0;
		
		// 
		public const ulong WordUnit = 1;
		
		// 
		public const ulong LineUnit = 2;
		
		// 
		public const ulong ParagraphUnit = 3;
		
		// 
		public const ulong PageUnit = 4;
		
		// 
		public const ulong DocumentUnit = 5;
		
		// <summary>
        // Text attributes. Used in conjunction with findAttrs().
        // </summary>
		public const ulong AnimationStyleAttr = 0;
		
		// 
		public const ulong AnnotationObjectsAttr = 1;
		
		// 
		public const ulong AnnotationTypesAttr = 2;
		
		// 
		public const ulong BackgroundColorAttr = 3;
		
		// 
		public const ulong BulletStyleAttr = 4;
		
		// 
		public const ulong CapStyleAttr = 5;
		
		// 
		public const ulong CaretBidiModeAttr = 6;
		
		// 
		public const ulong CaretPositionAttr = 7;
		
		// 
		public const ulong CultureAttr = 8;
		
		// 
		public const ulong FontNameAttr = 9;
		
		// 
		public const ulong FontSizeAttr = 10;
		
		// 
		public const ulong FontWeightAttr = 11;
		
		// 
		public const ulong ForegroundColorAttr = 12;
		
		// 
		public const ulong HorizontalTextAlignmentAttr = 13;
		
		// 
		public const ulong IndentationFirstLineAttr = 14;
		
		// 
		public const ulong IndentationLeadingAttr = 15;
		
		// 
		public const ulong IndentationTrailingAttr = 16;
		
		// 
		public const ulong IsActiveAttr = 17;
		
		// 
		public const ulong IsHiddenAttr = 18;
		
		// 
		public const ulong IsItalicAttr = 19;
		
		// 
		public const ulong IsReadOnlyAttr = 20;
		
		// 
		public const ulong IsSubscriptAttr = 21;
		
		// 
		public const ulong IsSuperscriptAttr = 22;
		
		// 
		public const ulong LinkAttr = 23;
		
		// 
		public const ulong MarginBottomAttr = 24;
		
		// 
		public const ulong MarginLeadingAttr = 25;
		
		// 
		public const ulong MarginTopAttr = 26;
		
		// 
		public const ulong MarginTrailingAttr = 27;
		
		// 
		public const ulong OutlineStylesAttr = 28;
		
		// 
		public const ulong OverlineColorAttr = 29;
		
		// 
		public const ulong OverlineStyleAttr = 30;
		
		// 
		public const ulong SelectionActiveEndAttr = 31;
		
		// 
		public const ulong StrikethroughColorAttr = 32;
		
		// 
		public const ulong StrikethroughStyleAttr = 33;
		
		// 
		public const ulong StyleIdAttr = 34;
		
		// 
		public const ulong StyleNameAttr = 35;
		
		// 
		public const ulong TabsAttr = 36;
		
		// 
		public const ulong TextFlowDirectionsAttr = 37;
		
		// 
		public const ulong UnderlineColorAttr = 38;
		
		// 
		public const ulong UnderlineStyleAttr = 39;
		
		// 
		public const ulong AlignToTop = 0;
		
		// 
		public const ulong AlignToBottom = 1;
	}
}
