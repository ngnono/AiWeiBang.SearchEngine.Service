using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class WebAppSettingMap : EntityTypeConfiguration<WebAppSetting>
    {
        public WebAppSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MiniBackImage)
                .HasMaxLength(80);

            this.Property(t => t.ElementBackImage)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("WebAppSetting");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.MiniTheme).HasColumnName("MiniTheme");
            this.Property(t => t.MiniBackImage).HasColumnName("MiniBackImage");
            this.Property(t => t.TagTheme).HasColumnName("TagTheme");
            this.Property(t => t.ElementTheme).HasColumnName("ElementTheme");
            this.Property(t => t.ElementBackImage).HasColumnName("ElementBackImage");
            this.Property(t => t.ShowAvatar).HasColumnName("ShowAvatar");
            this.Property(t => t.IndexType).HasColumnName("IndexType");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
