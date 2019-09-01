/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System.ComponentModel.DataAnnotations;

namespace ClassStudio.UI.Models.DTO
{
    public class GeneratorDTO
    {
        [Required]
        public string Input { get; set; }
    }
}
