using Microsoft.EntityFrameworkCore;
using Support;
using Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace parsing_api.Data
{
    /// <summary>
    /// Класс для выполнения запросов в БД
    /// </summary>
    public static class DataBase
    {
        /// <summary>
        /// Строка подключения к БД. Сервер находится в локальной сети, поэтому в настройки не вынесено. Надеюсь не страшно )
        /// </summary>
        const string connString = "Server=127.0.0.1;Port=5432;User Id=backenduser;Password=Qwerty123;Database=demhack3;CommandTimeOut=5000";

        /// <summary>
        /// Тестовый метод, который планируется убрать или поменять
        /// </summary>
        /// <returns></returns>
        public static int LogCount()
        {
            var count = 0;
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    count = db.ParsingRequests.Count();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(5, ex.Message);
            }

            return count;
        }

        /// <summary>
        /// Получить список регионов
        /// </summary>
        /// <returns></returns>
        public static List<Region> GetRegions()
        {
            var result = new List<Region>();
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    result = db.Regions.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(1, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Получить список веб-порталов для парсинга
        /// </summary>
        /// <returns></returns>
        public static List<Portal> GetPortals()
        {
            var result = new List<Portal>();
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    result = db.Portals.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(2, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Метод создания нового задания парсинга данных
        /// </summary>
        /// <param name="parsingRequest"></param>
        public static void CreateJob(ParsingRequest parsingRequest)
        {
            try
            {
                // создаем новое задание
                var job = new ParsingJob()
                {
                    Id = parsingRequest.Id,
                    PortalId = parsingRequest.PortalId,
                    Time = DateTime.Now,
                    TimeFrom = parsingRequest.TimeFrom,
                    TimeTo = parsingRequest.TimeTo
                };

                // запись задания в БД
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    db.ParsingJobs.Add(job);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(4, ex.Message);
            }
        }

        /// <summary>
        /// Метод получения всех задач в БД
        /// </summary>
        /// <returns></returns>
        public static List<ParsingJob> GetJobs()
        {
            var result = new List<ParsingJob>();
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    result = db.ParsingJobs.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(2, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Метод получения задачи по ее Id
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static ParsingJob GetJobById(string guid)
        {
            ParsingJob result = null;
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    result = db.ParsingJobs.SingleOrDefault(j => j.Id == guid);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(6, ex.Message);
            }

            return result;
        }
    }
}
