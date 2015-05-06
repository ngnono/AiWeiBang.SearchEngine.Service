using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Contract
{
    public class Must
    {
        /// <summary>
        /// 值等查询 相当于 sql  field = value
        /// </summary>
        [JsonProperty(PropertyName = "terms", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Terms { get; set; }

        /// <summary>
        /// 范围查询 相当于 sql data 大于 小于
        /// </summary>
        [JsonProperty(PropertyName = "range", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Range<object>> Range { get; set; }
    }
}