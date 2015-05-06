using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class AccountFeed
    {
        public int FeedID { get; set; }
        public byte FeedType { get; set; }
        public string FeedContent { get; set; }
        public int AccountID { get; set; }
        public Nullable<int> RelID { get; set; }
        public string RefererUrl { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
