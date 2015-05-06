using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class UnionMap : EntityTypeConfiguration<Union>
    {
        public UnionMap()
        {
            // Primary Key
            this.HasKey(t => t.UnionListID);

            // Properties
            this.Property(t => t.UnionListID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LinkName)
                .HasMaxLength(20);

            this.Property(t => t.LinkWechat)
                .HasMaxLength(32);

            this.Property(t => t.LinkPhone)
                .HasMaxLength(20);

            this.Property(t => t.LinkQQ)
                .HasMaxLength(20);

            this.Property(t => t.Alias)
                .HasMaxLength(30);

            this.Property(t => t.QrcodeSrc)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Union");
            this.Property(t => t.UnionListID).HasColumnName("UnionListID");
            this.Property(t => t.LinkName).HasColumnName("LinkName");
            this.Property(t => t.LinkWechat).HasColumnName("LinkWechat");
            this.Property(t => t.LinkPhone).HasColumnName("LinkPhone");
            this.Property(t => t.LinkQQ).HasColumnName("LinkQQ");
            this.Property(t => t.Alias).HasColumnName("Alias");
            this.Property(t => t.QrcodeSrc).HasColumnName("QrcodeSrc");
            this.Property(t => t.ApplyAccountID).HasColumnName("ApplyAccountID");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.SysStatus).HasColumnName("SysStatus");
            this.Property(t => t.SysAccountID).HasColumnName("SysAccountID");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            this.Property(t => t.Covers).HasColumnName("Covers");
        }
    }
}
