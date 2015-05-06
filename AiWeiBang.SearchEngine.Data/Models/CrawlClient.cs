using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class CrawlClient
    {
        public int CID { get; set; }
        public string ClientID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
