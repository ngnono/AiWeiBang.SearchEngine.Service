using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class DevSetting
    {
        public int UserID { get; set; }
        public byte WelcomeType { get; set; }
        public string WelcomeContent { get; set; }
        public byte ReplyType { get; set; }
        public string ReplyContent { get; set; }
        public Nullable<int> AccountID { get; set; }
        public bool MatchArticleKeyword { get; set; }
        public bool MatchArticleContent { get; set; }
        public bool MatchArticlePostdate { get; set; }
    }
}
