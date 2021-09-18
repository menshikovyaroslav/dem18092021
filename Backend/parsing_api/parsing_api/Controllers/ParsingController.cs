using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace parsing_api.Controllers
{
    [ApiController]
    public class ParsingController : ControllerBase
    {
        [Route("api/test")]
        [HttpGet]
        public ActionResult<string> Test()
        {
            return Ok("Test passed");
        }
    }
}
