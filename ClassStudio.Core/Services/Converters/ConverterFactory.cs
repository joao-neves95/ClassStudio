/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;

using ClassStudio.Core.Enums;
using ClassStudio.Core.Interfaces;

namespace ClassStudio.Core.Services.Converters
{
    public static class ConverterFactory
    {
        public static readonly IDictionary<LangEnum, LangEnum[]> ConverterMappings = new Dictionary<LangEnum, LangEnum[]>()
        {
            { LangEnum.CSharp, new LangEnum[] { LangEnum.TypeScript } },
            { LangEnum.XML, new LangEnum[] { LangEnum.CSharp } },
            { LangEnum.JSON, new LangEnum[] { LangEnum.CSharp } },
            { LangEnum.TypeScript, Array.Empty<LangEnum>() },
            { LangEnum.JavaScript, Array.Empty<LangEnum>() }
        };

        private static readonly IDictionary<ConverterType, IConverter> TypeMapping = new Dictionary<ConverterType, IConverter>()
        {
            { ConverterType.CSharpToTypescript, new CSharpToTypescript() },
            { ConverterType.XMLToCSharp, new XMLToCSharp() },
            { ConverterType.JsonToCSharp, new JsonToCSharp() }
        };

        public static IConverter Get(ConverterType converterType)
        {
            return ConverterFactory.TypeMapping[converterType];
        }
    }
}
