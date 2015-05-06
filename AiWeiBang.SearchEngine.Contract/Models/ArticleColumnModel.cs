using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AiWeiBang.SearchEngine.Contract.Models
{
    /// <summary>
    /// 文章自定义列
    /// </summary>
    public class ArticleColumnModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get
            {
                return String.Format("{0}_{1}", ArticleId.ToString(CultureInfo.InvariantCulture), ColumnId.ToString(CultureInfo.InvariantCulture));
            }
            set { }
        }

        [JsonProperty(PropertyName = "article_id")]
        public int ArticleId { get; set; }

        [JsonProperty(PropertyName = "column_id")]
        public int ColumnId { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }

        /// <summary>
        /// 最后索引时间
        /// </summary>
        [JsonProperty(PropertyName = "last_index_datetime", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public Nullable<DateTime> LastIndexDateTime { get; set; }
    }
}