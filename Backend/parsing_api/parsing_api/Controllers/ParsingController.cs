using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using parsing_api.Classes;
using parsing_api.Data;
using parsing_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace parsing_api.Controllers
{
    /// <summary>
    /// Основной контроллер API - методы работы для парсинга данных
    /// </summary>
    [ApiController]
    public class ParsingController : ControllerBase
    {
        /// <summary>
        /// Тест метод для проверки дступности API
        /// </summary>
        /// <returns></returns>
        [Route("api/test")]
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult<string> Test()
        {
            return Ok("Test passed");
        }

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

        [Route("api/log/count")]
        [AllowCrossSiteJson]
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

        /// <summary>
        /// Поиск информации по заданным параметрам
        /// </summary>
        /// <param name="frontRequest">Объект с заданными параметрами</param>
        /// <returns></returns>
        [Route("api/getbyparameters")]
        [AllowCrossSiteJson]
        [HttpPost]
        public ActionResult<string> GetByParameters(FrontRequest frontRequest)
        {
            return Ok($"frontRequest: {frontRequest.Number}");
        }

        /// <summary>
        /// Запрос на создание задания парсинга определенного веб-портала на указанную дату
        /// </summary>
        /// <param name="frontRequest"></param>
        /// <returns></returns>
        [Route("api/setparsing")]
        [AllowCrossSiteJson]
        [HttpPost]
        public ActionResult<string> SetParsing(FrontRequest frontRequest)
        {
            return Ok($"frontRequest: {frontRequest.Number}");
        }
    }
}
