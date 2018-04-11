namespace Gecko.Cryptography
{
    internal sealed class KeyObject
    {
        private nsIKeyObject _keyObject;

        internal KeyObject(nsIKeyObject keyObject)
        {
            _keyObject = keyObject;
        }
    }
}