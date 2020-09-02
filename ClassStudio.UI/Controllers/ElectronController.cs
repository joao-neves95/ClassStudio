/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClassStudio.UI.Models.DTO;

using ElectronNET.API;
using ElectronNET.API.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassStudio.UI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ElectronController : ControllerBase
    {
        [HttpPost]
        [Route( "SelectDirectory" )]
        public async Task<string[]> SelectDirectory([FromBody] SelectDirectoryDTO selectDirectoryDTO)
        {
            try
            {
                OpenDialogOptions options = new OpenDialogOptions
                {
                    Properties = new OpenDialogProperty[2]
                };

                if (selectDirectoryDTO.SelectDirectory)
                {
                    options.Properties[0] = OpenDialogProperty.openDirectory;
                }
                else if (selectDirectoryDTO.SelectFiles)
                {
                    options.Properties[0] = OpenDialogProperty.openFile;
                }

                options.Properties[1] = OpenDialogProperty.multiSelections;

                return await Electron.Dialog.ShowOpenDialogAsync( Startup.MainWindow, options );
            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message );
                Console.WriteLine( e.StackTrace );
            }

            return new string[] { };
        }

        [HttpPost]
        public async void SaveFiles([FromBody] SaveFilesDTO saveFilesDTO)
        {
            throw new NotImplementedException();
        }
    }
}
