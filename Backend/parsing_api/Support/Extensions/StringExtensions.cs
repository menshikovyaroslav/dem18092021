using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Проверка на пустую строку
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string x)
        {
            return string.IsNullOrEmpty(x);
        }
    }
}
