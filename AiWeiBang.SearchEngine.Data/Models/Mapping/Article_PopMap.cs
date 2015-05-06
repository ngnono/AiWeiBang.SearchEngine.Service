using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_PopMap : EntityTypeConfiguration<Article_Pop>
    {
        public Article_PopMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticleID);

            // Properties
            this.Property(t => t.ArticleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Article_Pop");
            this.Property(t => t.PopDate).HasColumnName("PopDate");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.PostUserID).HasColumnName("PostUserID");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.ReadRate).HasColumnName("ReadRate");
            this.Property(t => t.LikeRate).HasColumnName("LikeRate");
            this.Property(t => t.ReadNumIndex).HasColumnName("ReadNumIndex");
            this.Property(t => t.PopIndex).HasColumnName("PopIndex");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
        }
    }
}
