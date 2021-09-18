using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace parsing_api.Models
{
    /// <summary>
    /// Модель задачи парсинга данных
    /// </summary>
    [Table("parsingjobs")]
    public class ParsingJob
    {
        /// <summary>
        /// Id в форме Guid задачи
        /// </summary>
        [Column("id")]
        public string Id { get; set; }

        /// <summary>
        /// Id веб-портала для задачи
        /// </summary>
        [Column("portalid")]
        public int PortalId { get; set; }

        /// <summary>
        /// Текущий код выполнения задачи парсинга
        /// 0 - задача создана
        /// 1 - задача выполнена
        /// </summary>
        [Column("resultcode")]
        public int ResultCode { get; set; }

        /// <summary>
        /// Время запуска задачи
        /// </summary>
        [Column("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Время начала даты
        /// </summary>
        [Column("timefrom")]
        public DateTime TimeFrom { get; set; }

        /// <summary>
        /// Время конца даты
        /// </summary>
        [Column("timeto")]
        public DateTime TimeTo { get; set; }

        /// <summary>
        /// Текст ошибки выполнения задачи (если произошла ошибка)
        /// </summary>
        [Column("error")]
        public string Error { get; set; }
    }
}
