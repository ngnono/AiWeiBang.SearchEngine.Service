using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class AccountScene
    {
        public int AccountID { get; set; }
        public Nullable<int> SceneID { get; set; }
        public Nullable<bool> Checked { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
