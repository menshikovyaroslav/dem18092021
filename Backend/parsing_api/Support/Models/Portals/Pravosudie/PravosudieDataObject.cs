using System.Collections.Generic;

namespace Support.Models.Portals.Pravosudie
{
    /// <summary>
    /// Корневой элемент объекта данных Post-запроса
    /// </summary>
    public class PravosudieRoot
    {
        public PravosudieRoot()
        {
            request = new PravosudieDataObject();
        }

        public PravosudieDataObject request { get; set; }
        public bool doNotSaveHistory { get; set; }
    }

    public class PravosudieQueryRequest
    {
        public string type { get; set; }
        public string request { get; set; }
        public string @operator { get; set; }
        public string queryRequestRole { get; set; }
    }

    public class PravosudieMultiqueryRequest
    {
        public PravosudieMultiqueryRequest()
        {
            queryRequests = new List<PravosudieQueryRequest>();
        }

        public List<PravosudieQueryRequest> queryRequests { get; set; }
    }

    public class PravosudieSort
    {
        public string field { get; set; }
        public string order { get; set; }
    }

    public class PravosudieFacet
    {
        public PravosudieFacet()
        {
            field = new List<string>();
        }

        public List<string> field { get; set; }
    }

    public class PravosudieDataObject
    {
        public PravosudieDataObject()
        {
            multiqueryRequest = new PravosudieMultiqueryRequest();
            sorts = new List<PravosudieSort>();
            facet = new PravosudieFacet();
            additionalFields = new List<string>();
        }

        public string type { get; set; }
        public PravosudieMultiqueryRequest multiqueryRequest { get; set; }
        public List<PravosudieSort> sorts { get; set; }
        public string simpleSearchFieldsBundle { get; set; }
        public int start { get; set; }
        public int rows { get; set; }
        public string uid { get; set; }
        public bool noOrpho { get; set; }
        public PravosudieFacet facet { get; set; }
        public int facetLimit { get; set; }
        public List<string> additionalFields { get; set; }
        public int hlFragSize { get; set; }
        public int groupLimit { get; set; }
        public bool woBoost { get; set; }
    }
}
