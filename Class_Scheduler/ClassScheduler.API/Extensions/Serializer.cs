using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassScheduler.API.Extensions
{
    public static class Serializer
    {
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null) return null;

            byte[] result = null;
            MemoryStream ms = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(object));
            serializer.WriteObject(ms, obj);
            result = ms.ToArray();
            return result;
        }
    }
}
