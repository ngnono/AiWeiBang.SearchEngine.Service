using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class DevReceiveLog
    {
        public long LogID { get; set; }
        public int UserID { get; set; }
        public string FromUserName { get; set; }
        public string MsgType { get; set; }
        public string Content { get; set; }
        public Nullable<long> MsgID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
