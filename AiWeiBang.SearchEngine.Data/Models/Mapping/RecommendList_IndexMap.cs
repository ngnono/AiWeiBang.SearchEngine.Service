using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class RecommendList_IndexMap : EntityTypeConfiguration<RecommendList_Index>
    {
        public RecommendList_IndexMap()
        {
            // Primary Key
            this.HasKey(t => t.ListID);

            // Properties
            this.Property(t => t.ListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RecommendList_Index");
            this.Property(t => t.ListID).HasColumnName("ListID");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.BeginTime).HasColumnName("BeginTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
        }
    }
}
