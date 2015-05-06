using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class todelete_AccountCommitMap : EntityTypeConfiguration<todelete_AccountCommit>
    {
        public todelete_AccountCommitMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.CommitIP)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("todelete_AccountCommit");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CommitDate).HasColumnName("CommitDate");
            this.Property(t => t.CommitIP).HasColumnName("CommitIP");
        }
    }
}
