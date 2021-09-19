using Microsoft.EntityFrameworkCore;
using Support;
using Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PravosudieParser.Data
{
    /// <summary>
    /// Класс для выполнения запросов в БД
    /// </summary>
    public static class DataBase
    {
        /// <summary>
        /// Строка подключения к БД. Строка подключения из настроек приложения.
        /// </summary>
        private static string connString = Properties.Settings.Default.connectionString;

        /// <summary>
        /// Запись в БД нового кейса
        /// </summary>
        /// <param name="parsingResponse"></param>
        public static void CreateCase(ParsingResponse parsingResponse)
        {
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    // проверяем в БД есть ли запись с номером этого дела
                    var findDoubleCase = db.ParsingResponses.SingleOrDefault(o => o.Number == parsingResponse.Number);

                    // если в БД нет такой записи, то добавим
                    if (findDoubleCase == null)
                    {
                        db.ParsingResponses.Add(parsingResponse);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(4, ex.Message);
            }
        }

        /// <summary>
        /// Получить Id региона по его имени
        /// </summary>
        /// <returns></returns>
        public static int GetRegionIdByName(string name)
        {
            int result = 0;
            var length = name.Length / 2;
            try
            {
                using (var db = new BackendDb(new DbContextOptionsBuilder<BackendDb>().UseNpgsql(connString).Options))
                {
                    result = db.Regions.SingleOrDefault(r => r.Name.ToLower() == name.ToLower() || (r.Aliases != null && r.Aliases.Contains(name))).Id;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(1, ex.Message);
            }

            return result;
        }
    }
}
