using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_RecommendMap : EntityTypeConfiguration<Article_Recommend>
    {
        public Article_RecommendMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticleID);

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Article_Recommend");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.ClassID).HasColumnName("ClassID");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
        }
    }
}
