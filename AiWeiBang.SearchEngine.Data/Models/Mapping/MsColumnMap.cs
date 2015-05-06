using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class MsColumnMap : EntityTypeConfiguration<MsColumn>
    {
        public MsColumnMap()
        {
            // Primary Key
            this.HasKey(t => t.ColumnID);

            // Properties
            this.Property(t => t.ColumnName)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MsColumn");
            this.Property(t => t.ColumnID).HasColumnName("ColumnID");
            this.Property(t => t.ColumnName).HasColumnName("ColumnName");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.ViewStatus).HasColumnName("ViewStatus");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
