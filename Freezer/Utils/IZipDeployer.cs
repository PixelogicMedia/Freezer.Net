namespace Freezer.Utils
{
    internal interface IZipDeployer
    {
        void DeployOnDirectory(string directoryName);
        void Dispose();
    }
}