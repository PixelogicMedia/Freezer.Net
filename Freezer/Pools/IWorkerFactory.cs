namespace Freezer.Pools
{
    internal interface IWorkerFactory<out T>
    {
        T CreateInstance(string parentIdentifier);
    }
}