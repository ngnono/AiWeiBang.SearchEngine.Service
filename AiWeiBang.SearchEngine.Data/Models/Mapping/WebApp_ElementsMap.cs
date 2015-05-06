using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WebApp_ElementsMap : EntityTypeConfiguration<WebApp_Elements>
    {
        public WebApp_ElementsMap()
        {
            // Primary Key
            this.HasKey(t => t.ElementID);

            // Properties
            this.Property(t => t.ElementName)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(80);

            this.Property(t => t.Icon)
                .HasMaxLength(80);

            this.Property(t => t.Url)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("WebApp_Elements");
            this.Property(t => t.ElementID).HasColumnName("ElementID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ElementName).HasColumnName("ElementName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Icon).HasColumnName("Icon");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.ViewStatus).HasColumnName("ViewStatus");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
