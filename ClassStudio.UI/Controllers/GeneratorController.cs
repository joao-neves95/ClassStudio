using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassStudio.Core.Generators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassStudio.UI.Controllers
{
    [Route("api/generator")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        [HttpPost]
        public string XMLStringToCSharp([FromBody]string xml)
        {
            return XML.ToCSharp( xml );
        }
    }
}
