using Microsoft.EntityFrameworkCore;
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
    }
}
