using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class CrawlClientMap : EntityTypeConfiguration<CrawlClient>
    {
        public CrawlClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientID);

            // Properties
            this.Property(t => t.CID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CrawlClient");
            this.Property(t => t.CID).HasColumnName("CID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
        }
    }
}
