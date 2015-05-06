using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AiWeiBang.SearchEngine.Data.Models.Mapping;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WechatMsgContext : DbContext
    {
        static WechatMsgContext()
        {
            Database.SetInitializer<WechatMsgContext>(null);
        }

        public WechatMsgContext()
            : base("Name=WechatMsgContext")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Article_Bak> Article_Bak { get; set; }
        public DbSet<Article_Ext> Article_Ext { get; set; }
        public DbSet<Article_Keyword> Article_Keyword { get; set; }
        public DbSet<Article_Num> Article_Num { get; set; }
        public DbSet<Article_Pop> Article_Pop { get; set; }
        public DbSet<Article_PopBlack> Article_PopBlack { get; set; }
        public DbSet<Article_Recommend> Article_Recommend { get; set; }
        public DbSet<Article_Tag> Article_Tag { get; set; }
        public DbSet<Article_Temp> Article_Temp { get; set; }
        public DbSet<CrawlClient> CrawlClients { get; set; }
        public DbSet<CrawlMap> CrawlMaps { get; set; }
        public DbSet<CrawlTime> CrawlTimes { get; set; }
        public DbSet<CrawlUrl> CrawlUrls { get; set; }
        public DbSet<ImageMap> ImageMaps { get; set; }
        public DbSet<VerifyCode> VerifyCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new Article_BakMap());
            modelBuilder.Configurations.Add(new Article_ExtMap());
            modelBuilder.Configurations.Add(new Article_KeywordMap());
            modelBuilder.Configurations.Add(new Article_NumMap());
            modelBuilder.Configurations.Add(new Article_PopMap());
            modelBuilder.Configurations.Add(new Article_PopBlackMap());
            modelBuilder.Configurations.Add(new Article_RecommendMap());
            modelBuilder.Configurations.Add(new Article_TagMap());
            modelBuilder.Configurations.Add(new Article_TempMap());
            modelBuilder.Configurations.Add(new CrawlClientMap());
            modelBuilder.Configurations.Add(new CrawlMapMap());
            modelBuilder.Configurations.Add(new CrawlTimeMap());
            modelBuilder.Configurations.Add(new CrawlUrlMap());
            modelBuilder.Configurations.Add(new ImageMapMap());
            modelBuilder.Configurations.Add(new VerifyCodeMap());
        }
    }
}
