using System.ComponentModel.DataAnnotations.Schema;

namespace parsing_api.Models
{
    /// <summary>
    /// Модель объекта веб-портала для парсинга
    /// </summary>
    [Table("portals")]
    public class Portal
    {
        /// <summary>
        /// Id веб-портала
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Имя веб-портала (название, описание)
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на веб-портал
        /// </summary>
        [Column("link")]
        public string Link { get; set; }
    }
}
