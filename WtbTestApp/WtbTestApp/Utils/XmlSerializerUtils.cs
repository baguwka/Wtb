using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WtbTestApp.Utils
{
    public static class XmlSerializerUtils
    {
        public static string Serialize<T>(T model)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, model, ns);
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

        public static string BeautifyXml(string xml)
        {
            try
            {
                return XDocument.Parse(xml).ToString();
            }
            catch
            {
                //todo log
                return xml;
            }
        }
    }
}