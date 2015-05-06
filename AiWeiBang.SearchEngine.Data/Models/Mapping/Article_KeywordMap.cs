using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_KeywordMap : EntityTypeConfiguration<Article_Keyword>
    {
        public Article_KeywordMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ArticleID, t.Keyword });

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Keyword)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Article_Keyword");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.Keyword).HasColumnName("Keyword");
            this.Property(t => t.PostUserID).HasColumnName("PostUserID");
        }
    }
}
