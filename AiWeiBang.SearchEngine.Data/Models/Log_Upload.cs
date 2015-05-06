using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Log_Upload
    {
        public int LogID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Action { get; set; }
        public string Image { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
