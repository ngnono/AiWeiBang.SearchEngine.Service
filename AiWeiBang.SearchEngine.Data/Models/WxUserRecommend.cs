using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WxUserRecommend
    {
        public System.DateTime RecommendDate { get; set; }
        public int UserID { get; set; }
        public int Coin { get; set; }
        public string Introduction { get; set; }
        public int AccountID { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
