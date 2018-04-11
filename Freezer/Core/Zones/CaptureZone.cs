using System;
using System.Drawing;

namespace Freezer.Core
{
    /// <summary>
    /// Base class for providing rectangle coordinates for screenshot. 
    /// </summary>
    [Serializable]
    public abstract class CaptureZone 
    {
        /// <summary>
        /// Get a CaptureZone representing what is visible on screen 
        /// </summary>
        public static CaptureZone VisibleScreen { get;  } = new VisibleScreen();

        /// <summary>
        /// Get a CaptureZone representing the whole document, ignoring scroll
        /// </summary>
        public static CaptureZone FullPage { get; } = new FullPage();

        protected internal CaptureZone()
        {
            
        }

        internal abstract Rectangle GetZone(IActiveDocument activeDocument);
    }
}