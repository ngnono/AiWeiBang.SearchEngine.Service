using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Log_AccountOperate
    {
        public long LogID { get; set; }
        public int AccountID { get; set; }
        public short BusiType { get; set; }
        public int BusiID { get; set; }
        public string LogIP { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
