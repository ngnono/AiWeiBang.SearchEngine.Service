using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AiWeiBang.SearchEngine.Data.Models.Mapping;

namespace AiWeiBang.SearchEngine.Data.Models
{
    public partial class WechatMsg_Content01Context : DbContext
    {
        static WechatMsg_Content01Context()
        {
            Database.SetInitializer<WechatMsg_Content01Context>(null);
        }

        public WechatMsg_Content01Context()
            : base("Name=WechatMsg_Content01Context")
        {
        }

        public DbSet<Article_Content> Article_Content { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Article_ContentMap());
        }
    }
}
