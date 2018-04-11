using System;
using System.Drawing;
using Freezer.Engines;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a rectangle in the web page where the screenshot is taken
    /// </summary>
    [Serializable]
    public sealed class CroppedZone : CaptureZone
    {
        /// <summary>
        /// This constructor is only there for serialization purpose
        /// </summary>
        private CroppedZone() 
        {
            Zone = Rectangle.Empty;
        }

        /// <summary>
        /// Creates a CroppedZone from System.Drawing.Rectangle
        /// </summary>
        /// <param name="zone"></param>
        public CroppedZone(Rectangle zone)
        {
            if (zone.Width <= 0 || zone.Height <= 0 || zone.X < 0 || zone.Height < 0)
                throw new ArgumentException("Selected zone is invalid", nameof(zone));
            
            Zone = zone; 
        }

        /// <summary>
        /// Creates a CroppedZone by providing rectangle coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CroppedZone(int x, int y , int width, int height) :
            this (new Rectangle(x, y, width, height))
        {
        }

        /// <summary>
        /// Get the actual zone of this CroppedZone instance
        /// </summary>
        public Rectangle Zone { get;  }

        internal override Rectangle GetZone(IActiveDocument activeDocument)
        {
            var browserRect = new Rectangle(0, 0, activeDocument.BrowserSize.Width, activeDocument.BrowserSize.Height);

            if (!browserRect.Contains(Zone))
                throw new CaptureEngineException($"Cropped zone is out of bounds for active document. Current size is {browserRect}", CaptureEngineState.InvalidCaptureZone);

            return Zone;
        }
    }
}