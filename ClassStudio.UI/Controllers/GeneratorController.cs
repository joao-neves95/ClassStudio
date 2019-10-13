/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Generators;
using ClassStudio.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using ClassStudio.Core.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassStudio.UI.Controllers
{
    [Route( "api/generator" )]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        [HttpPost]
        [Route( "XMLStringToCSharp" )]
        public async Task<string> XMLStringToCSharp([FromBody]GeneratorDTO dto)
        {
            try
            {
                if (dto.Input != null)
                {
                    return XML.ToCSharp( dto.Input );
                }
                else
                {
                    return await XML.ToCSharp( await this.GetInputFromFilesAsync( dto ) );
                }
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }

        [HttpPost]
        [Route( "CSharpToTypescript" )]
        public async Task<string> CSharpToTypescript([FromBody]GeneratorDTO dto)
        {
            try
            {
                if (dto.Input != null)
                {
                    return await CSharp.ToTypeScript( dto.Input );
                }
                else
                {
                    return await CSharp.ToTypeScript( await this.GetInputFromFilesAsync( dto ) );
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
