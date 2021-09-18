using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Models.Portals
{
    /// <summary>
    /// Веб-портал ГАС Правосудие
    /// https://bsr.sudrf.ru/
    /// </summary>
    public class PravosudiePortal : IPortal
    {
        public string GetHtml(ParsingRequest parsingRequest)
        {
            throw new NotImplementedException();
        }

        public ParsingResponse ParseHtml(string html)
        {
            throw new NotImplementedException();
        }
    }
}
