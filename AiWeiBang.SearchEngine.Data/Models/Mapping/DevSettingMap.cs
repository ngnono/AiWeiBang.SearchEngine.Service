using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class DevSettingMap : EntityTypeConfiguration<DevSetting>
    {
        public DevSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.WelcomeContent)
                .HasMaxLength(512);

            this.Property(t => t.ReplyContent)
                .HasMaxLength(512);

            // Table & Column Mappings
            this.ToTable("DevSetting");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.WelcomeType).HasColumnName("WelcomeType");
            this.Property(t => t.WelcomeContent).HasColumnName("WelcomeContent");
            this.Property(t => t.ReplyType).HasColumnName("ReplyType");
            this.Property(t => t.ReplyContent).HasColumnName("ReplyContent");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.MatchArticleKeyword).HasColumnName("MatchArticleKeyword");
            this.Property(t => t.MatchArticleContent).HasColumnName("MatchArticleContent");
            this.Property(t => t.MatchArticlePostdate).HasColumnName("MatchArticlePostdate");
        }
    }
}
