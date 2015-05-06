using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_NumMap : EntityTypeConfiguration<Article_Num>
    {
        public Article_NumMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticleID);

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Article_Num");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.PostUserID).HasColumnName("PostUserID");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.PostTime).HasColumnName("PostTime");
            this.Property(t => t.ReadNum).HasColumnName("ReadNum");
            this.Property(t => t.LikNum).HasColumnName("LikNum");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}
