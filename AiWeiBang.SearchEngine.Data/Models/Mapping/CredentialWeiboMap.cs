using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class CredentialWeiboMap : EntityTypeConfiguration<CredentialWeibo>
    {
        public CredentialWeiboMap()
        {
            // Primary Key
            this.HasKey(t => t.WeiboID);

            // Properties
            this.Property(t => t.WeiboID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Token)
                .HasMaxLength(32);

            this.Property(t => t.RefreshToken)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("CredentialWeibo");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.WeiboID).HasColumnName("WeiboID");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.RefreshToken).HasColumnName("RefreshToken");
            this.Property(t => t.ExpiresIn).HasColumnName("ExpiresIn");
            this.Property(t => t.ExpiresTime).HasColumnName("ExpiresTime");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
