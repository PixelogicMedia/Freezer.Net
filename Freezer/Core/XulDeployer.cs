using Freezer.Utils;

namespace Freezer.Core
{
    internal class XulDeployer : IXulDeployer
    {
        private readonly byte[] _payload;

        internal XulDeployer(byte[] payload)
        {
            _payload = payload;
        }

        public void Deploy(string path)
        {
            using (var zipDeployer = new ZipDeployer(_payload))
            {
                zipDeployer.DeployOnDirectory(path);
            }
        }
    }
}