using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class AccountSceneMap : EntityTypeConfiguration<AccountScene>
    {
        public AccountSceneMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountID);

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AccountScene");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.SceneID).HasColumnName("SceneID");
            this.Property(t => t.Checked).HasColumnName("Checked");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
