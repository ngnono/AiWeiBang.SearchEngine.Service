using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WxUserManageMap : EntityTypeConfiguration<WxUserManage>
    {
        public WxUserManageMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AccountID, t.UserID });

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("WxUserManage");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
