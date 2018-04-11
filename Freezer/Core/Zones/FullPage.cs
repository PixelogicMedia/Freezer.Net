using System;
using System.Drawing;

namespace Freezer.Core
{
    /// <summary>
    /// Define a CaptureZone representing the whole document. Check CaptureZone.FullPage to have an instance
    /// </summary>
    [Serializable]
    public sealed class FullPage : CaptureZone
    {
        internal FullPage()
        {
            
        }

        internal override Rectangle GetZone(IActiveDocument activeDocument)
        {
            return activeDocument.DocumentSize; 
        }
    }
}