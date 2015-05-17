using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article_Num_Detail
    {
        public int DetailID { get; set; }
        public int ArticleID { get; set; }
        public int PostUserID { get; set; }
        public System.DateTime PostTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public int ReadNum { get; set; }
        public int LikeNum { get; set; }
        public short SpanHour { get; set; }
    }
}
