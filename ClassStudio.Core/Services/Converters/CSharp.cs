/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

using CSharpToTypescript;
using CSharpToTypescript.Contract;

using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Configuration;
using ClassStudio.Core.Utils;

namespace ClassStudio.Core.Services.Converters
{
    public class CSharp : ICSharpConverter
    {
        public string ToXML<T>(T classInput)
        {
            XmlSerializer xmlSerializer = new XmlSerializer( typeof( T ) );
            using StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize( stringWriter, classInput );

            return stringWriter.ToString();
        }

        public async Task<string> ToTypeScript(string[] typescriptInputs)
        {
            using StringWriter allContent = new StringWriter();
            allContent.WriteClassStudioHeader();

            for (int i = 0; i < typescriptInputs.Length; ++i)
            {
                await allContent.WriteLineAsync( await this.ToTypeScript( typescriptInputs[i], false, allContent ) );
            }

            return allContent.ToString();
        }

        public async Task<string> ToTypeScript(string typescriptInput, bool writeGeneratorHeader = true, StringWriter stringWriter = null)
        {
            ICSharpToTypescriptConverter cSharpToTypescriptConverter = new CSharpToTypescriptConverter();
            string compiledCode = cSharpToTypescriptConverter.ConvertToTypescript( typescriptInput, new TSGeneratorSettings() );

            bool dispose = true;

            if (stringWriter == null)
            {
                stringWriter = new StringWriter();
                dispose = false;
            }

            if (writeGeneratorHeader)
            {
                stringWriter.WriteClassStudioHeader();
            }

            await stringWriter.WriteLineAsync( compiledCode );
            string result = stringWriter.ToString();

            if (dispose)
            {
                await stringWriter.DisposeAsync();
            }

            return result;
        }

        public static string ToJSON()
        {
            throw new NotImplementedException();
        }
    }
}
