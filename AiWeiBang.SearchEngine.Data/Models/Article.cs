using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string Summary { get; set; }
        public string Sourceurl { get; set; }
        public string MediaUrl { get; set; }
        public string MediaLocal { get; set; }
        public string MedialLocalTumb { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<System.DateTime> PostTime { get; set; }
        public Nullable<int> PostUserID { get; set; }
        public string PostUserExt { get; set; }
        public Nullable<byte> MsgType { get; set; }
        public string SrcUrl { get; set; }
        public Nullable<int> CategoryID_ { get; set; }
        public string WechatBiz_ { get; set; }
        public System.DateTime RecordTime { get; set; }
        public short SortIndex { get; set; }
        public bool Enabled { get; set; }
        public int Hits { get; set; }
        public Nullable<bool> ShowCoverPic { get; set; }
        public Nullable<byte> ArticleIndex { get; set; }
    }
}
