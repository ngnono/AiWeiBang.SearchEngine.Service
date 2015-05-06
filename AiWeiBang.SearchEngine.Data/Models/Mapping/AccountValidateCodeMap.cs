using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountValidateCodeMap : EntityTypeConfiguration<AccountValidateCode>
    {
        public AccountValidateCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountID);

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AccountValidateCode");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.ValidateCode).HasColumnName("ValidateCode");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
