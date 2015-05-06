using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class VerifyCodeMap : EntityTypeConfiguration<VerifyCode>
    {
        public VerifyCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.WechatID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("VerifyCode");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.WechatID).HasColumnName("WechatID");
            this.Property(t => t.UpperLimit).HasColumnName("UpperLimit");
            this.Property(t => t.GenDatetime).HasColumnName("GenDatetime");
            this.Property(t => t.Used).HasColumnName("Used");
            this.Property(t => t.UseDateTime).HasColumnName("UseDateTime");
        }
    }
}
