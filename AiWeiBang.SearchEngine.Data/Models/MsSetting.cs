using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class MsSetting
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public Nullable<bool> ShowAvatar { get; set; }
        public Nullable<bool> ShowSlides { get; set; }
        public Nullable<byte> ShowListStyle { get; set; }
        public string FollowUrl { get; set; }
        public string CoverImage { get; set; }
        public string Skin { get; set; }
        public string Welcome { get; set; }
        public int AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
        public Nullable<bool> LinkSource { get; set; }
        public Nullable<byte> StyleIndex { get; set; }
        public string FootLinkName { get; set; }
        public string FootLinkUrl { get; set; }
        public string ZhidahaoAppID { get; set; }
    }
}
