using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class AccountUserSetting
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public Nullable<byte> KindID { get; set; }
        public Nullable<byte> KindClassID { get; set; }
        public Nullable<byte> ProvinceID { get; set; }
        public Nullable<int> CityID { get; set; }
        public string Tags { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<bool> IsCheck { get; set; }
    }
}
