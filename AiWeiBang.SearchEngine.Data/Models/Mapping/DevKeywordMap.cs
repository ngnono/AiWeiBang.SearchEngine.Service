using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class DevKeywordMap : EntityTypeConfiguration<DevKeyword>
    {
        public DevKeywordMap()
        {
            // Primary Key
            this.HasKey(t => t.KeywordID);

            // Properties
            this.Property(t => t.Keyword)
                .HasMaxLength(20);

            this.Property(t => t.ReplyContent)
                .HasMaxLength(600);

            // Table & Column Mappings
            this.ToTable("DevKeyword");
            this.Property(t => t.KeywordID).HasColumnName("KeywordID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Keyword).HasColumnName("Keyword");
            this.Property(t => t.ReplyType).HasColumnName("ReplyType");
            this.Property(t => t.ReplyContent).HasColumnName("ReplyContent");
            this.Property(t => t.ModeSwitch).HasColumnName("ModeSwitch");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
