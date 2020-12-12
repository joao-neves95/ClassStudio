/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

namespace ClassStudio.Core.Models
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
