using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class CrawlUrl
    {
        public long UrlID { get; set; }
        public string WechatBiz { get; set; }
        public string ParamUin { get; set; }
        public string ParamKey { get; set; }
        public string SrcUrl { get; set; }
        public short Type { get; set; }
        public System.DateTime RecordTime { get; set; }
        public Nullable<System.DateTime> CrawlTime { get; set; }
        public int Status { get; set; }
    }
}
