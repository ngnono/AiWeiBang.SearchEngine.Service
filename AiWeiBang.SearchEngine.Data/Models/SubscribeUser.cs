using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class SubscribeUser
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> RecordTime { get; set; }
    }
}
