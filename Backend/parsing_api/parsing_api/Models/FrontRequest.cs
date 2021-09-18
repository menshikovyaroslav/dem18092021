using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Models
{
    /// <summary>
    /// Объект данных от frontend-части в API
    /// </summary>
    public class FrontRequest
    {
        /// <summary>
        /// Номер дела
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public int Region { get; set; }
    }
}
