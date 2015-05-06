using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class RecommendListDetail
    {
        public int ListID { get; set; }
        public int UserID { get; set; }
        public short SortIndex { get; set; }
        public string Introduction { get; set; }
        public string FollowUrl { get; set; }
        public string ArticleUrl { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<System.DateTime> RecordTime { get; set; }
        public int ClickCount { get; set; }
    }
}
