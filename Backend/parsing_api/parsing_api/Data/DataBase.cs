﻿using Microsoft.EntityFrameworkCore;
using parsing_api.Classes;
using parsing_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Data
{
    public static class DataBase
    {
        const string connString = "Server=127.0.0.1;Port=5432;User Id=backenduser;Password=Qwerty123;Database=demhack3;CommandTimeOut=5000";

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
                Classes.Log.Instance.Info(ex.Message);
            }

            return count;
        }

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
                Classes.Log.Instance.Error(1, ex.Message);
            }

            return result;
        }

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
                Classes.Log.Instance.Error(2, ex.Message);
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
                Classes.Log.Instance.Error(4, ex.Message);
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
                Classes.Log.Instance.Error(2, ex.Message);
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
                Classes.Log.Instance.Error(2, ex.Message);
            }

            return result;
        }
    }
}
