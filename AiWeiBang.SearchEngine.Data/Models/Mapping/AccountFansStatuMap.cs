using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountFansStatuMap : EntityTypeConfiguration<AccountFansStatu>
    {
        public AccountFansStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.WeibangFansID);

            // Properties
            this.Property(t => t.WeibangFansID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NickName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("AccountFansStatus");
            this.Property(t => t.WeibangFansID).HasColumnName("WeibangFansID");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.SubStatus).HasColumnName("SubStatus");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}
