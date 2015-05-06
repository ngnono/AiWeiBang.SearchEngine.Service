using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WebApp_Tags
    {
        public int TagID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string TagName { get; set; }
        public Nullable<byte> TagType { get; set; }
        public string Url { get; set; }
        public Nullable<byte> SortIndex { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<byte> ViewStatus { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
