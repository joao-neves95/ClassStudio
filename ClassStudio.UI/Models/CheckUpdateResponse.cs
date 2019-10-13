/*
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

namespace ClassStudio.UI.Models
{
    public class CheckUpdateResponse
    {
        public bool UpdateAvailable { get; set; }

        public string CurrentVersion { get; set; }

        public string NewAvailableVersion { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
