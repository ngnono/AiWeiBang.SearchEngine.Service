using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article_Tag
    {
        public long TagID { get; set; }
        public int ArticleID { get; set; }
        public string Tag { get; set; }
    }
}
