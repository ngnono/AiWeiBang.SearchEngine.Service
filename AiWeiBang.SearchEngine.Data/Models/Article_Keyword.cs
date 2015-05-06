using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article_Keyword
    {
        public int ArticleID { get; set; }
        public string Keyword { get; set; }
        public int PostUserID { get; set; }
    }
}
