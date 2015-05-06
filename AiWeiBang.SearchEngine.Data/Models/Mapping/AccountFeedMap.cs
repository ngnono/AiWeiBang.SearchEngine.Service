using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountFeedMap : EntityTypeConfiguration<AccountFeed>
    {
        public AccountFeedMap()
        {
            // Primary Key
            this.HasKey(t => t.FeedID);

            // Properties
            this.Property(t => t.FeedContent)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.RefererUrl)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AccountFeed");
            this.Property(t => t.FeedID).HasColumnName("FeedID");
            this.Property(t => t.FeedType).HasColumnName("FeedType");
            this.Property(t => t.FeedContent).HasColumnName("FeedContent");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RelID).HasColumnName("RelID");
            this.Property(t => t.RefererUrl).HasColumnName("RefererUrl");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
