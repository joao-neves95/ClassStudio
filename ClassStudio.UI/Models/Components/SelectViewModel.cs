﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassStudio.UI.Models.Components
{
    public class SelectViewModel
    {
        public string Id { get; set; }

        public List<OptionViewModel> Options { get; set; }
    }

    public class OptionViewModel
    {
        public string Label { get; set; }

        public string Value { get; set; }
    }
}
