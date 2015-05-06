using System;
using AiWeiBang.SearchEngine.Contract;
using AiWeiBang.SearchEngine.Dtos;

namespace AiWeiBang.SearchEngine.Cores.Articles
{
    public class ArticleFilter : PagerRequest
    {
        /// <summary>
        /// 查询串
        /// </summary>
        /// <param name="pageNum">page num</param>
        /// <param name="pageSize">page size</param>
        public ArticleFilter(int pageNum, int pageSize)
            : base(pageNum, pageSize)
        {
        }

        /// <summary>
        /// 文章ID
        /// </summary>
        public int? ArticleID { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public SqlRange<DateTime?> PostDateRange { get; set; }

        /// <summary>
        /// 记录日期
        /// </summary>
        public SqlRange<DateTime?> RecordDateRange { get; set; }

        /// <summary>
        /// 文章ID 范围查询
        /// </summary>
        public SqlRange<int?> ArticleIdRange { get; set; }
    }
}