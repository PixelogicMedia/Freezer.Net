using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freezer.UnitTests
{
    public static class AssertExtensions
    {
        public static void BitmapEquals(string expectedPath, string actualPath)
        {
            Assert.AreEqual(new FileInfo(expectedPath).Length, new FileInfo(actualPath).Length);
        }

        public static void BitmapEquals(string expectedPath, Image resultImage)
        {
            using (var memoryStream = new MemoryStream())
            {
                resultImage.Save(memoryStream, ImageFormat.Png);
                Assert.AreEqual(new FileInfo(expectedPath).Length, memoryStream.ToArray().Length);
            }
        }
    }
}
