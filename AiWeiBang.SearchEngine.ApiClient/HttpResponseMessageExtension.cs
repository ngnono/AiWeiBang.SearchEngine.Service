using System.Net;
using System.Net.Http;

namespace AiWeiBang.SearchEngine.ApiClient
{
    public static class HttpResponseMessageExtension
    {
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
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}