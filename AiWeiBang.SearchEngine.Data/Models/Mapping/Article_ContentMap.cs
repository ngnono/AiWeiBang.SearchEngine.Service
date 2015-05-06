using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_ContentMap : EntityTypeConfiguration<Article_Content>
    {
        public Article_ContentMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticleID);

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Article_Content");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.Content).HasColumnName("Content");
        }
    }
}
