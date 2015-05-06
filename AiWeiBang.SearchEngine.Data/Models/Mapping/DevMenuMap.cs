using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AiWeiBang.SearchEngine.Data.Models.Mapping
{
    public class DevMenuMap : EntityTypeConfiguration<DevMenu>
    {
        public DevMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuID);

            // Properties
            this.Property(t => t.ButtonName)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.KeyValue)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("DevMenus");
            this.Property(t => t.MenuID).HasColumnName("MenuID");
            this.Property(t => t.ButtonName).HasColumnName("ButtonName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.KeyValue).HasColumnName("KeyValue");
            this.Property(t => t.SortIndex).HasColumnName("SortIndex");
            this.Property(t => t.ParentMenuID).HasColumnName("ParentMenuID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.RecordTime).HasColumnName("RecordTime");
        }
    }
}
