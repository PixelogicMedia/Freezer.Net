namespace Freezer.Pools
{
    /// <summary>
    /// Represents an available port provider on loopback
    /// </summary>
    internal interface ILocalPortProvider
    {
        /// <summary>
        /// Get an available boundable port on local
        /// </summary>
        /// <returns></returns>
        int GetAvailablePort();
    }
}