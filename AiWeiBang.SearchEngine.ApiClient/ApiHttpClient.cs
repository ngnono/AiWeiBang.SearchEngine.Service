using System.Net.Http;

namespace AiWeiBang.SearchEngine.ApiClient
{
    public class ApiHttpClient : HttpClient
    {
        public ApiHttpClient()
            : base()
        {
        }

        public ApiHttpClient(HttpMessageHandler handler)
            : base(handler)
        {
        }
    }
}
