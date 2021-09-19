using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Support.Models
{
    /// <summary>
    /// Данные парсинга по делу - объект возвращаемого результата пользователю
    /// </summary>
    [Table("cases")]
    public class ParsingResponse
    {
        /// <summary>
        /// Id записи в БД
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Дата поступления
        /// </summary>
        [Column("date_in")]
        public DateTime DateIn { get; set; }

        /// <summary>
        /// Дата рассмотрения
        /// </summary>
        [Column("date_check")]
        public DateTime DateCheck { get; set; }

        /// <summary>
        /// Суд
        /// </summary>
        [Column("sud")]
        public string Sud { get; set; }

        /// <summary>
        /// Статьи
        /// </summary>
        [Column("clause")]
        public string Clause { get; set; }

        /// <summary>
        /// Решение
        /// </summary>
        [Column("decision")]
        public string Decision { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        [Column("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        [Column("region")]
        public int Region { get; set; }

        /// <summary>
        /// Инстанция
        /// </summary>
        [Column("instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Ссылка на сайте суда
        /// </summary>
        [Column("link")]
        public string Link { get; set; }

        /// <summary>
        /// Дата апелляции
        /// </summary>
        [Column("date_appeal")]
        public DateTime DateAppeal { get; set; }

        /// <summary>
        /// Пол ответчиков
        /// </summary>
        [Column("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Судья
        /// </summary>
        [Column("judge")]
        public string Judge { get; set; }

        /// <summary>
        /// Номер дела в суде
        /// </summary>
        [Column("number")]
        public string Number { get; set; }

        /// <summary>
        /// Текст решения
        /// </summary>
        [Column("decision_text")]
        public string DecisionText { get; set; }

        /// <summary>
        /// ФИО подсудимого
        /// </summary>
        [Column("fio")]
        public string Fio { get; set; }
    }
}
