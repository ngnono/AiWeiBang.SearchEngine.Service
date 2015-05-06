using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WebApp_Elements
    {
        public int ElementID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string ElementName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public Nullable<int> SortIndex { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<byte> ViewStatus { get; set; }
        public Nullable<System.DateTime> RecordTime { get; set; }
    }
}
