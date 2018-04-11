using System.IO;
using System.IO.Compression;

namespace Freezer.Utils
{
    /// <summary>
    /// This extensions which allow zip extraction overwrite was taken on : 
    /// http://stackoverflow.com/a/14795752/3655779
    /// </summary>
    internal static class ZipArchiveExtensions
    {
        public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }

            foreach (ZipArchiveEntry file in archive.Entries)
            {
                string completeFileName = Path.Combine(destinationDirectoryName, file.FullName);
                if (file.Name == "")
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }

                var destinationFileInfo = new FileInfo(completeFileName);

                // Overwrite if destinationFileInfo is older than file

                var shouldOverWrite = !destinationFileInfo.Exists ||
                                      destinationFileInfo.LastWriteTimeUtc < file.LastWriteTime.UtcDateTime; 
                
                if (shouldOverWrite)
                    file.ExtractToFile(completeFileName, true);
            }
        }
    }
}