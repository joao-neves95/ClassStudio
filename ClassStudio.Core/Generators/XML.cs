/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Utils;
using System.IO;
using System.Threading.Tasks;
using Xml2CSharp;

namespace ClassStudio.Core.Generators
{
    public static class XML
    {
        public static async Task<string> ToCSharp(string[] xmlInputs)
        {
            using StringWriter allContents = new StringWriter();

            for (int i = 0; i < xmlInputs.Length; ++i)
            {
                await allContents.WriteLineAsync( XML.ToCSharp( xmlInputs[i] ) );
            }

            return allContents.ToString();
        }

        public static string ToCSharp(string xmlInput)
        {
            ClassInfoWriter classInfoWriter = new ClassInfoWriter(
                new Xml2CSharpConverer().Convert( xmlInput )
            );

            using StringWriter stringWriter = new StringWriter().WriteClassStudioHeader();
            classInfoWriter.Write( stringWriter );

            return stringWriter.ToString();
        }
    }
}
