using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class RecommendList
    {
        public int ListID { get; set; }
        public string ListName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Banner { get; set; }
        public Nullable<byte> SeriesID { get; set; }
        public bool ShowArticle { get; set; }
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string FootMemberName { get; set; }
        public Nullable<bool> FootArticleShow { get; set; }
        public string FootArticleName { get; set; }
        public string FootCustomName { get; set; }
        public string FootCustomUrl { get; set; }
        public Nullable<byte> FootCustomUrlViewStatus { get; set; }
        public System.DateTime RecordTime { get; set; }
        public int AccountCount { get; set; }
        public int ViewCount { get; set; }
        public Nullable<bool> IndexRandom { get; set; }
    }
}
