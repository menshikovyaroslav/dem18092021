using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Controllers
{
    /// <summary>
    /// Контроллер для тест запросов
    /// </summary>
    public class TestController : Controller
    {
        /// <summary>
        /// Тест метод для проверки доступности API
        /// </summary>
        /// <returns></returns>
        [Route("api/test")]
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult<string> Test()
        {
            return Ok("Test passed");
        }
    }
}
