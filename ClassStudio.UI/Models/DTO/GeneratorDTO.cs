/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.UI.Enums;

namespace ClassStudio.UI.Models.DTO
{
    public class GeneratorDTO
    {
        public string Input { get; set; }

        /// <summary>
        /// LangEnum
        /// </summary>
        public sbyte InputType { get; set; }

        public bool InputAreFiles { get; set; }

        public string[] InputSourceFiles { get; set; }
    }
}
