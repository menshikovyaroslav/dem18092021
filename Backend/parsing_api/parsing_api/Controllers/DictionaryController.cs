using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using parsing_api.Data;

namespace parsing_api.Controllers
{
    /// <summary>
    /// Методы загрузки словарей из БД
    /// </summary>
    public class DictionaryController : Controller
    {
        /// <summary>
        /// Загрузка регионов из БД
        /// </summary>
        /// <returns></returns>
        [Route("api/regions")]
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult<string> GetRegions()
        {
            var regions = DataBase.GetRegions();
            return Ok(regions);
        }

        /// <summary>
        /// Загрузка списка порталов
        /// </summary>
        /// <returns></returns>
        [Route("api/portals")]
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult<string> GetPortals()
        {
            var portals = DataBase.GetPortals();
            return Ok(portals);
        }
    }
}
