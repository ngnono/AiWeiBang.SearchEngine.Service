using System;
using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WebApp_Slides
    {
        public int SlideID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Nullable<int> AccountID { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}
