using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class AccountValidateCode
    {
        public int AccountID { get; set; }
        public Nullable<int> ValidateCode { get; set; }
        public Nullable<System.DateTime> RecordTime { get; set; }
    }
}
