using parsing_api.Data;
using parsing_api.Models;
using parsing_api.Models.Portals;
using parsing_api.Models.Portals.Pravosudie;

namespace parsing_api.Classes
{
    /// <summary>
    /// Класс для обработки задач парсинга данных
    /// </summary>
    public static class ParsingFactory
    {
        /// <summary>
        /// Метод инициализации парсинга данных
        /// </summary>
        /// <param name="parsingRequest"></param>
        public static void Parse(ParsingRequest parsingRequest)
        {
            var portal = GetPortal(parsingRequest.PortalId);
            if (portal == null)
            {
                Log.Instance.Error(3, "Портал не прописан в методе GetPortal !");
                return;
            }

            // создадим новую задачу парсинга
            DataBase.CreateJob(parsingRequest);

            // получить HTML-код веб-портала
            var html = portal.GetHtml(parsingRequest);

            // парсинг HTML кода в красивый универсальный объект
            var parsingResponse = portal.ParseHtml(html);
        }

        /// <summary>
        /// Вернуть объект портала по его Id
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        private static IPortal GetPortal(int portalId)
        {
            switch (portalId)
            {
                case 1: return new PravosudiePortal();
            }

            return null;
        }
    }
}
