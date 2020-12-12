/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Interfaces;

using Xml2CSharp;

namespace ClassStudio.Core.Services.Converters
{
    public class XMLToCSharp : IConverter<string>
    {
        public string Convert(string input)
        {
            ClassInfoWriter classInfoWriter = new ClassInfoWriter(
                new Xml2CSharpConverer().Convert( input )
            );

            return classInfoWriter.ToString();
        }
    }
}
