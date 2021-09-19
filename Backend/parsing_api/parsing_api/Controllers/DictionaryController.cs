using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using parsing_api.Data;
using System.Web.Http.Cors;

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
        [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
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
        [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
        [HttpGet]
        public ActionResult<string> GetPortals()
        {
            var portals = DataBase.GetPortals();
            return Ok(portals);
        }
    }
}
