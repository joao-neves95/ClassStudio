/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.IO;
using System.Xml;
using System.Threading.Tasks;

using Newtonsoft.Json;

using ClassStudio.Core.Enums;
using ClassStudio.Core.Interfaces;

namespace ClassStudio.Core.Services.Converters
{
    public class JsonToCSharp : IConverter
    {
        public async Task ConvertAsync(string input, StringWriter stringWriter)
        {
            XmlDocument doc;

            try
            {
                doc = (XmlDocument)JsonConvert.DeserializeXmlNode( input );
            }
            catch (Exception e)
            {
                try
                {
                    doc = (XmlDocument)JsonConvert.DeserializeXmlNode( "{" + input + "}" );
                }
                catch (Exception e2)
                {
                    doc = (XmlDocument)JsonConvert.DeserializeXmlNode( input, "Root" );
                }
            }

            await ConverterFactory.Get( ConverterType.XMLToCSharp ).ConvertAsync( doc.OuterXml, stringWriter );
        }
    }
}
