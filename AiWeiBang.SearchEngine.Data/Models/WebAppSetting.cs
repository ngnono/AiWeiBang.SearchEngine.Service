using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WebAppSetting
    {
        public int UserID { get; set; }
        public Nullable<byte> MiniTheme { get; set; }
        public string MiniBackImage { get; set; }
        public byte TagTheme { get; set; }
        public byte ElementTheme { get; set; }
        public string ElementBackImage { get; set; }
        public Nullable<bool> ShowAvatar { get; set; }
        public Nullable<byte> IndexType { get; set; }
        public Nullable<int> AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
