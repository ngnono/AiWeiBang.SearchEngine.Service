using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class todelete_AccountCommit
    {
        public long LogID { get; set; }
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public System.DateTime CommitDate { get; set; }
        public string CommitIP { get; set; }
    }
}
