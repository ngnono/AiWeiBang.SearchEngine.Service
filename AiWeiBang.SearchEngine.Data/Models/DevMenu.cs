using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class DevMenu
    {
        public int MenuID { get; set; }
        public string ButtonName { get; set; }
        public byte Type { get; set; }
        public string KeyValue { get; set; }
        public short SortIndex { get; set; }
        public int ParentMenuID { get; set; }
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
