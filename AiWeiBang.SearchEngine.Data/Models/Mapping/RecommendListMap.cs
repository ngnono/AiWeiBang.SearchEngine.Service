using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class RecommendListMap : EntityTypeConfiguration<RecommendList>
    {
        public RecommendListMap()
        {
            // Primary Key
            this.HasKey(t => t.ListID);

            // Properties
            this.Property(t => t.ListName)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(80);

            this.Property(t => t.Icon)
                .HasMaxLength(80);

            this.Property(t => t.Banner)
                .HasMaxLength(80);

            this.Property(t => t.FirstName)
                .HasMaxLength(10);

            this.Property(t => t.FootMemberName)
                .HasMaxLength(10);

            this.Property(t => t.FootArticleName)
                .HasMaxLength(10);

            this.Property(t => t.FootCustomName)
                .HasMaxLength(10);

            this.Property(t => t.FootCustomUrl)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("RecommendList");
            this.Property(t => t.ListID).HasColumnName("ListID");
            this.Property(t => t.ListName).HasColumnName("ListName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Banner).HasColumnName("Banner");
            this.Property(t => t.SeriesID).HasColumnName("SeriesID");
            this.Property(t => t.ShowArticle).HasColumnName("ShowArticle");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.FootMemberName).HasColumnName("FootMemberName");
            this.Property(t => t.FootArticleShow).HasColumnName("FootArticleShow");
            this.Property(t => t.FootArticleName).HasColumnName("FootArticleName");
            this.Property(t => t.FootCustomName).HasColumnName("FootCustomName");
            this.Property(t => t.FootCustomUrl).HasColumnName("FootCustomUrl");
            this.Property(t => t.FootCustomUrlViewStatus).HasColumnName("FootCustomUrlViewStatus");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
            this.Property(t => t.AccountCount).HasColumnName("AccountCount");
            this.Property(t => t.ViewCount).HasColumnName("ViewCount");
            this.Property(t => t.IndexRandom).HasColumnName("IndexRandom");
        }
    }
}
