using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Contract
{
    public class Result<T>
    {
        [JsonProperty(PropertyName = "status")]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "code")]
        public int StatusCode { get; set; }

        /// <summary>
        /// 一般只有 status = false 时 才会有信息
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}