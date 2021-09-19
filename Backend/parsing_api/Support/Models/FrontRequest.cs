namespace Support.Models
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
