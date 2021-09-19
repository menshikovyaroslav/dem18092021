using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using parsing_api.Data;
using Support;
using Support.Models;
using System;
using System.Collections.Generic;
using Support.Extensions;
using System.Linq;
using System.Web.Http.Cors;

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
        [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
        [HttpGet]
        public ActionResult<string> GetCases(FrontRequest frontRequest)
        {
            Log.Instance.Info($"x1: {frontRequest.DateFrom}");
            Log.Instance.Info($"x1-1: {frontRequest.DateTo}");

            // получаем все кейсы
            var result = DataBase.GetAllCases();

            Log.Instance.Info($"x2: {result.Count}");

            // фильтр по номеру кейса
            if (!frontRequest.Number.IsEmpty()) result = result.Where(c => c.Number == frontRequest.Number).ToList();

            Log.Instance.Info($"x3: {result.Count}");

            // фильтр по дате поступления дела
            result = result.Where(c => c.DateIn >= frontRequest.DateFrom && c.DateIn <= frontRequest.DateTo).ToList();

            Log.Instance.Info($"x4: {result.Count}");

            return Ok(result);
        }
    }
}
