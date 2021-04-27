namespace Scada.DBUtility
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class ScadaJsonConvertor
    {
        public static T DeepCopyByBinary<T>(T obj)
        {
            object obj2;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                formatter1.Serialize(stream, obj);
                stream.Seek(0L, SeekOrigin.Begin);
                obj2 = formatter1.Deserialize(stream);
                stream.Close();
            }
            return (T) obj2;
        }

        public static T JsonToObject<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch
            {
                return default(T);
            }
        }

        public static string ObjectToJson(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(obj);
        }
    }
}

