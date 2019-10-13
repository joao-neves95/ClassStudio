using ClassStudio.UI.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassStudio.Core.Utils
{
    public class Parsers
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
