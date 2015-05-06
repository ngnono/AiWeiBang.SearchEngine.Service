using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class MsSettingMap : EntityTypeConfiguration<MsSetting>
    {
        public MsSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FirstName)
                .HasMaxLength(20);

            this.Property(t => t.FollowUrl)
                .HasMaxLength(256);

            this.Property(t => t.CoverImage)
                .HasMaxLength(80);

            this.Property(t => t.Skin)
                .HasMaxLength(10);

            this.Property(t => t.Welcome)
                .HasMaxLength(256);

            this.Property(t => t.FootLinkName)
                .HasMaxLength(10);

            this.Property(t => t.FootLinkUrl)
                .HasMaxLength(128);

            this.Property(t => t.ZhidahaoAppID)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MsSetting");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.ShowAvatar).HasColumnName("ShowAvatar");
            this.Property(t => t.ShowSlides).HasColumnName("ShowSlides");
            this.Property(t => t.ShowListStyle).HasColumnName("ShowListStyle");
            this.Property(t => t.FollowUrl).HasColumnName("FollowUrl");
            this.Property(t => t.CoverImage).HasColumnName("CoverImage");
            this.Property(t => t.Skin).HasColumnName("Skin");
            this.Property(t => t.Welcome).HasColumnName("Welcome");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
            this.Property(t => t.LinkSource).HasColumnName("LinkSource");
            this.Property(t => t.StyleIndex).HasColumnName("StyleIndex");
            this.Property(t => t.FootLinkName).HasColumnName("FootLinkName");
            this.Property(t => t.FootLinkUrl).HasColumnName("FootLinkUrl");
            this.Property(t => t.ZhidahaoAppID).HasColumnName("ZhidahaoAppID");
        }
    }
}
