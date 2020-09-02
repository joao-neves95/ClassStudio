/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System.IO;
using System.Threading.Tasks;

using Xml2CSharp;

using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Utils;

namespace ClassStudio.Core.Services.Converters
{
    public class XML : IXMLConverter
    {
        public async Task<string> ToCSharp(string[] xmlInputs)
        {
            using StringWriter allContents = new StringWriter();
            await allContents.WriteLineAsync( allContents.WriteClassStudioHeader().ToString() );


            for (int i = 0; i < xmlInputs.Length; ++i)
            {
                await allContents.WriteLineAsync( this.ToCSharp( xmlInputs[i], false ) );
            }

            return allContents.ToString();
        }

        public string ToCSharp(string xmlInput, bool writeGeneratorHeader = true, StringWriter stringWriter = null)
        {
            ClassInfoWriter classInfoWriter = new ClassInfoWriter(
                new Xml2CSharpConverer().Convert( xmlInput )
            );

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

            classInfoWriter.Write( stringWriter );
            string result = stringWriter.ToString();

            if (dispose)
            {
                stringWriter.Dispose();
            }

            return result;
        }
    }
}
