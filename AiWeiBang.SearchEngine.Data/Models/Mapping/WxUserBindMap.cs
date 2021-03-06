using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WxUserBindMap : EntityTypeConfiguration<WxUserBind>
    {
        public WxUserBindMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AccountID, t.UserID });

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("WxUserBind");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
