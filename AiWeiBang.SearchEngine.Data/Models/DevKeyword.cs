using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class DevKeyword
    {
        public int KeywordID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Keyword { get; set; }
        public Nullable<byte> ReplyType { get; set; }
        public string ReplyContent { get; set; }
        public Nullable<bool> ModeSwitch { get; set; }
        public Nullable<int> AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
