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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassStudio.Core.Generators;
using ClassStudio.UI.Models.DTO;
using Newtonsoft.Json;

namespace ClassStudio.UI.Controllers
{
    [Route("api/generator")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        [HttpPost]
        [Route( "XMLStringToCSharp" )]
        public string XMLStringToCSharp([FromBody]XMLStringToCSharpDTO dto)
        {
            try
            {
                // TEMPORARY.
                return CSharp.ToTypeScript( dto.XML );
                //return XML.ToCSharp( dto.XML );
            }
            catch (Exception e)
            {
                return $"{e.Message} \n{e.StackTrace}";
            }
        }
    }
}
