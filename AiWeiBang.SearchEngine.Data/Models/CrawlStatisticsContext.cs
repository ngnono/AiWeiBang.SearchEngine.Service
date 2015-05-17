using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AiWeiBang.SearchEngine.Data.Models.Mapping;

namespace AiWeiBang.SearchEngine.Data.Models
{
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

        public DbSet<Article_Num_Detail> Article_Num_Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Article_Num_DetailMap());
        }
    }
}
