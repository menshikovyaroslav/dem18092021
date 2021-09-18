using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using parsing_api.Data;
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

        [Route("api/log/count")]
        [HttpGet]
        public ActionResult<string> LogCount()
        {
            var count = 0;
            try
            {
                count = DataBase.LogCount();
            }
            catch (Exception ex)
            {
                Classes.Log.Instance.Info(ex.Message);
            }

            return Ok($"count: {count}");
        }
    }
}
