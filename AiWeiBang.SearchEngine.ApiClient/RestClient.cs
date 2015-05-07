using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using AiWeiBang.SearchEngine.Contract;
using log4net;

namespace AiWeiBang.SearchEngine.ApiClient
{
    /// <summary>
    ///     Class RestClient.
    /// </summary>
    public class RestClient
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(RestClient));

        //[UsedImplicitly]
        private static int _curStatuscode;

        public static int CurStatusCode
        {
            get { return _curStatuscode; }
        }

        /// <summary>
        ///     The base URL 静态
        /// </summary>
        private static ApiHttpClient _client;

        /// <summary>
        ///     Gets the client.
        /// </summary>
        /// <value>The client.</value>
        public static ApiHttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip };
                    _client = new ApiHttpClient(handler);
                }

                return _client;
            }
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public static IList<T> Get<T>(string address, string urlParams = "")
        {
            var url = String.Format("{0}?{1}&timestamp={2}", address, urlParams, GetTimeStamp());

            HttpResponseMessage response = Client.PostAsync(url, null).Result;
            _curStatuscode = (int)response.StatusCode;

            return response.VerificationResponse() ? response.Content.ReadAsAsync<List<T>>().Result : new List<T>();
        }

        public static PagingResult<T> GetPage<T>(string address, string urlParams)
        {
            string url = string.Format("{0}?{1}&timestamp={2}", address, urlParams, GetTimeStamp());
            HttpResponseMessage response = Client.PostAsync(url, null).Result;
            _curStatuscode = (int)response.StatusCode;
            return response.VerificationResponse()
                ? response.Content.ReadAsAsync<PagingResult<T>>().Result
                : new PagingResult<T>(null, 10);
        }

        public static PagingResult<T> Get<T>(string address, string urlParams, int pageIndex, int pageSize)
        {
            string url = string.Format("{0}?{1}&pageIndex={2}&pageSize={3}&timestamp={4}", address, urlParams, pageIndex, pageSize, GetTimeStamp());
            HttpResponseMessage response = Client.PostAsync(url, null).Result;
            _curStatuscode = (int)response.StatusCode;
            return response.VerificationResponse()
                ? response.Content.ReadAsAsync<PagingResult<T>>().Result
                : new PagingResult<T>(null, 10);
        }

        public static T GetItem<T>(string address, string urlParams = "")
        {
            var url = String.IsNullOrWhiteSpace(urlParams) ? address : string.Format("{0}?{1}&timestamp={2}", address, urlParams, GetTimeStamp());
            HttpResponseMessage response = Client.GetAsync(url).Result;
            _curStatuscode = (int)response.StatusCode;

            return response.VerificationResponse() ? response.Content.ReadAsAsync<T>().Result : default(T);
        }

        /// <summary>
        ///     Posts the specified URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Post<T>(string url, T data)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync(url, data).Result;
            _curStatuscode = (int)response.StatusCode;
            return response.VerificationResponse();
        }

        /// <summary>
        ///     Posts the specified URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns>``1.</returns>
        public static TResult Post<T, TResult>(string url, T data)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync(url, data).Result;
            Log.Debug(response);
            _curStatuscode = (int)response.StatusCode;
            return response.VerificationResponse() ? response.Content.ReadAsAsync<TResult>().Result : default(TResult);
        }


        /// <summary>
        ///     Puts the specified URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static TResult Put<T, TResult>(string url, T data)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync(url, data).Result;
            _curStatuscode = (int)response.StatusCode;

            return response.VerificationResponse() ? response.Content.ReadAsAsync<TResult>().Result : default(TResult);
        }

        public static T PostReturnModel<T>(string url, T data)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync(url, data).Result;
            _curStatuscode = (int)response.StatusCode;

            return response.VerificationResponse() ? response.Content.ReadAsAsync<T>().Result : default(T);
        }

        //public static bool Put(string url, object data)
        //{
        //    HttpResponseMessage response = Client.PutAsJsonAsync(url, data).Result;
        //    _curStatuscode = (int)response.StatusCode;

        //    return response.VerificationResponse();
        //}

        /// <summary>
        ///     Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Delete(string url)
        {
            HttpResponseMessage response = Client.DeleteAsync(url).Result;
            _curStatuscode = (int)response.StatusCode;

            return response.VerificationResponse();
        }

        private static string GetTimeStamp()
        {
            var st = new DateTime(1970, 1, 1);
            var t = (DateTime.Now.ToUniversalTime() - st);
            var retval = (Int64)(t.TotalMilliseconds + 0.5);

            return retval.ToString(CultureInfo.InvariantCulture);
        }
    }
}