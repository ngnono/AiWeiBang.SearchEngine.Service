using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class CrawlMap
    {
        public int ArticleID { get; set; }
        public string WechatBiz { get; set; }
        public string AppmsgID { get; set; }
        public int ItemIdx { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
