using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class AccountFansStatu
    {
        public int WeibangFansID { get; set; }
        public string NickName { get; set; }
        public Nullable<byte> SubStatus { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
