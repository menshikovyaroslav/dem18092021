using Request.Support;
using Support.Request;
using System;
using System.Net;

namespace Support.Models.Portals.Pravosudie
{
    /// <summary>
    /// Веб-портал ГАС Правосудие
    /// https://bsr.sudrf.ru/
    /// </summary>
    public class NskDzer1Portal : IPortal
    {
        /// <summary>
        /// Получить HTML-код
        /// </summary>
        /// <param name="parsingRequest"></param>
        /// <returns></returns>
        public string GetHtml(ParsingRequest parsingRequest, int clause)
        {
            var clauseString = string.Empty;
            switch (clause)
            {
                case 137:
                    clauseString = "137";
                    break;
                case 138:
                    clauseString = "138";
                    break;
                case 272:
                    clauseString = "272";
                    break;
                case 274:
                    clauseString = "274";
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(clauseString))
            {
                return clauseString;
            }

            var dataObject = new PravosudieRoot();

            #region неинтересное наполнение объекта POST-запроса

            dataObject.request.type = "MULTIQUERY";
            dataObject.request.multiqueryRequest.queryRequests.Add(new PravosudieQueryRequest()
            {
                type = "Q",
                // видимо ошибка строки json на портале, поэтому вручную внесу это значение
                request = $"{{\"mode\":\"EXTENDED\",\"typeRequests\":[{{\"fieldRequests\":[{{\"name\":\"case_user_doc_entry_date\",\"operator\":\"B\",\"query\":\"{parsingRequest.TimeFrom.ToString("s")}\",\"sQuery\":\"{parsingRequest.TimeTo.ToString("s")}\",\"fieldName\":\"case_user_doc_entry_date\"}},{{\"name\":\"case_document_category_article_cat\",\"operator\":\"SEW\",\"query\":\"{clauseString}\",\"fieldName\":\"case_document_category_article_cat\"}}],\"mode\":\"AND\",\"name\":\"common\",\"typesMode\":\"AND\"}}]}}",
                @operator = "AND",
                queryRequestRole = "CATEGORIES"
            });
            dataObject.request.sorts.Add(new PravosudieSort()
            {
                field = "score",
                order = "desc"
            });
            dataObject.request.simpleSearchFieldsBundle = "default";
            dataObject.request.start = 0;
            dataObject.request.rows = 10;
            dataObject.request.uid = Guid.NewGuid().ToString();
            dataObject.request.noOrpho = false;
            dataObject.request.facet = new PravosudieFacet()
            {
                field = new System.Collections.Generic.List<string>() { "type" }
            };
            dataObject.request.facetLimit = 21;
            dataObject.request.additionalFields.Add("court_document_documentype1");
            dataObject.request.additionalFields.Add("court_case_entry_date");
            dataObject.request.additionalFields.Add("court_case_result_date");
            dataObject.request.additionalFields.Add("court_subject_rf");
            dataObject.request.additionalFields.Add("court_name_court");
            dataObject.request.additionalFields.Add("court_document_law_article");
            dataObject.request.additionalFields.Add("court_case_result");
            dataObject.request.additionalFields.Add("case_user_document_type");
            dataObject.request.additionalFields.Add("case_user_doc_entry_date");
            dataObject.request.additionalFields.Add("case_user_doc_result_date");
            dataObject.request.additionalFields.Add("case_doc_subject_rf");
            dataObject.request.additionalFields.Add("case_user_doc_court");
            dataObject.request.additionalFields.Add("case_doc_instance");
            dataObject.request.additionalFields.Add("case_document_category_article");
            dataObject.request.additionalFields.Add("case_user_doc_result");
            dataObject.request.additionalFields.Add("case_user_entry_date");
            dataObject.request.additionalFields.Add("m_case_user_type");
            dataObject.request.additionalFields.Add("m_case_user_sub_type");
            dataObject.request.additionalFields.Add("ora_main_law_article");

            dataObject.request.hlFragSize = 1000;
            dataObject.request.groupLimit = 3;
            dataObject.request.woBoost = false;
            dataObject.doNotSaveHistory = false;

            #endregion

            // Контейнер куки
            var cookieContainer = new CookieContainer();

            // Первое обращение к порталу, собираем куки
            var getRequest = new GetRequest()
            {
                Address = "https://bsr.sudrf.ru/bigs/portal.html",
                Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                Host = "bsr.sudrf.ru",
                TurnOffProxy = true,
                KeepAliveTrick = true
            };


            var postRequest = new PostRequest()
            {
                Data = dataObject.ToString(),
                Address = "https://bsr.sudrf.ru/bigs/s.action",
                Accept = "application/json, text/javascript, */*; q=0.01",
                Host = "bsr.sudrf.ru",
                ContentType = "application/json; charset=UTF-8",
                Referer = "https://bsr.sudrf.ru/bigs/portal.html",
                TurnOffProxy = true,
                KeepAliveTrick = true
            };
            postRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
            postRequest.AddHeader("X-Ajax-Token", "acc9d67db1b54c580a9bee0a8b06671b3a6e0aa5746c2f0da0923c39161ad22a");
            postRequest.AddHeader("Origin", "https://bsr.sudrf.ru");
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
