using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class ImageMap
    {
        public string Md5 { get; set; }
        public string LocalUrl { get; set; }
        public string LocalThumbUrl { get; set; }
        public string SrcUrl { get; set; }
        public Nullable<int> RepeatCount { get; set; }
    }
}
