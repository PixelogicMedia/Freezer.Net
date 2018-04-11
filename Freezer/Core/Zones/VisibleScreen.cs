using System;
using System.Drawing;

namespace Freezer.Core
{
    /// <summary>
    /// Define a CaptureZone representing the visible screen. Check CaptureZone.VisibleScreen to get an instance.
    /// </summary>
    [Serializable]
    public sealed class VisibleScreen : CaptureZone
    {
        internal VisibleScreen()
        {
            
        }

        internal override Rectangle GetZone(IActiveDocument activeDocument)
        {
            return new Rectangle(0, 0, activeDocument.BrowserSize.Width, activeDocument.BrowserSize.Height);
        }
    }
}