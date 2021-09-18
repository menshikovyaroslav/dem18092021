namespace parsing_api.Models.Portals
{
    /// <summary>
    /// Интерфейс объекта веб-портала
    /// </summary>
    public interface IPortal
    {
        /// <summary>
        /// Метод получения HTML от веб-портала 
        /// </summary>
        /// <param name="parsingRequest"></param>
        /// <param name="clause"></param>
        /// <returns></returns>
        public string GetHtml(ParsingRequest parsingRequest, int clause);

        /// <summary>
        /// Парсинг полученного HTML портала
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public ParsingResponse ParseHtml(string html);
    }
}
