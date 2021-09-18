using Support.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Text;

namespace Support.Request
{
    /// <summary>
    /// Метод реализации Post запроса
    /// </summary>
    public class PostRequest
    {
        #region private fields

        private const string _ie = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
        private HttpWebRequest _request;
        private Dictionary<string, string> _headers;

        #endregion

        #region public settings

        public bool NoCachePolicy { get; set; }
        public string Response { get; set; }
        public string ResponseEncoding { get; set; }
        public string Data { get; set; }
        public byte[] ByteData { get; set; }
        public string Address { get; set; }
        public string Accept { get; set; }
        public string Host { get; set; }
        public string ContentType { get; set; }
        public string Referer { get; set; }
        public bool KeepAlive { get; set; }
        public bool KeepAliveTrick { get; set; }
        public bool? Expect100Continue { get; set; }
        public string UserAgent { get; set; }
        public bool? AllowAutoRedirect { get; set; }
        public WebHeaderCollection ResponseHeaders { get; private set; }
        public WebHeaderCollection RequestHeaders { get; private set; }
        public WebProxy Proxy { get; set; }
        public bool TurnOffProxy { get; set; }
        public int TimeOut { get; set; }

        #endregion

        public PostRequest()
        {
            _headers = new Dictionary<string, string>();
        }

        // выполнить запрос
        public void Run(ref CookieContainer cookies)
        {
            _request = (HttpWebRequest)WebRequest.Create(Address);
            _request.Method = "POST";
            _request.Host = Host;
            _request.Headers.Add("DNT", "1");

            if (TurnOffProxy) _request.Proxy = null;
            else _request.Proxy = Proxy;

            if (TimeOut > 0)
            {
                _request.Timeout = TimeOut;
                _request.ReadWriteTimeout = TimeOut;
            }
            else
            {
                _request.Timeout = 90000;
                _request.ReadWriteTimeout = 90000;
            }

            var noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            _request.CachePolicy = noCachePolicy;

            if (Expect100Continue == true) _request.ServicePoint.Expect100Continue = true;
            else _request.ServicePoint.Expect100Continue = false;

            _request.ContentType = ContentType;
            _request.Accept = Accept;
            _request.Referer = Referer;

            _request.KeepAlive = KeepAlive;

            foreach (KeyValuePair<string, string> keyValuePair in _headers)
            {
                _request.Headers.Add(keyValuePair.Key, keyValuePair.Value);
            }

            _request.CookieContainer = cookies;

            if (UserAgent == null) _request.UserAgent = _ie;
            else _request.UserAgent = UserAgent;

            if (AllowAutoRedirect != null)
                _request.AllowAutoRedirect = (bool)AllowAutoRedirect;

            if (KeepAliveTrick)
            {
                var sp = _request.ServicePoint;
                var prop = sp.GetType().GetProperty("HttpBehaviour", BindingFlags.Instance | BindingFlags.NonPublic);
                prop.SetValue(sp, (byte)0, null);
            }

            byte[] sentData;
            if (ByteData != null) sentData = ByteData;
            else sentData = Encoding.UTF8.GetBytes(Data);

            _request.ContentLength = sentData.Length;
            Stream sendStream = _request.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            WebResponse response = _request.GetResponse();

            ResponseHeaders = response.Headers;
            RequestHeaders = _request.Headers;

            Stream stream = response.GetResponseStream();
            if (stream != null)
            {
                if (ResponseEncoding.IsEmpty()) Response = new StreamReader(stream).ReadToEnd();
                else Response = new StreamReader(stream, Encoding.GetEncoding(ResponseEncoding)).ReadToEnd();
            }
            response.Close();
        }

        // добавить дополнительный заголовок в запрос
        public void AddHeader(string headerName, string headerValue)
        {
            _headers[headerName] = headerValue;
        }
    }
}
