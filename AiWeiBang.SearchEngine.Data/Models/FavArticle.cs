using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class FavArticle
    {
        public int AccountID { get; set; }
        public int ArticleID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
