/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Configuration;
using ClassStudio.Core.Utils;
using System;
using System.IO;
using System.Xml.Serialization;
using CSharpToTypescript;
using System.Threading.Tasks;

namespace ClassStudio.Core.Generators
{
    public static class CSharp
    {
        public static string ToXML<T>(T classInput)
        {
            XmlSerializer xmlSerializer = new XmlSerializer( typeof( T ) );
            using StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize( stringWriter, classInput );

            return stringWriter.ToString();
        }

        public static async Task<string> ToTypeScript(string[] typescriptInputs)
        {
            using StringWriter allContent = new StringWriter();

            for (int i = 0; i < typescriptInputs.Length; ++i)
            {
                await allContent.WriteLineAsync( await CSharp.ToTypeScript( typescriptInputs[i] ) );
            }

            return allContent.ToString();
        }

        public static async Task<string> ToTypeScript(string typescriptInput)
        {
            CSharpToTypescriptConverter cSharpToTypescriptConverter = new CSharpToTypescriptConverter();
            string compiledCode = cSharpToTypescriptConverter.ConvertToTypescript( typescriptInput, new TSGeneratorSettings() );

            using StringWriter stringWriter = new StringWriter().WriteClassStudioHeader();
            await stringWriter.WriteLineAsync( compiledCode );

            return stringWriter.ToString();
        }

        public static string ToJSON()
        {
            throw new NotImplementedException();
        }
    }
}
