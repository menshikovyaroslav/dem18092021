using Microsoft.AspNetCore.Mvc;
using parsing_api.Classes;
using parsing_api.Data;
using Support.Models;

namespace parsing_api.Controllers
{
    /// <summary>
    /// Основной контроллер API - методы работы для парсинга данных
    /// </summary>
    [ApiController]
    public class ParsingController : ControllerBase
    {

        /// <summary>
        /// Запрос на создание задания парсинга определенного веб-портала на указанную дату
        /// </summary>
        /// <param name="parsingRequest"></param>
        /// <returns></returns>
        [Route("api/newjob")]
        [AllowCrossSiteJson]
        [HttpPost]
        public ActionResult<string> SetParsing(ParsingRequest parsingRequest)
        {
            // получили запрос на парсинг, отправляем задачу на исполнение
            ParsingFactory.Parse(parsingRequest);

            return Ok("success");
        }

        /// <summary>
        /// Получить все задания
        /// </summary>
        /// <returns></returns>
        [Route("api/jobs")]
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult<string> GetJobs()
        {
            var jobs = DataBase.GetJobs();
            return Ok(jobs);
        }

        /// <summary>
        /// Получить задачу по ее Id
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [Route("api/job")]
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult<string> GetJob(string jobId)
        {
            var job = DataBase.GetJobById(jobId);
            if (job == null) return NotFound();
            return Ok(job);
        }
    }
}
