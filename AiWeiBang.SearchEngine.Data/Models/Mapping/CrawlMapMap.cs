using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class CrawlMapMap : EntityTypeConfiguration<CrawlMap>
    {
        public CrawlMapMap()
        {
            // Primary Key
            this.HasKey(t => new { t.WechatBiz, t.AppmsgID, t.ItemIdx });

            // Properties
            this.Property(t => t.WechatBiz)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.AppmsgID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ItemIdx)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CrawlMap");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.WechatBiz).HasColumnName("WechatBiz");
            this.Property(t => t.AppmsgID).HasColumnName("AppmsgID");
            this.Property(t => t.ItemIdx).HasColumnName("ItemIdx");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
