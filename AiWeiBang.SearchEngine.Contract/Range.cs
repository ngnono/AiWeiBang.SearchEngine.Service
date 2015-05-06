using Newtonsoft.Json;

namespace AiWeiBang.SearchEngine.Contract
{
    /// <summary>
    /// 范围查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Range<T> where T : new()
    {
        /// <summary>
        /// 小于等于
        /// </summary>
        [JsonProperty(PropertyName = "lte", NullValueHandling = NullValueHandling.Ignore)]
        public T Lte { get; set; }

        /// <summary>
        /// 小于
        /// </summary>
        [JsonProperty(PropertyName = "lt", NullValueHandling = NullValueHandling.Ignore)]
        public T Lt { get; set; }

        /// <summary>
        /// 大于等于
        /// </summary>
        [JsonProperty(PropertyName = "gte", NullValueHandling = NullValueHandling.Ignore)]
        public T Gte { get; set; }

        /// <summary>
        /// 大于
        /// </summary>
        [JsonProperty(PropertyName = "gt", NullValueHandling = NullValueHandling.Ignore)]
        public T Gt { get; set; }
    }
}
