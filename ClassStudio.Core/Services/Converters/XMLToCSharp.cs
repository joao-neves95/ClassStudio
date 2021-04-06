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

namespace ClassStudio.Core.Services.Converters
{
    public class XMLToCSharp : IConverter
    {
        public async Task ConvertAsync(string input, StringWriter stringWriter)
        {
            ClassInfoWriter classInfoWriter = new ClassInfoWriter(
                new Xml2CSharpConverer().Convert( input )
            );

            await classInfoWriter.WriteAsync( stringWriter );
        }
    }
}
