using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class MsColumnArticleMap : EntityTypeConfiguration<MsColumnArticle>
    {
        public MsColumnArticleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ColumnID, t.ArticleID });

            // Properties
            this.Property(t => t.ColumnID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MsColumnArticle");
            this.Property(t => t.ColumnID).HasColumnName("ColumnID");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
        }
    }
}
