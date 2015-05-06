using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Article_Pop
    {
        public Nullable<System.DateTime> PopDate { get; set; }
        public int ArticleID { get; set; }
        public int PostUserID { get; set; }
        public System.DateTime PostDate { get; set; }
        public Nullable<short> ReadRate { get; set; }
        public Nullable<short> LikeRate { get; set; }
        public Nullable<byte> ReadNumIndex { get; set; }
        public Nullable<int> PopIndex { get; set; }
        public Nullable<byte> SortIndex { get; set; }
    }
}
