/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using CSharpToTypescript;
using CSharpToTypescript.Contract;

using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Configuration;

namespace ClassStudio.Core.Services.Converters
{
    public class CSharpToTypescript : IConverter<string>
    {
        public string Convert(string input)
        {
            ICSharpToTypescriptConverter cSharpToTypescriptConverter = new CSharpToTypescriptConverter();
            return cSharpToTypescriptConverter.ConvertToTypescript( input, new TSGeneratorSettings() );
        }
    }
}
