using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class Union
    {
        public int UnionListID { get; set; }
        public string LinkName { get; set; }
        public string LinkWechat { get; set; }
        public string LinkPhone { get; set; }
        public string LinkQQ { get; set; }
        public string Alias { get; set; }
        public string QrcodeSrc { get; set; }
        public int ApplyAccountID { get; set; }
        public byte SortIndex { get; set; }
        public byte SysStatus { get; set; }
        public Nullable<int> SysAccountID { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public int Covers { get; set; }
    }
}
