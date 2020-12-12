/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ClassStudio.Core.Enums;
using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Models.DTO;
using ClassStudio.Core.Utils;
using ClassStudio.UI.Models.DTO;

namespace ClassStudio.UI.Controllers
{
    [Route( "api/generator" )]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        public GeneratorController(ICSharpConverter cSharpConverter, IXMLConverter xMLConverter)
        {
            this._CSharpConverter = cSharpConverter;
            this._XMLConverter = xMLConverter;
        }

        private ICSharpConverter _CSharpConverter { get; set; }

        private IXMLConverter _XMLConverter { get; set; }

        [HttpPost]
        [Route( "XMLStringToCSharp" )]
        public async Task<string> XMLStringToCSharp([FromBody] GeneratorDTO dto)
        {
            try
            {
                if (dto.Input != null)
                {
                    return this._XMLConverter.ToCSharp( dto.Input );
                }
                else
                {
                    return await this._XMLConverter.ToCSharp( await this.GetInputFromFilesAsync( dto ) );
                }
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }

        [HttpPost]
        [Route( "CSharpToTypescript" )]
        public async Task<string> CSharpToTypescript([FromBody] GeneratorDTO dto)
        {
            try
            {
                if (dto.Input != null)
                {
                    return await this._CSharpConverter.ToTypeScript( dto.Input );
                }
                else
                {
                    return await this._CSharpConverter.ToTypeScript( await this.GetInputFromFilesAsync( dto ) );
                }
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }

        private async Task<string[]> GetInputFromFilesAsync(GeneratorDTO generatorDTO)
        {
            if (!generatorDTO.InputAreFiles)
            {
                return await Readers.ReadFileAsync( Readers.ReadDirectory(
                    generatorDTO.InputSourceFiles,
                    Parsers.ParseInputTypeExtension( generatorDTO.InputType )
                ) );
            }
            else
            {
                return await Readers.ReadFileAsync( generatorDTO.InputSourceFiles );
            }
        }
    }
}
