using System.Collections.Generic;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public class ArticleColumnFilter
    {
        public List<int> ArticleIds { get; set; }

        public List<int> ColumnIds { get; set; }

        public List<int> UserIds { get; set; }

        public SqlRange<int?> RangeArticleId { get; set; }
    }
}