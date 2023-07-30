using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Class_Scheduler.Extensions
{
    public static class XmlSerializeManager
    {
        public static void XmlSerialize<T>(string Path, System.Object obj)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Path);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                writer.Close();
            }
            catch (Exception e) 
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public static T XmlDeserializer<T>(string Path)
        {
            try
            {
                if (!File.Exists(Path))
                    throw new ArgumentNullException(Path + " not Exists");

                using (StreamReader reader = new StreamReader(Path))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    T res = (T)xs.Deserialize(reader);
                    return res;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return default(T);
            }
        }
    }
}
