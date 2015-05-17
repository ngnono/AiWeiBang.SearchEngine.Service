using System.Net;
using System.Net.Http;
using log4net;

namespace AiWeiBang.SearchEngine.ApiClient
{
    public static class HttpResponseMessageExtension
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(HttpResponseMessageExtension));
        public static bool VerificationResponse(this HttpResponseMessage response)
        {
            var i = (int) response.StatusCode;
            if (i >= 200 && i < 300)
            {
                return true;
            }

            //201
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }

            //204
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            //200

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            var rst = response.Content.ReadAsStringAsync().Result;

            Log.Error(rst);

            return false;
        }
    }
}