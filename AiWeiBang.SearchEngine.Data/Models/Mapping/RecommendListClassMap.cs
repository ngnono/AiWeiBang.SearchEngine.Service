using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class RecommendListClassMap : EntityTypeConfiguration<RecommendListClass>
    {
        public RecommendListClassMap()
        {
            // Primary Key
            this.HasKey(t => t.ClassID);

            // Properties
            this.Property(t => t.ClassName)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("RecommendListClass");
            this.Property(t => t.ClassID).HasColumnName("ClassID");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
            this.Property(t => t.ListID).HasColumnName("ListID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
