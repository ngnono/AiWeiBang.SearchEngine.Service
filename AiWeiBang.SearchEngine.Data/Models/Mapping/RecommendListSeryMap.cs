using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class RecommendListSeryMap : EntityTypeConfiguration<RecommendListSery>
    {
        public RecommendListSeryMap()
        {
            // Primary Key
            this.HasKey(t => t.SeriesID);

            // Properties
            this.Property(t => t.SeriesName)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("RecommendListSeries");
            this.Property(t => t.SeriesID).HasColumnName("SeriesID");
            this.Property(t => t.SeriesName).HasColumnName("SeriesName");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
