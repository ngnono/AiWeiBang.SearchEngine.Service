using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class CrawlUrlMap : EntityTypeConfiguration<CrawlUrl>
    {
        public CrawlUrlMap()
        {
            // Primary Key
            this.HasKey(t => t.UrlID);

            // Properties
            this.Property(t => t.WechatBiz)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ParamUin)
                .HasMaxLength(32);

            this.Property(t => t.ParamKey)
                .HasMaxLength(256);

            this.Property(t => t.SrcUrl)
                .IsRequired()
                .HasMaxLength(1024);

            // Table & Column Mappings
            this.ToTable("CrawlUrl");
            this.Property(t => t.UrlID).HasColumnName("UrlID");
            this.Property(t => t.WechatBiz).HasColumnName("WechatBiz");
            this.Property(t => t.ParamUin).HasColumnName("ParamUin");
            this.Property(t => t.ParamKey).HasColumnName("ParamKey");
            this.Property(t => t.SrcUrl).HasColumnName("SrcUrl");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
            this.Property(t => t.CrawlTime).HasColumnName("CrawlTime");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
