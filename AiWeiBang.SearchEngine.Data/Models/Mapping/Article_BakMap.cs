using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_BakMap : EntityTypeConfiguration<Article_Bak>
    {
        public Article_BakMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticleID);

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ArticleTitle)
                .HasMaxLength(80);

            this.Property(t => t.Summary)
                .HasMaxLength(128);

            this.Property(t => t.Sourceurl)
                .HasMaxLength(512);

            this.Property(t => t.MediaUrl)
                .HasMaxLength(128);

            this.Property(t => t.MediaLocal)
                .HasMaxLength(128);

            this.Property(t => t.MedialLocalTumb)
                .HasMaxLength(128);

            this.Property(t => t.PostUserExt)
                .HasMaxLength(20);

            this.Property(t => t.SrcUrl)
                .HasMaxLength(256);

            this.Property(t => t.WechatBiz_)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Article_Bak");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.ArticleTitle).HasColumnName("ArticleTitle");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.Sourceurl).HasColumnName("Sourceurl");
            this.Property(t => t.MediaUrl).HasColumnName("MediaUrl");
            this.Property(t => t.MediaLocal).HasColumnName("MediaLocal");
            this.Property(t => t.MedialLocalTumb).HasColumnName("MedialLocalTumb");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.PostTime).HasColumnName("PostTime");
            this.Property(t => t.PostUserID).HasColumnName("PostUserID");
            this.Property(t => t.PostUserExt).HasColumnName("PostUserExt");
            this.Property(t => t.MsgType).HasColumnName("MsgType");
            this.Property(t => t.SrcUrl).HasColumnName("SrcUrl");
            this.Property(t => t.CategoryID_).HasColumnName("CategoryID_");
            this.Property(t => t.WechatBiz_).HasColumnName("WechatBiz_");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.Hits).HasColumnName("Hits");
            this.Property(t => t.ShowCoverPic).HasColumnName("ShowCoverPic");
            this.Property(t => t.BackTime).HasColumnName("BackTime");
            this.Property(t => t.ArticleIndex).HasColumnName("ArticleIndex");
        }
    }
}
