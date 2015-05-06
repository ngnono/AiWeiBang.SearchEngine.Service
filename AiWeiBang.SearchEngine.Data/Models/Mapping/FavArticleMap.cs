using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class FavArticleMap : EntityTypeConfiguration<FavArticle>
    {
        public FavArticleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AccountID, t.ArticleID });

            // Properties
            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("FavArticle");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
