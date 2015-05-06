using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article_Num
    {
        public int ArticleID { get; set; }
        public Nullable<byte> CategoryID { get; set; }
        public Nullable<int> PostUserID { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<System.DateTime> PostTime { get; set; }
        public Nullable<int> ReadNum { get; set; }
        public Nullable<int> LikNum { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
