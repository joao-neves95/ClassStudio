/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.UI.Models.Components;

namespace ClassStudio.UI.Models
{
    public class IndexViewModel
    {
        public SelectViewModel InputTypeSelector { get; set; }

        public SelectViewModel OutputTypeSelector { get; set; }
    }
}
