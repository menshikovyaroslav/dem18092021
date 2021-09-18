using Microsoft.EntityFrameworkCore;
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
                    count = db.ParsingObjects.Count();
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
    }
}
