using System;
using System.IO;
using System.IO.Compression;

namespace Freezer.Utils
{
    internal sealed class ZipDeployer : IDisposable, IZipDeployer
    {
        private static readonly string DefaultDirectory;

        static ZipDeployer()
        {
            DefaultDirectory =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "ZipDeployer", "Temp");

            if (!Directory.Exists(DefaultDirectory))
            {
                Directory.CreateDirectory(DefaultDirectory);
            }
        }

        private Stream _contentStream;
        private readonly bool _disposeStreamOnDone; 

        public ZipDeployer(byte[] byteArray) :
            this (new MemoryStream(byteArray))
        {
            _disposeStreamOnDone = true; 
        }

        public ZipDeployer(Stream stream)
        {
            _contentStream = stream;  
        }
         
        public void DeployOnDirectory(string directoryName)
        {
            var targetDirectory = directoryName;

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            using (ZipArchive archive = new ZipArchive(_contentStream, ZipArchiveMode.Read, true))
            {
                archive.ExtractToDirectory(Path.Combine(DefaultDirectory, directoryName), true);
            }
        }

        public void Dispose()
        {
            if (_disposeStreamOnDone)
            {
                _contentStream?.Dispose();
                _contentStream = null; 
            }
        }
    }
}