using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Cores
{
    public class CreatedItemsResult
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "_index")]
        public string Index { get; set; }

        [JsonProperty(PropertyName = "_type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "_version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}