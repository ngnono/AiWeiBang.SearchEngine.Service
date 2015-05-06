using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_ExtMap : EntityTypeConfiguration<Article_Ext>
    {
        public Article_ExtMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticleID);

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Article_Ext");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.CopyrightStat).HasColumnName("CopyrightStat");
        }
    }
}
