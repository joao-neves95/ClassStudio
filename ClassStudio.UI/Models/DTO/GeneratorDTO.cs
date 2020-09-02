/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
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
