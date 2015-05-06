using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AiWeiBang.SearchEngine.Dtos
{
    public class ArticleContentDto
    {
        public int ArticleID { get; set; }

        public string Content { get; set; }
    }
}