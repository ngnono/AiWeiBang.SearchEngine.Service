using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Log_AccountOperateMap : EntityTypeConfiguration<Log_AccountOperate>
    {
        public Log_AccountOperateMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.LogIP)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Log_AccountOperate");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.BusiType).HasColumnName("BusiType");
            this.Property(t => t.BusiID).HasColumnName("BusiID");
            this.Property(t => t.LogIP).HasColumnName("LogIP");
            this.Property(t => t.RecordDate).HasColumnName("RecordDate");
        }
    }
}
