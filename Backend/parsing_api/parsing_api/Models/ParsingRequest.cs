using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
