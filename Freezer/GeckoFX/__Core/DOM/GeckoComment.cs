﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Gecko.DOM;

namespace Gecko
{
    /// <summary>
    /// Represents a DOM Comment
    /// </summary>
    internal class GeckoComment : DOM.DomCharacterData
    {
        private nsIDOMComment DomComment;

        internal GeckoComment(nsIDOMComment comment)
            : base(comment)
        {
            DomComment = comment;
        }

        internal static GeckoComment CreateCommentWrapper(nsIDOMComment comment)
        {
            return (comment == null) ? null : new GeckoComment(comment);
        }
    }
}