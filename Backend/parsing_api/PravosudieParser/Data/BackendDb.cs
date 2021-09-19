using Microsoft.EntityFrameworkCore;
using Support.Models;

namespace PravosudieParser.Data
{
    /// <summary>
    /// Контест для работы с БД
    /// </summary>
    public class BackendDb : DbContext
    {
        /// <summary>
        /// Данные запросов парсинга
        /// </summary>
        public DbSet<ParsingResponse> ParsingResponses { get; set; }

        /// <summary>
        /// Инициализация контекста работы с БД
        /// </summary>
        /// <param name="options"></param>
        public BackendDb(DbContextOptions<BackendDb> options) : base(options) { }
    }
}
