using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class CrawlTimeMap : EntityTypeConfiguration<CrawlTime>
    {
        public CrawlTimeMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CrawlTime");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CrawlLastTime).HasColumnName("CrawlLastTime");
            this.Property(t => t.RetCode).HasColumnName("RetCode");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
        }
    }
}
