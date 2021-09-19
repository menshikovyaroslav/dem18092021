using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using parsing_api.Data;
using Support;
using Support.Models;
using System;

namespace parsing_api.Controllers
{
    /// <summary>
    /// Контроллер для получения клиентской информации из БД
    /// </summary>
    public class DataController : Controller
    {
        /// <summary>
        /// Поиск кейсов по параметрам
        /// </summary>
        /// <param name="frontRequest"></param>
        /// <returns></returns>
        [Route("api/getcases")]
        [AllowCrossSiteJson]
        [HttpPost]
        public ActionResult<string> GetCases(FrontRequest frontRequest)
        {
            return Ok($"");
        }
    }
}
