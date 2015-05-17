using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class Article_Num_DetailMap : EntityTypeConfiguration<Article_Num_Detail>
    {
        public Article_Num_DetailMap()
        {
            // Primary Key
            this.HasKey(t => t.DetailID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Article_Num_Detail");
            this.Property(t => t.DetailID).HasColumnName("DetailID");
            this.Property(t => t.ArticleID).HasColumnName("ArticleID");
            this.Property(t => t.PostUserID).HasColumnName("PostUserID");
            this.Property(t => t.PostTime).HasColumnName("PostTime");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            this.Property(t => t.ReadNum).HasColumnName("ReadNum");
            this.Property(t => t.LikeNum).HasColumnName("LikeNum");
            this.Property(t => t.SpanHour).HasColumnName("SpanHour");
        }
    }
}
