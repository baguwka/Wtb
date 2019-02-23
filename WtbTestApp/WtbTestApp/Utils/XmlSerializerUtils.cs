using System.IO;
using System.Xml.Serialization;

namespace WtbTestApp.Utils
{
    public static class XmlSerializerUtils
    {
        public static string Serialize<T>(T model)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, model);
                return stringWriter.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xml))
            {
                return (T) serializer.Deserialize(stringReader);
            }
        }
    }
}