using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class CrawlTime
    {
        public int UserID { get; set; }
        public Nullable<System.DateTime> CrawlLastTime { get; set; }
        public Nullable<byte> RetCode { get; set; }
        public string ClientID { get; set; }
    }
}
