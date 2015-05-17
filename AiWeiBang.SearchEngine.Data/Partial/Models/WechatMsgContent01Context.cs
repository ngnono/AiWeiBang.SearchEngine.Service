using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiWeiBang.SearchEngine.Data.Models
{

    public partial class WechatMsg_Content01Context
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringName">WechatMsg_Content01Context</param>
        public WechatMsg_Content01Context(string connectionStringName)
            : base("Name=" + connectionStringName)
        {
        }
    }

    public partial class CrawlStatisticsContext : DbContext
    {
        static CrawlStatisticsContext()
        {
            Database.SetInitializer<CrawlStatisticsContext>(null);
        }

        public CrawlStatisticsContext()
            : base("Name=CrawlStatisticsContext")
        {
        }

        public DbSet<Article_Num_Detail> Article_Num_Details { get; set; }

    }

    public partial class Article_Num_Detail
    {
        public int ArticleID { get; set; }

        public DateTime UpdateTime { get; set; }

        public int ReadNum { get; set; }

        public int LikeNum { get; set; }

    }
}
