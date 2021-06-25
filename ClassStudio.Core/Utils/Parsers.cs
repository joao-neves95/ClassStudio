/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Enums;

namespace ClassStudio.Core.Utils
{
    public static class Parsers
    {
        /// <summary>
        /// 
        /// Returns the extension based on the langEnum type provided.
        /// (E.g.: "*.CS")
        /// 
        /// </summary>
        /// <param name="langEnum"></param>
        /// <returns></returns>
        public static string ParseInputTypeExtension(int langEnum)
        {
            switch (langEnum)
            {
                case (int)LangEnum.CSharp:
                    return "*.CS";

                case (int)LangEnum.XML:
                    return "*.XML";

                case (int)LangEnum.TypeScript:
                    return "*.TS";

                case (int)LangEnum.JSON:
                    return "*.JSON";

                default:
                    return "*.*";
            }
        }
    }
}
