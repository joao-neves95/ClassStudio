using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassStudio.Core.Generators
{
    public static class CSharp
    {
        public static string ToXML<T>(T classInput)
        {
            XmlSerializer xmlSerializer = new XmlSerializer( typeof( T ) );
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize( stringWriter, classInput );

            return stringWriter.ToString();
        }

        public static void ToTypeScript()
        {

        }

        public static string ToJSON()
        {
            throw new NotImplementedException();
        }
    }
}
