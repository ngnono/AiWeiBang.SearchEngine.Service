using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Contract
{
    public class Sort
    {
        [JsonProperty(PropertyName = "field")]
        public string FieldName { get; set; }

        [JsonProperty(PropertyName = "params", NullValueHandling = NullValueHandling.Ignore)]
        public object Params { get; set; }
    }
}