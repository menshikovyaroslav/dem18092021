namespace Support.Extensions
{
    /// <summary>
    /// Статический класс для расширения методов строки
    /// </summary>
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
