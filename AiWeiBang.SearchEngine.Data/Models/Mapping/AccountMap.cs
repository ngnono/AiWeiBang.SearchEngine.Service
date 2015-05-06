using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountID);

            // Properties
            this.Property(t => t.AccountName)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.WeiboID)
                .HasMaxLength(20);

            this.Property(t => t.Gender)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.Wechat)
                .HasMaxLength(32);

            this.Property(t => t.Email)
                .HasMaxLength(32);

            this.Property(t => t.Mobile)
                .HasMaxLength(16);

            this.Property(t => t.QQ)
                .HasMaxLength(16);

            this.Property(t => t.AvatarUrl)
                .HasMaxLength(80);

            this.Property(t => t.AvatarLocalID)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.WeiboID).HasColumnName("WeiboID");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Wechat).HasColumnName("Wechat");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.AvatarUrl).HasColumnName("AvatarUrl");
            this.Property(t => t.AvatarLocalID).HasColumnName("AvatarLocalID");
            this.Property(t => t.SignupTime).HasColumnName("SignupTime");
        }
    }
}
