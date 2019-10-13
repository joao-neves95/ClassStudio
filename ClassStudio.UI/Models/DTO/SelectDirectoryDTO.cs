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

namespace ClassStudio.UI.Models.DTO
{
    public class SelectDirectoryDTO
    {
        public SelectDirectoryDTO() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectFiles"> Whether to select files or a directory. </param>
        public SelectDirectoryDTO( bool selectDirectory = true )
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
