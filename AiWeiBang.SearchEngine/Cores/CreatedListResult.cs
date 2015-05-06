using System.Collections.Generic;
using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Cores
{
    public class CreatedListResult
    {
        [JsonProperty(PropertyName = "errors")]
        public bool Errors { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<CreatedItemsResult> Data { get; set; }

        [JsonProperty(PropertyName = "took")]
        public string Took { get; set; }
    }
}