using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article_Recommend
    {
        public int ArticleID { get; set; }
        public int ClassID { get; set; }
        public int SortIndex { get; set; }
        public System.DateTime PostDate { get; set; }
    }
}
