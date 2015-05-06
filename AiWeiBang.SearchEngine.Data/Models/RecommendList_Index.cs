using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class RecommendList_Index
    {
        public int ListID { get; set; }
        public byte SortIndex { get; set; }
        public System.DateTime BeginTime { get; set; }
        public System.DateTime EndTime { get; set; }
    }
}
