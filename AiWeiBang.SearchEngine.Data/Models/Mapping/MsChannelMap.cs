using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class MsChannelMap : EntityTypeConfiguration<MsChannel>
    {
        public MsChannelMap()
        {
            // Primary Key
            this.HasKey(t => t.ChannelID);

            // Properties
            this.Property(t => t.ChannelName)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ExtID)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("MsChannel");
            this.Property(t => t.ChannelID).HasColumnName("ChannelID");
            this.Property(t => t.ChannelName).HasColumnName("ChannelName");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.ExtType).HasColumnName("ExtType");
            this.Property(t => t.ExtID).HasColumnName("ExtID");
            this.Property(t => t.ViewStatus).HasColumnName("ViewStatus");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
