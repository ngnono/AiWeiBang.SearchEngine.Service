using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class CredentialWeibo
    {
        public Nullable<int> AccountID { get; set; }
        public string WeiboID { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Nullable<int> ExpiresIn { get; set; }
        public Nullable<System.DateTime> ExpiresTime { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
