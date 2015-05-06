using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountUserSettingMap : EntityTypeConfiguration<AccountUserSetting>
    {
        public AccountUserSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountID);

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tags)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("AccountUserSetting");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.KindID).HasColumnName("KindID");
            this.Property(t => t.KindClassID).HasColumnName("KindClassID");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.Tags).HasColumnName("Tags");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            this.Property(t => t.IsCheck).HasColumnName("IsCheck");
        }
    }
}
