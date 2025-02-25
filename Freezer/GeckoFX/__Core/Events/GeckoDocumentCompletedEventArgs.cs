﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gecko.Events
{
    internal class GeckoDocumentCompletedEventArgs : EventArgs
    {
        public Uri Uri { get; private set; }
        public GeckoWindow Window { get; private set; }

        public bool IsTopLevel
        {
            get { return Window.IsTopWindow(); }
        }

        public GeckoDocumentCompletedEventArgs(Uri uri, GeckoWindow window)
        {
            this.Uri = uri;
            this.Window = window;
        }
    }
}