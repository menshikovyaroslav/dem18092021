using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;

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
