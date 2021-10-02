using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BikeSharingAPI.Helpers
{
    public static class HelperXML
    {
        public static string TOXML<T>(T obj)
        {
            try
            {
                var xml = "";

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        serializer.Serialize(writer, obj);
                        xml = sww.ToString();
                    }
                }

                return xml;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
