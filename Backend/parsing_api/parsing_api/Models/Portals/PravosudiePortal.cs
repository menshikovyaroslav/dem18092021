namespace parsing_api.Models.Portals
{
    /// <summary>
    /// Веб-портал ГАС Правосудие
    /// https://bsr.sudrf.ru/
    /// </summary>
    public class PravosudiePortal : IPortal
    {
        /// <summary>
        /// Получить HTML-код
        /// </summary>
        /// <param name="parsingRequest"></param>
        /// <returns></returns>
        public string GetHtml(ParsingRequest parsingRequest)
        {
            return "";
        }

        /// <summary>
        /// Парсинг HTML-кода в объект ParsingResponse
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public ParsingResponse ParseHtml(string html)
        {
            return new ParsingResponse();
        }
    }
}
