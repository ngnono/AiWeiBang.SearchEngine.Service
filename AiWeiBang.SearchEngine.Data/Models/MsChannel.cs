using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class MsChannel
    {
        public int ChannelID { get; set; }
        public string ChannelName { get; set; }
        public string Url { get; set; }
        public byte SortIndex { get; set; }
        public Nullable<int> ExtType { get; set; }
        public string ExtID { get; set; }
        public byte ViewStatus { get; set; }
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
