using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class RecommendListDetailMap : EntityTypeConfiguration<RecommendListDetail>
    {
        public RecommendListDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListID, t.UserID });

            // Properties
            this.Property(t => t.ListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Introduction)
                .HasMaxLength(256);

            this.Property(t => t.FollowUrl)
                .HasMaxLength(256);

            this.Property(t => t.ArticleUrl)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("RecommendListDetail");
            this.Property(t => t.ListID).HasColumnName("ListID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.Introduction).HasColumnName("Introduction");
            this.Property(t => t.FollowUrl).HasColumnName("FollowUrl");
            this.Property(t => t.ArticleUrl).HasColumnName("ArticleUrl");
            this.Property(t => t.ClassID).HasColumnName("ClassID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
            this.Property(t => t.ClickCount).HasColumnName("ClickCount");
        }
    }
}
