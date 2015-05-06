using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class ImageMapMap : EntityTypeConfiguration<ImageMap>
    {
        public ImageMapMap()
        {
            // Primary Key
            this.HasKey(t => t.Md5);

            // Properties
            this.Property(t => t.Md5)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.LocalUrl)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.LocalThumbUrl)
                .HasMaxLength(80);

            this.Property(t => t.SrcUrl)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("ImageMap");
            this.Property(t => t.Md5).HasColumnName("Md5");
            this.Property(t => t.LocalUrl).HasColumnName("LocalUrl");
            this.Property(t => t.LocalThumbUrl).HasColumnName("LocalThumbUrl");
            this.Property(t => t.SrcUrl).HasColumnName("SrcUrl");
            this.Property(t => t.RepeatCount).HasColumnName("RepeatCount");
        }
    }
}
