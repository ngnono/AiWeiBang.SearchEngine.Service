using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class VerifyCode
    {
        public string Code { get; set; }
        public string WechatID { get; set; }
        public int UpperLimit { get; set; }
        public System.DateTime GenDatetime { get; set; }
        public bool Used { get; set; }
        public Nullable<System.DateTime> UseDateTime { get; set; }
    }
}
