using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Models
{
    public class ParsingResponse
    {
        /// <summary>
        /// Id записи в БД
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime DateIn { get; set; }

        /// <summary>
        /// Дата рассмотрения
        /// </summary>
        public DateTime DateCheck { get; set; }

        /// <summary>
        /// Суд
        /// </summary>
        public string Sud { get; set; }

        /// <summary>
        /// Статьи
        /// </summary>
        public string Clause { get; set; }

        /// <summary>
        /// Решение
        /// </summary>
        public string Decision { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Инстанция
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Ссылка на сайте суда
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Дата апелляции
        /// </summary>
        public string DateAppeal { get; set; }

        /// <summary>
        /// Пол ответчиков
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Пол ответчиков
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Судья
        /// </summary>
        public string Judge { get; set; }

        /// <summary>
        /// Номер дела в суде
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Текст решения
        /// </summary>
        public string DecisionText { get; set; }
    }
}
