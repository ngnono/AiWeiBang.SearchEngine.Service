using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Contract
{
    /// <summary>
    /// 
    /// </summary>

    public class Should
    {
        [JsonProperty(PropertyName = "range", NullValueHandling = NullValueHandling.Ignore)]
        public List<Range<object>> Range { get; set; }

        [JsonProperty(PropertyName = "terms", NullValueHandling = NullValueHandling.Ignore)]
        public NameValueCollection Terms { get; set; }
    }
}