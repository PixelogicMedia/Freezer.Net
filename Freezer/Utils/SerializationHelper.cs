using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Freezer.Utils
{
    internal static class SerializationHelper
    {
        static SerializationHelper()
        {
            DefaultFormatter = new BinaryFormatter(); 
        }

        public static IFormatter DefaultFormatter { get; set; }

        public static byte [] ToByteArray<T>(this T instance)
        {
            IFormatter binaryFormatter = DefaultFormatter;

            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, instance);
                return memoryStream.ToArray();
            }
        }

        public static T FromByteArray<T>(byte[] array)
        {
            IFormatter binaryFormatter = DefaultFormatter;

            using (var memoryStream = new MemoryStream(array))
            {
                return (T) binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
