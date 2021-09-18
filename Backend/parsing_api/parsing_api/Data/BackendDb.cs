using Microsoft.EntityFrameworkCore;
using parsing_api.Models;

namespace parsing_api.Data
{
    /// <summary>
    /// Контест для работы с БД
    /// </summary>
    public class BackendDb : DbContext
    {
        /// <summary>
        /// Данные запросов парсинга
        /// </summary>
        public DbSet<ParsingRequest> ParsingRequests { get; set; }

        /// <summary>
        /// Таблица регионов страны
        /// </summary>
        public DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Таблица веб-порталов для парсинга
        /// </summary>
        public DbSet<Portal> Portals { get; set; }

        /// <summary>
        /// Данные запросов на парсинг
        /// </summary>
        public DbSet<ParsingJob> ParsingJobs { get; set; }

        /// <summary>
        /// Инициализация контекста работы с БД
        /// </summary>
        /// <param name="options"></param>
        public BackendDb(DbContextOptions<BackendDb> options) : base(options) { }
    }
}
