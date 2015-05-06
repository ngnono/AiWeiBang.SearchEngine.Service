using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Account
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string WeiboID { get; set; }
        public string Gender { get; set; }
        public string Wechat { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string QQ { get; set; }
        public string AvatarUrl { get; set; }
        public string AvatarLocalID { get; set; }
        public Nullable<System.DateTime> SignupTime { get; set; }
    }
}
