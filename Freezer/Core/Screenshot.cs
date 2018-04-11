using System;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using Freezer.Mvc;

namespace Freezer.Core
{
    /// <summary>
    /// Represent the result of a freezer screeenshot.
    /// </summary>
    public sealed class Screenshot
    {
        private readonly byte [] _imageData;


        internal Screenshot(byte[] imageData)
        {
            if (imageData == null)
                throw new ArgumentNullException(nameof(imageData));

            _imageData = imageData;
        }

        /// <summary>
        /// Gets screenshot as byte array in PNG format. 
        /// </summary>
        /// <returns>byte array in PNG format</returns>
        public byte [] AsBytes()
        {
            byte [] result = new byte[_imageData.Length];
            Buffer.BlockCopy(_imageData, 0, result, 0, _imageData.Length);

            return result; 
        }

        /// <summary>
        /// Get current screenshot as System.Drawing.Image
        /// </summary>
        /// <returns> System.Drawing.Image representing the screenshot</returns>
        public Image AsImage()
        {
            using (var memoryStream = new MemoryStream(_imageData))
            {
                return Image.FromStream(memoryStream);
            }
        }

        /// <summary>
        /// Get current screenshot as ActionResult
        /// </summary>
        /// <returns>ActionResult representing the screenshot</returns>
        public ActionResult AsActionResult()
        {
            return new ScreenshotMvcResult(this);
        }

        /// <summary>
        /// Syntaxic sugar for AsBytes()
        /// </summary>
        /// <param name="screenShot"></param>
        public static implicit operator byte[] (Screenshot screenShot)
        {
            return screenShot.AsBytes();
        }

        /// <summary>
        /// Syntaxic sugar for AsImage()
        /// </summary>
        /// <param name="screenShot"></param>
        public static implicit operator Bitmap(Screenshot screenShot)
        {
            return (Bitmap) screenShot.AsImage(); 
        }

        /// <summary>
        /// Syntaxic sugar for AsActionResult()
        /// </summary>
        /// <param name="screenShot"></param>
        public static implicit operator ActionResult(Screenshot screenShot)
        {
            return screenShot.AsActionResult();
        }
    }
}