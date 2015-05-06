using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountManagerMap : EntityTypeConfiguration<AccountManager>
    {
        public AccountManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountID);

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AccountManager");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.IsAdmin).HasColumnName("IsAdmin");
        }
    }
}
