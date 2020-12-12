/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

namespace ClassStudio.Core.Models.DTO
{
    public class SelectDirectoryDTO
    {
        public SelectDirectoryDTO() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectFiles"> Whether to select files or a directory. </param>
        public SelectDirectoryDTO(bool selectDirectory = true)
        {
            if (selectDirectory)
            {
                this.SelectDirectory = true;
            }
            else
            {
                this.SelectFiles = true;
            }
        }

        public bool SelectFiles { get; set; } = false;

        public bool SelectDirectory { get; set; } = false;
    }
}
