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

namespace ClassStudio.UI.Controllers
{
    [Route( "api/generator" )]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        [HttpPost]
        [Route( "XMLStringToCSharp" )]
        public string XMLStringToCSharp([FromBody]GeneratorDTO dto)
        {
            try
            {
                return XML.ToCSharp( dto.Input );
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }

        [HttpPost]
        [Route( "CSharpToTypescript" )]
        public string CSharpToTypescript([FromBody]GeneratorDTO dto)
        {
            try
            {
                return CSharp.ToTypeScript( dto.Input );
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }
    }
}
