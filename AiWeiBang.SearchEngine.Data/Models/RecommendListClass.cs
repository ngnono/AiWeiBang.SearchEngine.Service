using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class RecommendListClass
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public Nullable<int> ListID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<byte> SortIndex { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
