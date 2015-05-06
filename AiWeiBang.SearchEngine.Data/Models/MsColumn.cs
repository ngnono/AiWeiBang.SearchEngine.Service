using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class MsColumn
    {
        public int ColumnID { get; set; }
        public string ColumnName { get; set; }
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public byte SortIndex { get; set; }
        public byte ViewStatus { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
