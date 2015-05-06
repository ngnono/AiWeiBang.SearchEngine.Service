using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class DevToken
    {
        public int UserID { get; set; }
        public string AppId { get; set; }
        public string Secret { get; set; }
        public string Token { get; set; }
        public Nullable<System.DateTime> ExpiresTime { get; set; }
        public int AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
