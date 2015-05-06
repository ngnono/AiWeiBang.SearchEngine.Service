using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WebApp_SlidesMap : EntityTypeConfiguration<WebApp_Slides>
    {
        public WebApp_SlidesMap()
        {
            // Primary Key
            this.HasKey(t => t.SlideID);

            // Properties
            this.Property(t => t.Image)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.Description)
                .HasMaxLength(80);

            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("WebApp_Slides");
            this.Property(t => t.SlideID).HasColumnName("SlideID");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
