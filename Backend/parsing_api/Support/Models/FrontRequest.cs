using System;

namespace Support.Models
{
    /// <summary>
    /// Объект данных от frontend-части в API
    /// </summary>
    public class FrontRequest
    {
        /// <summary>
        /// Номер кейса в БД
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Номер дела
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public int Region { get; set; }

        /// <summary>
        /// Дата начала поиска
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Дата конца поиска
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Название суда
        /// </summary>
        public string Sud { get; set; }

        /// <summary>
        /// Статья
        /// </summary>
        public string Clause { get; set; }

        /// <summary>
        /// Инстанция
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// ФИО подсудимого
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// ФИО судьи
        /// </summary>
        public string Judge { get; set; }
    }
}
