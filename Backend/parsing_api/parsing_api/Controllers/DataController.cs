using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using parsing_api.Data;
using parsing_api.Models;
using System;

namespace parsing_api.Controllers
{
    /// <summary>
    /// Контроллер для получения клиентской информации из БД
    /// </summary>
    public class DataController : Controller
    {
        /// <summary>
        /// Ненужный запрос - скоро удалим
        /// </summary>
        /// <returns></returns>
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
    }
}
