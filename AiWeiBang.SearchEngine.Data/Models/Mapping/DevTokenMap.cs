using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class DevTokenMap : EntityTypeConfiguration<DevToken>
    {
        public DevTokenMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AppId)
                .HasMaxLength(20);

            this.Property(t => t.Secret)
                .HasMaxLength(32);

            this.Property(t => t.Token)
                .HasMaxLength(512);

            // Table & Column Mappings
            this.ToTable("DevToken");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AppId).HasColumnName("AppId");
            this.Property(t => t.Secret).HasColumnName("Secret");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.ExpiresTime).HasColumnName("ExpiresTime");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
