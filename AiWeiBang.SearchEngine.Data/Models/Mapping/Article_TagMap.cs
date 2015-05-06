using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_TagMap : EntityTypeConfiguration<Article_Tag>
    {
        public Article_TagMap()
        {
            // Primary Key
            this.HasKey(t => t.TagID);

            // Properties
            this.Property(t => t.Tag)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Article_Tag");
            this.Property(t => t.TagID).HasColumnName("TagID");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.Tag).HasColumnName("Tag");
        }
    }
}
