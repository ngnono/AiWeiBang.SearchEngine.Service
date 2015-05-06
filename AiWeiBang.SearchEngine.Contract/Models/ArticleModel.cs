using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AiWeiBang.SearchEngine.Contract.Models
{
    /// <summary>
    /// 文章DTO
    /// </summary>
    public class ArticleModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id
        {
            get { return ArticleID; }
            set { ArticleID = value; }
        }

        [JsonProperty(PropertyName = ContantFields.ArticleId)]
        public int ArticleID { get; set; }

        [JsonProperty(PropertyName = "article_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ArticleTitle { get; set; }

        [JsonProperty(PropertyName = "summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "source_url", NullValueHandling = NullValueHandling.Ignore)]
        public string Sourceurl { get; set; }

        [JsonProperty(PropertyName = "media_url", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaUrl { get; set; }

        [JsonProperty(PropertyName = "media_local", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaLocal { get; set; }

        [JsonProperty(PropertyName = "media_local_tumb", NullValueHandling = NullValueHandling.Ignore)]
        public string MedialLocalTumb { get; set; }

        [JsonProperty(PropertyName = ContantFields.PostDate, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public Nullable<DateTime> PostDate { get; set; }

        [JsonProperty(PropertyName = ContantFields.PostTime, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public Nullable<DateTime> PostTime { get; set; }

        [JsonProperty(PropertyName = ContantFields.PostUserId, NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<int> PostUserID { get; set; }

        [JsonProperty(PropertyName = "post_user_ext")]
        public string PostUserExt { get; set; }

        [JsonProperty(PropertyName = "msg_type", NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<byte> MsgType { get; set; }

        [JsonProperty(PropertyName = "src_url")]
        public string SrcUrl { get; set; }

        [JsonProperty(PropertyName = "category_id", NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<int> CategoryID_ { get; set; }

        [JsonProperty(PropertyName = "wechat_biz")]
        public string WechatBiz_ { get; set; }

        [JsonProperty(PropertyName = ContantFields.RecordTime)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime RecordTime { get; set; }

        [JsonProperty(PropertyName = "sort_index")]
        public short SortIndex { get; set; }

        [JsonProperty(PropertyName = ContantFields.Enabled)]
        public bool Enabled { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public int Hits { get; set; }

        [JsonProperty(PropertyName = "show_cover_pic", NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<bool> ShowCoverPic { get; set; }

        [JsonProperty(PropertyName = "article_index", NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<byte> ArticleIndex { get; set; }

        //articleNum
        [JsonProperty(PropertyName = ContantFields.ReadNum, NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<int> ReadNum { get; set; }

        [JsonProperty(PropertyName = ContantFields.LikeNum, NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<int> LikNum { get; set; }

        [JsonProperty(PropertyName = "num_update_time", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public Nullable<DateTime> NumUpdateTime { get; set; }

        /// <summary>
        /// content
        /// </summary>
        [JsonProperty(PropertyName = ContantFields.Content, NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// 最后索引时间
        /// </summary>
        [JsonProperty(PropertyName = "last_index_datetime", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public Nullable<DateTime> LastIndexDateTime { get; set; }
    }
}