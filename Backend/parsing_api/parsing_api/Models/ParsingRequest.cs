using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace parsing_api.Models
{
    /// <summary>
    /// Модель запроса парсинга данных
    /// </summary>
    public class ParsingRequest
    {
        /// <summary>
        /// Id запроса
        /// </summary>
        [Column(TypeName = "Guid")]
        public string Id { get; set; }

        /// <summary>
        /// Id веб-портала
        /// </summary>
        public int PortalId { get; set; }

        /// <summary>
        /// Дата начала парсинга
        /// </summary>
        public DateTime TimeFrom { get; set; }

        /// <summary>
        /// Дата конца парсинга
        /// </summary>
        public DateTime TimeTo { get; set; }
    }
}
