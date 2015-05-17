using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AiWeiBang.SearchEngine.Dtos
{
    /// <summary>
    /// JOB 上下文模型
    /// </summary>
    public class JobHistoryContextModel
    {
        /// <summary>
        /// JOB KEY
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// 上下文参数
        /// </summary>
        [JsonProperty(PropertyName = "context", NullValueHandling = NullValueHandling.Ignore)]
        public string Context { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [JsonProperty(PropertyName = "update_dt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdateDateTime { get; set; }
    }
}
