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
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronController : ControllerBase
    {
        public async Task<string[]> SelectDirectory(SelectDirectoryDTO selectDirectoryDTO)
        {
            OpenDialogOptions options = new OpenDialogOptions
            {
                Properties = new OpenDialogProperty[1]
            };

            if (selectDirectoryDTO.SelectDirectory)
            {
                options.Properties[0] = OpenDialogProperty.openDirectory;
            }
            else if (selectDirectoryDTO.SelectFile)
            {
                options.Properties[0] = OpenDialogProperty.openFile;
            }

            return await Electron.Dialog.ShowOpenDialogAsync( Startup.MainWindow, options );
        }

        public async void SaveFiles(SaveFilesDTO saveFilesDTO)
        {
            throw new NotImplementedException();
        }
    }
}
