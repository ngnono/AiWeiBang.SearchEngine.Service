using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class CredentialMailMap : EntityTypeConfiguration<CredentialMail>
    {
        public CredentialMailMap()
        {
            // Primary Key
            this.HasKey(t => t.Mail);

            // Properties
            this.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ValidationCode)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("CredentialMail");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.ValidationCode).HasColumnName("ValidationCode");
            this.Property(t => t.Validated).HasColumnName("Validated");
        }
    }
}
