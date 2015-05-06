using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WxUserRecommendMap : EntityTypeConfiguration<WxUserRecommend>
    {
        public WxUserRecommendMap()
        {
            // Primary Key
            this.HasKey(t => t.RecommendDate);

            // Properties
            this.Property(t => t.Introduction)
                .IsRequired()
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("WxUserRecommend");
            this.Property(t => t.RecommendDate).HasColumnName("RecommendDate");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Coin).HasColumnName("Coin");
            this.Property(t => t.Introduction).HasColumnName("Introduction");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
        }
    }
}
