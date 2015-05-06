using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class CredentialMail
    {
        public Nullable<int> AccountID { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ValidationCode { get; set; }
        public Nullable<bool> Validated { get; set; }
    }
}
