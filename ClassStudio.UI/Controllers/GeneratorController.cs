/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ClassStudio.Core.Enums;
using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Models.DTO;
using ClassStudio.Core.Utils;
using ClassStudio.Core.Services.Converters;

namespace ClassStudio.UI.Controllers
{
    [Route( "api/generator" )]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        private readonly IConverterService _ConverterService;

        public GeneratorController(IConverterService converterService)
        {
            this._ConverterService = converterService;
        }

        [HttpGet]
        [Route( "ConverterMappings" )]
        public IDictionary<LangEnum, LangEnum[]> GetConverterMappings()
        {
            return ConverterFactory.ConverterMappings;
        }

        // TODO: Remove this duplication.
        #region TO REFACTOR

        [HttpPost]
        [Route( "XMLStringToCSharp" )]
        public async Task<string> XMLStringToCSharp([FromBody] GeneratorDTO dto)
        {
            try
            {
                if (dto.Input != null)
                {
                    return await this._ConverterService.ConvertAsync( ConverterType.XMLToCSharp, dto.Input );
                }
                else
                {
                    return await this._ConverterService.ConvertAsync( ConverterType.XMLToCSharp, await this.GetInputFromFilesAsync( dto ) );
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
                    return await this._ConverterService.ConvertAsync( ConverterType.CSharpToTypescript, dto.Input );
                }
                else
                {
                    return await this._ConverterService.ConvertAsync( ConverterType.CSharpToTypescript, await this.GetInputFromFilesAsync( dto ) );
                }
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }

        [HttpPost]
        [Route( "JsonToCSharp" )]
        public async Task<string> JsonToCSharp([FromBody] GeneratorDTO dto)
        {
            try
            {
                if (dto.Input != null)
                {
                    return await this._ConverterService.ConvertAsync( ConverterType.JsonToCSharp, dto.Input );
                }
                else
                {
                    return await this._ConverterService.ConvertAsync( ConverterType.JsonToCSharp, await this.GetInputFromFilesAsync( dto ) );
                }
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }

        #endregion TO REFACTOR

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
