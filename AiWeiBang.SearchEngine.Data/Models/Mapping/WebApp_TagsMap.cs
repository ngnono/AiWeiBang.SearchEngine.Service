using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WebApp_TagsMap : EntityTypeConfiguration<WebApp_Tags>
    {
        public WebApp_TagsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TagID, t.Url, t.RecordTime });

            // Properties
            this.Property(t => t.TagID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.TagName)
                .HasMaxLength(10);

            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("WebApp_Tags");
            this.Property(t => t.TagID).HasColumnName("TagID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.TagName).HasColumnName("TagName");
            this.Property(t => t.TagType).HasColumnName("TagType");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.ViewStatus).HasColumnName("ViewStatus");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
