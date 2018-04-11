using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Freezer.UnitTests.TestCases.Core
{
    internal static class TestUtils
    {
        public static string SaveBitmap(Image bitmap, string className, string testName)
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "TestCases", className);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string fullPath = Path.Combine(directory, $"{testName}.png"); 

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                bitmap.Save(fileStream, ImageFormat.Png);
            }

            return fullPath;
        }
    }
}